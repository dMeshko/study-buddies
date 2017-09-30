using System;
using System.Collections.Generic;
using StudyBuddies.Business.ViewModels.Groups;

namespace StudyBuddies.Business.Services
{
    public interface IPostService
    {
        #region Post

        IList<PostViewModel> GetAllPosts();
        PostViewModel GetPostById(Guid postId);
        PostViewModel CreatePost(CreatePostViewModel post);
        void AddAttachment(AttachmentViewModel attachment);
        void DeletePost(Guid postId);

        #endregion

        #region Comment

        List<CommentViewModel> GetAllComments(Guid postId);
        CommentViewModel AddComment(CreateCommentViewModel comment);
        Guid DeleteComment(Guid postId, Guid commentId);

        #endregion
    }
}
