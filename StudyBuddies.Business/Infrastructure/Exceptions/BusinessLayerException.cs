using System;

namespace StudyBuddies.Business.Infrastructure.Exceptions
{
    public class BusinessLayerException : Exception
    {
        public BusinessLayerException(string message) : base(message)
        {
        }
    }
}
