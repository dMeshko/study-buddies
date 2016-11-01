using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddies.Service.Infrastructure.Exceptions
{
    public class BusinessLayerException : Exception
    {
        public BusinessLayerException(string message) : base(message)
        {
        }
    }
}
