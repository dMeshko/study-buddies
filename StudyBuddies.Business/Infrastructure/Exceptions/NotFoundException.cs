using System;

namespace StudyBuddies.Business.Infrastructure.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
