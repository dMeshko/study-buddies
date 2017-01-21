using System;
using System.Collections.Generic;
using StudyBuddies.Business.ViewModels.Groups;

namespace StudyBuddies.Business.Services
{
    public interface IPostService
    {
        #region Post

        PostViewModel GetPostById(Guid postId);
        void CreatePost(CreatePostViewModel post);
        void DeletePost(Guid postId);

        #endregion

        #region Comment

        IList<CommentViewModel> GetAllComments(Guid postId);
        void AddComment(CreateCommentViewModel comment);
        void DeleteComment(Guid postId, Guid commentId);

        #endregion
    }
}
