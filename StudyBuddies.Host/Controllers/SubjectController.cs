using System;
using System.Web.Http;
using StudyBuddies.Business.Services;
using StudyBuddies.Business.ViewModels.Subjects;

namespace StudyBuddies.Host.Controllers
{
    //[RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        public IHttpActionResult Get()
        {
            var subjects = _subjectService.GetAllSubjects();
            return Ok(subjects);
        }

        public IHttpActionResult Get(Guid id)
        {
            return Ok();
        }

        public IHttpActionResult Post(SubjectViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _subjectService.CreateSubject(model);
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
