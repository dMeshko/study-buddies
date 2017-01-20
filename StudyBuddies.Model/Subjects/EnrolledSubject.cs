using System.IO;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Subjects
{
    public class EnrolledSubject : BaseEntity
    {
        private User _user;
        private Subject _subject;
        private SubjectStatus _status;
        private int? _grade;

        protected EnrolledSubject() { }

        public EnrolledSubject(User user, Subject subject, SubjectStatus subjectStatus = SubjectStatus.Current, int? grade = null)
        {
            if (user == null)
                throw new InvalidDataException(nameof(user));

            if (subject == null)
                throw new InvalidDataException(nameof(subject));

            if (grade != null && subjectStatus == SubjectStatus.Current)
                throw new InvalidDataException(nameof(subjectStatus));

            if (grade == null || grade < 6 || grade > 10)
                throw new InvalidDataException(nameof(grade));

            _user = user;
            _subject = subject;
            _status = subjectStatus;
            _grade = grade;
        }

        #region Properties

        public virtual User User => _user;
        public virtual Subject Subject => _subject;
        public virtual SubjectStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public virtual int? Grade => _grade;

        #endregion

        #region Public Methods

        public virtual void SetGrade(int? grade)
        {
            if (grade == null || grade < 6 || grade > 10)
                throw new InvalidDataException(nameof(grade));

            if (_status != SubjectStatus.Passed)
                throw new InvalidDataException(nameof(_status));

            _grade = grade;
        }

        #endregion
    }
}
