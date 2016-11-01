using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddies.Domain.Models
{
    public class UserGroup : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Group Group { get; set; }
        public virtual bool Status { get; set; }
    }
}
