using System.IO;

namespace StudyBuddies.Domain.Subjects
{
    public class AreaOfStudy : BaseEntity
    {
        private string _name;

        protected AreaOfStudy() { }

        public AreaOfStudy(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        #region Properties

        public virtual string Name => _name;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        #endregion
    }
}
