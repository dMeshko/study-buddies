using System;
using System.Collections.Generic;
using AutoMapper;
using StudyBuddies.Business.Infrastructure.Exceptions;
using StudyBuddies.Business.Infrastructure.Exceptions.Messages;
using StudyBuddies.Business.ViewModels.Groups;
using StudyBuddies.Data.Repository.Groups;
using StudyBuddies.Data.Repository.Users;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Business.Services.Implementation
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ICommentRepository _commentRepository;

        public PostService(IPostRepository postRepository, IUserRepository userRepository, IGroupRepository groupRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _groupRepository = groupRepository;
            _commentRepository = commentRepository;
        }

        #region Post

        public PostViewModel GetPostById(Guid postId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            return Mapper.Map<Post, PostViewModel>(post);
        }

        public PostViewModel CreatePost(CreatePostViewModel post)
        {
            if (post == null)
                throw new BusinessLayerException(AppExceptionMessage.INVALID_INTERNAL_STATE);

            var user = _userRepository.GetById(post.User.Id);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var group = _groupRepository.GetById(post.Group.Id);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var dboPost = new Post(user, group, post.Content);
            // need the line below to mark the entity for saving, and thus generate id for the current session.
            // since my UoW is per request, I can't close the session to get the id with the collection persistance.
            _postRepository.Add(dboPost); 
            group.AddPost(dboPost);

            return Mapper.Map<Post, PostViewModel>(dboPost);
        }

        public void AddAttachment(AttachmentViewModel attachment)
        {
            if (attachment == null)
                throw new ArgumentNullException(nameof(attachment));

            var post = _postRepository.GetById(attachment.PostId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            var dboAttachment = new Attachment(post, attachment.Name, attachment.ContentType, attachment.File);
            post.AddAttachment(dboAttachment);
        }

        public void DeletePost(Guid postId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            _postRepository.Delete(post);
        }

        #endregion

        #region Comment

        public List<CommentViewModel> GetAllComments(Guid postId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            var comments = post.Comments;
            return Mapper.Map<IList<Comment>, List<CommentViewModel>>(comments);
        }

        public CommentViewModel AddComment(CreateCommentViewModel comment)
        {
            if (comment == null)
                throw new BusinessLayerException(AppExceptionMessage.INVALID_INTERNAL_STATE);

            var user = _userRepository.GetById(comment.User.Id);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var post = _postRepository.GetById(comment.Post.Id);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            var dboComment = new Comment(user, post, comment.Content);
            post.AddComment(dboComment);
            _postRepository.Update(post);

            return Mapper.Map<Comment, CommentViewModel>(dboComment);
        }

        public Guid DeleteComment(Guid postId, Guid commentId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            var comment = _commentRepository.GetById(commentId);
            if (comment == null)
                throw new NotFoundException(CommentExceptionMessage.COMMENT_NOT_FOUND);

            post.RemoveComment(comment);
            return comment.Id;
        }

        #endregion
    }
}
