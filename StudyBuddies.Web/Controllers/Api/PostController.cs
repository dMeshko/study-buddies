using System;
using System.Web.Http;
using StudyBuddies.Business.Services;
using StudyBuddies.Business.ViewModels.Groups;

namespace StudyBuddies.Web.Controllers.Api
{
    [RoutePrefix("api/post")]
    public class PostController : ApiController
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        #region Post

        [Route("{id:guid}")]
        public IHttpActionResult Get(Guid id)
        {
            var post = _postService.GetPostById(id);
            return Ok(post);
        }

        [Route("")]
        public IHttpActionResult Post(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _postService.CreatePost(model);
            return Ok();
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            _postService.DeletePost(id);
            return Ok();
        }

        #endregion

        #region Comment

        [Route("{id:guid}/comment")]
        public IHttpActionResult GetAllComments(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = _postService.GetAllComments(id);
            return Ok(comments);
        }

        [Route("{id:guid}/comment")]
        public IHttpActionResult AddComment(CreateCommentViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _postService.AddComment(model);
            return Ok();
        }

        [Route("{id:guid}/comment/{commentId:guid}")]
        public IHttpActionResult DeleteComment(Guid id, Guid commentId)
        {
            _postService.DeleteComment(id, commentId);
            return Ok();
        }

        #endregion
    }
}