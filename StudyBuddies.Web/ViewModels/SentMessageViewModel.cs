using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Web.ViewModels
{
    public class SentMessageViewModel
    {
        public virtual UserViewModel User { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Date { get; set; }
    }
}