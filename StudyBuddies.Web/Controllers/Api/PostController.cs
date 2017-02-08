using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Web.Http;
using StudyBuddies.Business.Services;
using StudyBuddies.Business.ViewModels.Groups;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Net.Http.Headers;
using System.Collections.Specialized;
using StudyBuddies.Web.App_Start;

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

            var post = _postService.CreatePost(model);
            return Ok(post);
        }

        [Route("attachment")]
        public async Task<IHttpActionResult> PostAttachment()
        {
            AttachmentViewModel model = new AttachmentViewModel();

            var provider = await Request.Content.ReadAsMultipartAsync(new InMemoryMultipartFormDataStreamProvider());
            
            // access form data
            NameValueCollection formData = provider.FormData;
            model.PostId = new Guid(formData.Get("postId"));
            
            // access files
            IList<HttpContent> files = provider.Files;
            
            HttpContent file = files[0];
            model.Name = file.Headers.ContentDisposition.FileName;
            model.ContentType = file.Headers.ContentType.MediaType;

            // access file's stream
            Stream fileStream = await file.ReadAsStreamAsync();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                model.File = memoryStream.ToArray();
            }

            _postService.AddAttachment(model);
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

            var comment = _postService.AddComment(model);
            return Ok(comment);
        }

        [Route("{id:guid}/comment/{commentId:guid}")]
        public IHttpActionResult DeleteComment(Guid id, Guid commentId)
        {
            var deletedCommentId = _postService.DeleteComment(id, commentId);
            return Ok(deletedCommentId);
        }

        #endregion
    }
}