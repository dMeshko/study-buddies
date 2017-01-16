using StudyBuddies.Service.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.IO;
using StudyBuddies.Service.ViewModels.Users;

namespace StudyBuddies.Web.Controllers.Api
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [Route("{id:guid}")]
        public IHttpActionResult Get(Guid id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [Route("")]
        public IHttpActionResult Post(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok();
        }

        //public async Task<IHttpActionResult> Post()
        //{
        //    // Check if the request contains multipart/form-data.
        //    if (!Request.Content.IsMimeMultipartContent())
        //    {
        //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //    }


        //    string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
        //    var provider = new MultipartFormDataStreamProvider(root);

        //    var filesReadToProvider = await Request.Content.ReadAsMultipartAsync(provider);


        //    RegisterUserViewModel user = new RegisterUserViewModel
        //    {
        //        Name = provider.FormData.Get("name"),
        //        Surname = provider.FormData.Get("surname"),
        //        Email = provider.FormData.Get("email"),
        //        Username = provider.FormData.Get("username"),
        //        Password = provider.FormData.Get("password")
        //    };

        //    foreach (var file in provider.FileData)
        //    {
        //        var fileName = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
        //        byte[] documentData;

        //        documentData = File.ReadAllBytes(file.LocalFileName);

        //        user.Image = documentData.Select(x => x).ToArray();
        //    }

        //    var mappedUser = Mapper.Map<RegisterUserViewModel, User>(user);
        //    _service.Save(mappedUser);

        //    return Ok();
        //}

        [Route("")]
        public IHttpActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }

        //public IHttpActionResult Put()
        //{
        //    return Ok();
        //}

        [Route("{id:guid}/message")]
        public IHttpActionResult GetMessages(Guid id)
        {
            return Ok();
        }
    }
}