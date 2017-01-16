using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyBuddies.Service.Services;
using StudyBuddies.Service.ViewModels.Groups;

namespace StudyBuddies.Web.Controllers.Api
{
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public IHttpActionResult Get()
        {
            var groups = _groupService.GetAllGroups();
            return Ok(groups);
        }

        public IHttpActionResult Get(Guid id)
        {
            var group = _groupService.GetGroupById(id);
            return Ok(group);
        }

        public IHttpActionResult Post(CreateGroupViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _groupService.CreateGroup(model);
            return Ok();
        }

        public IHttpActionResult Put()
        {
            return Ok();
        }

        public IHttpActionResult Delete(Guid id)
        {
            return Ok();
        }
    }
}
