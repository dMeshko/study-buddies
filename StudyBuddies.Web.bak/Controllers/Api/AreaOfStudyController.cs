using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyBuddies.Business.Services;

namespace StudyBuddies.Web.Controllers.Api
{
    [RoutePrefix("api/area")]
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
