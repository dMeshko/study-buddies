using System.IO;

namespace StudyBuddies.Domain.Users
{
    public class UserClaim : BaseEntity
    {
        private readonly string _claimType;
        private readonly string _claimValue;

        protected UserClaim() { }

        public UserClaim(string claimType, string claimValue)
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
