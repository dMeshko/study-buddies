using System.IO;

namespace StudyBuddies.Domain.Users
{
    public class Claim : BaseEntity
    {
        private string _claimType;
        private string _claimValue;

        protected Claim() { }

        public Claim(string claimType, string claimValue)
        {
            if (string.IsNullOrEmpty(claimType))
                throw new InvalidDataException(nameof(claimType));

            if (string.IsNullOrEmpty(claimValue))
                throw new InvalidDataException(nameof(claimValue));

            _claimType = claimType;
            _claimValue = claimValue;
        }

        #region Properties

        public virtual string ClaimType => _claimType;

        public virtual string ClaimValue => _claimValue;

        #endregion
    }
}
