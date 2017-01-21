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

        public void CreatePost(CreatePostViewModel post)
        {
            if (post == null)
                throw new BusinessLayerException(AppExceptionMessage.INVALID_INTERNAL_STATE);

            var user = _userRepository.GetById(post.User.Id);
            if (user == null)
                throw new NotFoundException(UserExceptionMessage.USER_NOT_FOUND);

            var group = _groupRepository.GetById(post.Group.Id);
            if (group == null)
                throw new NotFoundException(GroupExceptionMessage.GROUP_NOT_FOUND);

            var dboPost = new Post(user, group, post.Content, Mapper.Map<IList<AttachmentViewModel>, List<Attachment>>(post.Attachments));
            _postRepository.Add(dboPost);
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

        public IList<CommentViewModel> GetAllComments(Guid postId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            var comments = post.Comments;
            return Mapper.Map<IList<Comment>, IList<CommentViewModel>>(comments);
        }

        public void AddComment(CreateCommentViewModel comment)
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
            _commentRepository.Add(dboComment);
        }

        public void DeleteComment(Guid postId, Guid commentId)
        {
            var post = _postRepository.GetById(postId);
            if (post == null)
                throw new NotFoundException(PostExceptionMessage.POST_NOT_FOUND);

            var comment = _commentRepository.GetById(commentId);
            if (comment == null)
                throw new NotFoundException(CommentExceptionMessage.COMMENT_NOT_FOUND);

            post.RemoveComment(comment);
        }

        #endregion
    }
}
