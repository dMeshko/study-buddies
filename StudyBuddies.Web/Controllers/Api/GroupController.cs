using System;
using System.Web.Http;
using StudyBuddies.Business.Services;
using StudyBuddies.Business.ViewModels.Groups;

namespace StudyBuddies.Web.Controllers.Api
{
    [RoutePrefix("api/group")]
    public class GroupController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #region Group

        [Route("")]
        public IHttpActionResult Get()
        {
            var groups = _groupService.GetAllGroups();
            return Ok(groups);
        }

        [Route("{id:guid}")]
        public IHttpActionResult Get(Guid id)
        {
            var group = _groupService.GetGroupById(id);
            return Ok(group);
        }

        [Route("")]
        public IHttpActionResult Post(CreateGroupViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _groupService.CreateGroup(model);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put(UpdateGroupViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _groupService.UpdateGroup(model);
            return Ok();
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            _groupService.DeleteGroup(id);
            return Ok();
        }

        #endregion

        #region Post

        [Route("{id:guid}/post")]
        public IHttpActionResult GetPosts(Guid id)
        {
            var posts = _groupService.GetGroupPosts(id);
            return Ok(posts);
        }

        #endregion

        #region Member

        [Route("{id:guid}/member/")]
        public IHttpActionResult GetGroupMembers(Guid id)
        {
            var members = _groupService.GetGroupMembers(id);
            return Ok(members);
        }

        [Route("{id:guid}/member/pending")]
        public IHttpActionResult GetPendingGroupMembers(Guid id)
        {
            var members = _groupService.GetPendingGroupMembers(id);
            return Ok(members);
        }

        [Route("{id:guid}/member/accepted")]
        public IHttpActionResult GetAcceptedGroupMembers(Guid id)
        {
            var members = _groupService.GetAcceptedGroupMembers(id);
            return Ok(members);
        }

        [Route("{id:guid}/member/{userId:guid}")]
        public IHttpActionResult PutGroupMember(GroupRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _groupService.UpdateGroupMember(model);
            return Ok();
        }

        #endregion
    }
}
