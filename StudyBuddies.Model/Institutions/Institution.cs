using System.Collections.Generic;
using System.IO;

namespace StudyBuddies.Domain.Institutions
{
    public abstract class Institution : BaseEntity
    {
        private string _name;
        private IList<Location> _locations;
        private IList<EnrolledInstitution> _enrolledStudents;
   
        protected Institution() { }

        protected Institution(string name)
        {
            if (name == null)
                throw new InvalidDataException(nameof(name));

            _name = name;
            _locations = new List<Location>();
            _enrolledStudents = new List<EnrolledInstitution>();
        }

        #region Properties

        public virtual string Name => _name;
        public virtual IList<Location> Locations => _locations;
        public virtual IList<EnrolledInstitution> EnrolledStudents => _enrolledStudents;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        public virtual void AddLocation(Location location)
        {
            if (location == null)
                throw new InvalidDataException(nameof(location));

            _locations.Add(location);
        }

        public virtual void RemoveLocation(Location location)
        {
            if (location == null)
                throw new InvalidDataException(nameof(location));

            _locations.Remove(location);
        }

        #endregion
    }
}
