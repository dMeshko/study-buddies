using System.IO;

namespace StudyBuddies.Domain.Subjects
{
    public class Subject : BaseEntity
    {
        private string _name;
        private AreaOfStudy _areaOfStudy;

        protected Subject() { }

        public Subject(string name, AreaOfStudy areaOfStudy)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            if (areaOfStudy == null)
                throw new InvalidDataException(nameof(areaOfStudy));

            _name = name;
            _areaOfStudy = areaOfStudy;
        }

        #region Properties

        public virtual string Name => _name;
        public virtual AreaOfStudy AreaOfStudy => _areaOfStudy;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        public virtual void SetAreaOfStudy(AreaOfStudy areaOfStudy)
        {
            if (areaOfStudy == null)
                throw new InvalidDataException(nameof(areaOfStudy));

            _areaOfStudy = areaOfStudy;
        }

        #endregion
    }
}
