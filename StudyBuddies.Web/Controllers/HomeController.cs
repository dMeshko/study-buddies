using StudyBuddies.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IInstitutionService _institutionService;
        private readonly UnitOfWork _unitOfWork;

        public HomeController(IUserService userService, IInstitutionService institutionService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _institutionService = institutionService;
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.IsChildAction)
                _unitOfWork.BeginTransaction();
        }

        protected override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (!filterContext.IsChildAction)
                _unitOfWork.Commit();
        }

        // GET: Home
        public ActionResult Index()
        {
            //Seed();
            //_userService.Save(new User { Name = "Darko", Surname = "Meshkovski", Email = "darrko_messkovski@hotmail.com", Username = "dMeshko", Password = "password" });
            var user1 = _userService.GetUserByUsername("dMeshko");
            //var user2 = _userService.GetUserByUsername("markos");

            ViewBag.Name = user1.Name;
            return View();
        }

        private void Seed()
        {
            // adding users
            List<User> Users = new List<User>
            {
                new User { Name = "Darko", Surname = "Meshkovski", Email = "darrko_messkovski@hotmail.com", Username = "dMeshko", Password = "password" },
                new User { Name = "Marko", Surname = "Stefanovski", Email = "markos@gmail.com", Username = "markos", Password = "secret" },
                new User { Name = "Deni", Surname = "Belevski", Email = "deni_belevski@yahoo.com", Username = "denib", Password = "nerd" },
                new User { Name = "Martin", Surname = "Mrmachovski", Email = "mr.mach@hotmail.com", Username = "fish", Password = "ferd" },
                new User { Name = "Angel", Surname = "Miladinov", Email = "trash@hotmail.com", Username = "trashy", Password = "trash123" }
            };

            foreach (User u in Users)
                _userService.Save(u);

            // adding friendships
            _userService.SendFriendRequest(Users[0], Users[1]);
            _userService.SendFriendRequest(Users[0], Users[2]);
            _userService.SendFriendRequest(Users[0], Users[3]);
            _userService.SendFriendRequest(Users[0], Users[4]);
            _userService.SendFriendRequest(Users[1], Users[2]);
            _userService.SendFriendRequest(Users[1], Users[4]);
            _userService.SendFriendRequest(Users[4], Users[3]);

            _userService.AcceptFriend(Users[0], Users[3]);
            _userService.AcceptFriend(Users[1], Users[2]);
            _userService.AcceptFriend(Users[4], Users[3]);
            _userService.AcceptFriend(Users[0], Users[1]);

            // adding messages
            _userService.SendMessage(Users[0], Users[1], "Heyy..how's it going? :)");
            _userService.SendMessage(Users[2], Users[1], "Heyy..buddy!!");
            _userService.SendMessage(Users[2], Users[1], "wassssuuppp?!");
            _userService.SendMessage(Users[1], Users[0], "welp..good..how about you?");
            _userService.SendMessage(Users[0], Users[1], "Great...lifes good!");
            _userService.SendMessage(Users[0], Users[1], ":D");
            _userService.SendMessage(Users[0], Users[3], "hello!");

            // adding subjects
            List<Subject> Subjects = new List<Subject>
            {
                new Subject { Name = "Introduction in Informatics" },
                new Subject { Name = "Object-Oriented Programming" },
                new Subject { Name = "Structured Programming" },
                new Subject { Name = "Introduction to Web Design" },
                new Subject { Name = "Web Based Systems" },
                new Subject { Name = "Philosophy" },
                new Subject { Name = "History" },
                new Subject { Name = "Social Engineering" },
                new Subject { Name = "Theology" },
            };

            foreach (Subject s in Subjects)
                _institutionService.CreateSubject(s);

            // enrollment of subjects
            _userService.EnrollSubject(Users[0], Subjects[2]);
            _userService.EnrollSubject(Users[1], Subjects[2]);
            _userService.EnrollSubject(Users[2], Subjects[0]);
            _userService.EnrollSubject(Users[0], Subjects[1]);
            _userService.EnrollSubject(Users[3], Subjects[4]);

            _userService.PassSubject(Users[0], Subjects[2], 10);
            _userService.PassSubject(Users[2], Subjects[0], 6);
            _userService.PassSubject(Users[0], Subjects[1], 8);

            // adding groups
            _userService.CreateGroup(Users[0], Subjects[1], "uchenje na OOP", 5);
            _userService.CreateGroup(Users[2], Subjects[0], "VVI..gluposti! :D", 3);

            Group grp = _userService.GetGroupsByName("OOP").First();

            _userService.JoinGroup(grp, Users[1]);
            _userService.JoinGroup(grp, Users[2]);
            _userService.JoinGroup(grp, Users[4]);

            _userService.AcceptGroupMember(grp, Users[2]);
            _userService.AcceptGroupMember(grp, Users[1]);

            _userService.RateGroupMember(Users[2], Users[1], grp, 5);

            // adding new University
            List<University> Universities = new List<University>
            {
                new University
                {
                    Name = "UKIM",
                    Location = new Location { Address = "the UKIM address", City = "Skopje", Country = "Macedonia" }
                },
                 new University
                {
                    Name = "UKLO",
                    Location = new Location { Address = "the UKLO address", City = "Bitola", Country = "Macedonia" }
                }
            };

            foreach (var university in Universities)
            {
                _institutionService.CreateUniversity(university);
            }

            AreaOfStudy areaOfStudy = new AreaOfStudy { Name = "IT" };

            // adding new faculty
            _institutionService.CreateInstitution(new Faculty
            {
                Name = "FINKI",
                Subjects = new List<Subject> { Subjects[0], Subjects[1], Subjects[2] },
                Location = new Location { Address = "the finki address", City = "Skopje", Country = "Macedonia" },
                University = Universities[0],
                AreasOfStudy = new List<AreaOfStudy> { areaOfStudy }
            });

            _institutionService.CreateInstitution(new Faculty
            {
                Name = "FIKT",
                Subjects = new List<Subject> { Subjects[0], Subjects[1], Subjects[2] },
                Location = new Location { Address = "the fikt address", City = "Bitola", Country = "Macedonia" },
                University = Universities[1],
                AreasOfStudy = new List<AreaOfStudy> { areaOfStudy }
            });

            // adding new academy
            _institutionService.CreateInstitution(new Academy()
            {
                Name = "SEAVUS",
                Subjects = new List<Subject> { Subjects[0], Subjects[4], Subjects[2], Subjects[5] },
                Locations = new List<Location>
                {
                    new Location
                    {
                        Address = "the seavusSK address",
                        City = "Skopje",
                        Country = "Macedonia"
                    },
                    new Location
                    {
                        Address = "the seavusBT address",
                        City = "Bitola",
                        Country = "Macedonia"
                    }
                },
                AreasOfStudy = new List<AreaOfStudy> { areaOfStudy }
            });

            // enroll user in some institution
            _userService.EnrollStudent(Users[0], _institutionService.Get(x => x.Name == "FINKI"), DateTime.Now.AddYears(-3));
            _userService.EnrollGraduatedStudent(Users[0], _institutionService.Get(x => x.Name == "FINKI"), DateTime.Now.AddYears(-3), DateTime.Now);
        }
    }
}