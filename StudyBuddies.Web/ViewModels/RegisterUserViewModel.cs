using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyBuddies.Web.ViewModels
{
    public class RegisterUserViewModel
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual byte[] Image { get; set; }
    }
}