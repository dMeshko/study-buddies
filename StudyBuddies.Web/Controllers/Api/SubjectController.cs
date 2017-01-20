using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudyBuddies.Business.Services;
using StudyBuddies.Business.ViewModels.Subjects;

namespace StudyBuddies.Web.Controllers.Api
{
    public class SubjectController : ApiController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Get(Guid id)
        {
            return Ok();
        }

        public IHttpActionResult Post(SubjectViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _subjectService.CreateGroup(model);
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
