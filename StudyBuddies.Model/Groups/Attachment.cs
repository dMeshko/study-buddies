using System.IO;

namespace StudyBuddies.Domain.Groups
{
    public class Attachment : BaseEntity
    {
        private string _name;
        private string _description;
        private byte[] _file;
        private Post _post;

        protected Attachment() { }

        public Attachment(Post post, string name, string description, byte[] file)
        {
            if (post == null)
                throw new InvalidDataException(nameof(post));

            if (name == null || name.Trim().Length == 0)
                throw new InvalidDataException(nameof(name));

            if (file == null)
                throw new InvalidDataException(nameof(file));

            _post = post;
            _name = name;
            _description = description;
            _file = file;
        }

        #region Properties

        public virtual Post Post => _post;
        public virtual string Name => _name;
        public virtual string Description => _description;
        public virtual byte[] File => _file;

        #endregion
    }
}
