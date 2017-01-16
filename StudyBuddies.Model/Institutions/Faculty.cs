using System.IO;

namespace StudyBuddies.Domain.Institutions
{
    public class Faculty : Institution
    {
        private University _university;

        protected Faculty() : base(string.Empty) { }

        public Faculty(string name, University university) : base(name)
        {
            if (university == null)
                throw new InvalidDataException(nameof(university));

            _university = university;
        }

        #region Properties

        public virtual University University => _university;

        #endregion

        #region Public Methods

        public virtual void SetUniversity(University university)
        {
            if (university == null)
                throw new InvalidDataException(nameof(university));

            _university = university;
        }

        #endregion
    }
}
