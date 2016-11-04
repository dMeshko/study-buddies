using StudyBuddies.Domain.Models;
using StudyBuddies.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using StudyBuddies.Service.Infrastructure;
using StudyBuddies.Web.App_Start;
using StudyBuddies.Web.ViewModels;
using System.IO;
using System.Net.Http.Formatting;
using Newtonsoft.Json.Linq;

namespace StudyBuddies.Web.Controllers.Api
{
    public class UserController : ApiController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IHttpActionResult Get()
        {
            var users = _service.GetAllUsers();
    
            var mappedUser = Mapper.Map<IEnumerable<User>, IList<UserViewModel>>(users);
            return Ok(mappedUser);
        }

        public IHttpActionResult Get(Guid id)
        {
            var user = _service.GetUserById(id);

            var mappedUser = Mapper.Map<User, UserViewModel>(user);
            return Ok(mappedUser);
        }

        public async Task<IHttpActionResult> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }


            string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            var filesReadToProvider = await Request.Content.ReadAsMultipartAsync(provider);


            RegisterUserViewModel user = new RegisterUserViewModel
            {
                Name = provider.FormData.Get("name"),
                Surname = provider.FormData.Get("surname"),
                Email = provider.FormData.Get("email"),
                Username = provider.FormData.Get("username"),
                Password = provider.FormData.Get("password")
            };

            foreach (var file in provider.FileData)
            {
                var fileName = file.Headers.ContentDisposition.FileName.Replace("\"", string.Empty);
                byte[] documentData;

                documentData = File.ReadAllBytes(file.LocalFileName);

                user.Image = documentData.Select(x => x).ToArray();
            }

            var mappedUser = Mapper.Map<RegisterUserViewModel, User>(user);
            _service.Save(mappedUser);

            return Ok();
        }
    }
}
