using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Web.ViewModels
{
    public class UserViewModel
    {
        public virtual Guid Id { get; set; }
        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
    }
}