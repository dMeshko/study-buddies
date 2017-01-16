using System.Collections.Generic;
using System.IO;

namespace StudyBuddies.Domain.Institutions
{
    public class University : BaseEntity
    {
        private string _name;
        private Location _location;
        private IList<Faculty> _faculties;

        protected University() { }

        public University(string name, Location location)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            if (location == null)
                throw new InvalidDataException(nameof(location));

            _name = name;
            _location = location;
            _faculties = new List<Faculty>();
        }

        #region Properties

        public virtual string Name => _name;

        public virtual Location Location// => _location;
        {
            get { return _location; }
            set { _location = value; }
        }
        public virtual IList<Faculty> Faculties => _faculties;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        public virtual void SetLocation(Location location)
        {
            if (location == null)
                throw new InvalidDataException(nameof(location));

            _location = location;
        }

        public virtual void AddFaculty(Faculty faculty)
        {
            if (faculty == null)
                throw new InvalidDataException(nameof(faculty));

            _faculties.Add(faculty);
        }

        public virtual void RemoveFaculty(Faculty faculty)
        {
            if (faculty == null)
                throw new InvalidDataException(nameof(faculty));

            _faculties.Remove(faculty);
        }

        #endregion
    }
}
