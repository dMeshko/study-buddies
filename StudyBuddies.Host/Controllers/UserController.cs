using System;
using System.Web.Http;
using StudyBuddies.Business.Services;
using StudyBuddies.Business.ViewModels.Users;

namespace StudyBuddies.Host.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #region User

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

            var userId = _userService.RegisterUser(model);
            return Ok(userId);
        }

        [Route("{id:guid}")]
        public IHttpActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [Route("")]
        public IHttpActionResult Put(UpdateUserViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.UpdateUser(model);
            return Ok();
        }

        #endregion

        #region Conversation

        [Route("{id:guid}/conversation")]
        public IHttpActionResult GetConversations(Guid id)
        {
            var conversatoins = _userService.GetAllConversations(id);
            return Ok(conversatoins);
        }

        [Route("{id:guid}/conversation/{otherUserId:guid}")]
        public IHttpActionResult GetConversation(Guid id, Guid otherUserId)
        {
            var conversation = _userService.GetConversation(id, otherUserId);
            return Ok(conversation);
        }

        [Route("{userFromId:guid}/conversation/{userToId:guid}")]
        public IHttpActionResult PostMessage(MessageViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.SendMessage(model);
            return Ok();
        }

        [Route("{id:guid}/conversation/notification")]
        public IHttpActionResult GetAllMessageNotifications(Guid id)
        {
            var notifications = _userService.GetAllMessageNotifications(id);
            return Ok(notifications);
        }

        [Route("{id:guid}/conversation/notification/not")]
        public IHttpActionResult GetAllUnseenMessageNotifications(Guid id)
        {
            var notifications = _userService.GetAllUnseenMessageNotifications(id);
            return Ok(notifications);
        }

        #endregion

        #region Buddy

        [Route("{id:guid}/buddy")]
        public IHttpActionResult GetBuddies(Guid id)
        {
            var buddies = _userService.GetAllBuddies(id);
            return Ok(buddies);
        }

        [Route("{id:guid}/buddy/sent")]
        public IHttpActionResult GetSentPendingBuddyRequests(Guid id)
        {
            var buddies = _userService.GetAllSentPendingBuddyRequests(id);
            return Ok(buddies);
        }

        [Route("{id:guid}/buddy/received")]
        public IHttpActionResult GetReceivedPendingBuddyRequests(Guid id)
        {
            var buddies = _userService.GetAllReceivedPendingBuddyRequests(id);
            return Ok(buddies);
        }

        [Route("{userFromId:guid}/buddy/{userToId:guid}")]
        public IHttpActionResult PostBuddyRequest(BuddyRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.SendBuddyRequest(model);
            return Ok();
        }

        [Route("{userFromId:guid}/buddy/{userToId:guid}")]
        public IHttpActionResult PutBuddyRequest(BuddyRequestViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _userService.UpdateBuddyRequest(model);
            return Ok();
        }

        [Route("{id:guid}/buddy/notification")]
        public IHttpActionResult GetAllBuddyNotifications(Guid id)
        {
            var notifications = _userService.GetAllBuddyNotifications(id);
            return Ok(notifications);
        }

        [Route("{id:guid}/buddy/notification/not")]
        public IHttpActionResult GetAllUnseenBuddyNotifications(Guid id)
        {
            var notifications = _userService.GetAllUnseenBuddyNotifications(id);
            return Ok(notifications);
        }

        #endregion

        #region Subject

        [Route("{id:guid}/subject")]
        public IHttpActionResult GetEnrolledSubjects(Guid id)
        {
            var subjects = _userService.GetEnrolledSubjects(id);
            return Ok(subjects);
        }

        [Route("{id:guid}/subject/passed")]
        public IHttpActionResult GetPassedSubjects(Guid id)
        {
            var subjects = _userService.GetPassedSubjects(id);
            return Ok(subjects);
        }

        [Route("{id:guid}/subject/current")]
        public IHttpActionResult GetCurrentSubjects(Guid id)
        {
            var subjects = _userService.GetCurrentSubjects(id);
            return Ok(subjects);
        }

        #endregion

        #region Group

        [Route("{id:guid}/group")]
        public IHttpActionResult GetAllGroups(Guid id)
        {
            var groups = _userService.GetAllGroups(id);
            return Ok(groups);
        }

        [Route("{id:guid}/group/not")]
        public IHttpActionResult GetAllGroupsWhereNoRequestIsSent(Guid id)
        {
            var groups = _userService.GetAllGroupsWhereNoRequestIsSent(id);
            return Ok(groups);
        }

        [Route("{id:guid}/group/admin")]
        public IHttpActionResult GetAllManagedGroups(Guid id)
        {
            var groups = _userService.GetAllManagedGroups(id);
            return Ok(groups);
        }

        [Route("{id:guid}/group/member")]
        public IHttpActionResult GetAllMemberingGroups(Guid id)
        {
            var groups = _userService.GetAllMemberingGroups(id);
            return Ok(groups);
        }

        [Route("{id:guid}/group/notification")]
        public IHttpActionResult GetAllGroupNotifications(Guid id)
        {
            var notifications = _userService.GetAllGroupNotifications(id);
            return Ok(notifications);
        }

        [Route("{id:guid}/group/notification/not")]
        public IHttpActionResult GetAllUnseenGroupNotifications(Guid id)
        {
            var notifications = _userService.GetAllUnseenGroupNotifications(id);
            return Ok(notifications);
        }

        #endregion

        #region Post

        [Route("{id:guid}/post")]
        public IHttpActionResult GetLatestGroupsPosts(Guid id)
        {
            var groups = _userService.GetLatestGroupsPosts(id);
            return Ok(groups);
        }

        [Route("{id:guid}/post-mine")]
        public IHttpActionResult GetMineGroupPosts(Guid id)
        {
            var groups = _userService.GetMineGroupsPosts(id);
            return Ok(groups);
        }

        #endregion

        #region Login

        [Route("login")]
        public IHttpActionResult PostLogin(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _userService.Login(model);
            return Ok(user);
        }

        #endregion
    }
}