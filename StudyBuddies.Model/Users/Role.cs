using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddies.Domain.Users
{
    public class Role : BaseEntity
    {
        private string _name;
        private IList<User> _users;

        protected Role() { }

        public Role(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new InvalidDataException(nameof(name));

            _name = name;
            _users = new List<User>();
        }

        #region Properties

        public virtual string Name => _name;
        public virtual IList<User> Users => _users;

        #endregion

        #region Public Methods

        public virtual void SetName(string name)
        {
            if (string.IsNullOrEmpty(name.Trim()))
                throw new InvalidDataException(nameof(name));

            _name = name;
        }

        #endregion
    }
}
