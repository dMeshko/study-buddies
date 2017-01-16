using System;
using System.IO;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Institutions
{
    public class EnrolledInstitution : BaseEntity
    {
        private User _user;
        private Institution _institution;
        private InstitutionStatus _status;
        private DateTime? _graduationDate;

        protected EnrolledInstitution() { }

        public EnrolledInstitution(User user, Institution institution, InstitutionStatus institutionStatus = InstitutionStatus.Attending, DateTime? graduationDate = null)
        {
            if (user == null)
                throw new InvalidDataException(nameof(user));

            if (institution == null)
                throw new InvalidDataException(nameof(institution));

            if (graduationDate != null && institutionStatus == InstitutionStatus.Attending)
                throw new InvalidDataException(nameof(institutionStatus));

            _user = user;
            _institution = institution;
            _status = institutionStatus;
            _graduationDate = graduationDate;
        }

        #region Properties

        public virtual User User => _user;
        public virtual Institution Institution => _institution;
        public virtual InstitutionStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public virtual DateTime? GraduationDate => _graduationDate;

        #endregion

        #region Public Methods

        public virtual void SetGraduationDate(DateTime? graduationDate)
        {
            if (graduationDate == null)
                throw new InvalidDataException(nameof(graduationDate));

            if (_status == InstitutionStatus.Attending)
                throw new InvalidDataException(nameof(_status));

            _graduationDate = graduationDate;
        }

        #endregion
    }
}
