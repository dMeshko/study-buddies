using StudyBuddies.Domain.Models;
using StudyBuddies.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using StudyBuddies.Service.Infrastructure;
using StudyBuddies.Web.ViewModels;

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

        public IHttpActionResult GetFriends(Guid id)
        {
            var user = _service.GetUserById(id);
            var friends = _service.GetFriends(user);

            var mappedUser = Mapper.Map<IEnumerable<User>, IList<UserViewModel>>(friends);
            return Ok(mappedUser);
        }
    }
}
