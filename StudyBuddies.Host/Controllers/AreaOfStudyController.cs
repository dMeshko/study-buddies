using System.Web.Http;
using StudyBuddies.Business.Services;

namespace StudyBuddies.Host.Controllers
{
    [RoutePrefix("area")]
    public class AreaOfStudyController : ApiController
    {
        private readonly IAreaOfStudyService _areaOfStudyService;

        public AreaOfStudyController(IAreaOfStudyService areaOfStudyService)
        {
            _areaOfStudyService = areaOfStudyService;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var areas = _areaOfStudyService.GetAllAreas();
            return Ok(areas);
        }
    }
}
