using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyBuddies.Web.ViewModels
{
    public class ReceivedMessageViewModel
    {
        public virtual UserViewModel User { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Date { get; set; }
    }
}