//using StudyBuddies.Data.Repository.Users;
//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration.Provider;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Web.Configuration;
//using System.Web.Security;
//using StudyBuddies.Data.Infrastructure;
//using StudyBuddies.Domain.Users;

//namespace StudyBuddies.IdentityServer.Providers
//{
//    public class StudyBuddiesMembershipProvider : MembershipProvider
//    {
//        private readonly IUnitOfWork _unitOfWork;
//        private readonly IUserRepository _userRepository;

//        private bool _enablePasswordRetrieval;
//        private bool _enablePasswordReset;
//        private bool _requiresQuestionAndAnswer;
//        private string _applicationName;
//        private int _maxInvalidPasswordAttempts;
//        private int _passwordAttemptWindow;
//        private bool _requiresUniqueEmail;
//        private MembershipPasswordFormat _passwordFormat;
//        private int _minRequiredPasswordLength;
//        private int _minRequiredNonAlphanumericCharacters;
//        private string _passwordStrengthRegularExpression;

//        #region Properties

//        public override bool EnablePasswordRetrieval
//        {
//            get { return _enablePasswordRetrieval; }
//        }

//        public override bool EnablePasswordReset
//        {
//            get { return _enablePasswordReset; }
//        }

//        public override bool RequiresQuestionAndAnswer
//        {
//            get { return _requiresQuestionAndAnswer; }
//        }

//        public override string ApplicationName
//        {
//            get { return _applicationName; }
//            set { _applicationName = value; }
//        }

//        public override int MaxInvalidPasswordAttempts
//        {
//            get { return _maxInvalidPasswordAttempts; }
//        }

//        public override int PasswordAttemptWindow
//        {
//            get { return _passwordAttemptWindow; }
//        }

//        public override bool RequiresUniqueEmail
//        {
//            get { return _requiresUniqueEmail; }
//        }

//        public override MembershipPasswordFormat PasswordFormat
//        {
//            get { return _passwordFormat; }
//        }

//        public override int MinRequiredPasswordLength
//        {
//            get { return _minRequiredPasswordLength; }
//        }

//        public override int MinRequiredNonAlphanumericCharacters
//        {
//            get { return _minRequiredNonAlphanumericCharacters; }
//        }

//        public override string PasswordStrengthRegularExpression
//        {
//            get { return _passwordStrengthRegularExpression; }
//        }

//        #endregion

//        public StudyBuddiesMembershipProvider(IUnitOfWork unitOfWork, IUserRepository userRepository)
//        {
//            _unitOfWork = unitOfWork;
//            _userRepository = userRepository;
//        }

//        public override void Initialize(string name, NameValueCollection config)
//        {
//            if (config == null)
//                throw new ArgumentNullException(nameof(config));

//            if (string.IsNullOrEmpty(name.Trim()))
//                name = "StudyBuddies";

//            if (string.IsNullOrEmpty(config["description"].Trim()))
//            {
//                config.Remove("description");
//                config.Add("description", "StudyBuddies Membership Provider");
//            }
//            base.Initialize(name, config);

//            //todo: take these from a config file.
//            _applicationName = "StudyBuddies";
//            _maxInvalidPasswordAttempts = 3;
//            _passwordAttemptWindow = 10;
//            _minRequiredPasswordLength = 6;
//            _minRequiredNonAlphanumericCharacters = 1;
//            _passwordStrengthRegularExpression = "";
//            _enablePasswordReset = true;
//            _enablePasswordRetrieval = true;
//            _requiresQuestionAndAnswer = false;
//            _requiresUniqueEmail = true;
//            string passwordFormat = config["passwordFormat"];
//            if (string.IsNullOrEmpty(passwordFormat.Trim()))
//                passwordFormat = "Hashed";

//            switch (passwordFormat)
//            {
//                case "Hashed":
//                    _passwordFormat = MembershipPasswordFormat.Hashed;
//                    break;
//                case "Encrypted":
//                    _passwordFormat = MembershipPasswordFormat.Encrypted;
//                    break;
//                case "Clear":
//                    _passwordFormat = MembershipPasswordFormat.Clear;
//                    break;
//                default:
//                    throw new ProviderException("Password format not supported.");
//            }

//            // open the session
//            _unitOfWork.BeginTransaction();
//        }

//        ~StudyBuddiesMembershipProvider()
//        {
//            try
//            {
//                _unitOfWork.Commit();
//            }
//            catch (Exception)
//            {
//                _unitOfWork.Rollback();
//                throw;
//            }
//        }

//        #region Private Methods

//        private string _GetConfigValue(string configValue, string defaultValue)
//        {
//            if (string.IsNullOrEmpty(configValue))
//                return defaultValue;

//            return configValue;
//        }

//        private static IEnumerable<char> _GenerateRandomCharacters(int count)
//        {
//            var random = new Random();
//            for (int i = 0; i < count; i++)
//            {
//                yield return (char)random.Next(128);
//            }
//        }

//        private static string _Salt()
//        {
//            return new string(_GenerateRandomCharacters(5).ToArray());
//        }

//        //   Converts a hexadecimal string to a byte array. Used to convert encryption key values from the configuration.    
//        private byte[] _HexToByte(string hexString)
//        {
//            byte[] returnBytes = new byte[hexString.Length / 2];
//            for (int i = 0; i < returnBytes.Length; i++)
//                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
//            return returnBytes;
//        }

//        // EncodePassword:Encrypts, Hashes, or leaves the password clear based on the PasswordFormat.
//        private string _EncodePassword(string password)
//        {
//            string encodedPassword = password;

//            switch (PasswordFormat)
//            {
//                case MembershipPasswordFormat.Clear:
//                    break;
//                case MembershipPasswordFormat.Encrypted:
//                    encodedPassword =
//                      Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
//                    break;
//                case MembershipPasswordFormat.Hashed:
//                    HMACSHA1 hash = new HMACSHA1();
//                    hash.Key = _HexToByte("");
//                    encodedPassword =
//                      Convert.ToBase64String(hash.ComputeHash(Encoding.Unicode.GetBytes(password)));
//                    break;
//                default:
//                    throw new ProviderException("Unsupported password format.");
//            }
//            return encodedPassword;
//        }

//        // DecodePassword :Decrypts or leaves the password clear based on the PasswordFormat.
//        private string _DecodePassword(string encodedPassword)
//        {
//            string password = encodedPassword;

//            switch (PasswordFormat)
//            {
//                case MembershipPasswordFormat.Clear:
//                    break;
//                case MembershipPasswordFormat.Encrypted:
//                    password =
//                      Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(password)));
//                    break;
//                case MembershipPasswordFormat.Hashed:
//                    throw new ProviderException("Cannot decode a hashed password.");
//                default:
//                    throw new ProviderException("Unsupported password format.");
//            }

//            return password;
//        }

//        #endregion

//        #region Public Methods

//        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer,
//            bool isApproved, object providerUserKey, out MembershipCreateStatus status)
//        {
//            ValidatePasswordEventArgs args = new ValidatePasswordEventArgs(username, password, true);

//            OnValidatingPassword(args);
//            if (args.Cancel)
//            {
//                status = MembershipCreateStatus.InvalidPassword;
//                return null;
//            }

//            if (RequiresUniqueEmail && !string.IsNullOrEmpty(GetUserNameByEmail(email).Trim()))
//            {
//                status = MembershipCreateStatus.DuplicateEmail;
//                return null;
//            }

//            MembershipUser user = GetUser(username, false);
//            if (user == null)
//            {
//                string salt = _Salt();

//                User dboUser = new User(string.Empty, string.Empty, email, _EncodePassword(password + salt));
//                dboUser.SetUsername(username);

//            }
//        }

//        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
//            string newPasswordAnswer)
//        {
//            throw new NotImplementedException();
//        }

//        public override string GetPassword(string username, string answer)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool ChangePassword(string username, string oldPassword, string newPassword)
//        {
//            throw new NotImplementedException();
//        }

//        public override string ResetPassword(string username, string answer)
//        {
//            throw new NotImplementedException();
//        }

//        public override void UpdateUser(MembershipUser user)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool ValidateUser(string username, string password)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool UnlockUser(string userName)
//        {
//            throw new NotImplementedException();
//        }

//        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
//        {
//            throw new NotImplementedException();
//        }

//        public override MembershipUser GetUser(string username, bool userIsOnline)
//        {
//            throw new NotImplementedException();
//        }

//        public override string GetUserNameByEmail(string email)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool DeleteUser(string username, bool deleteAllRelatedData)
//        {
//            throw new NotImplementedException();
//        }

//        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
//        {
//            throw new NotImplementedException();
//        }

//        public override int GetNumberOfUsersOnline()
//        {
//            throw new NotImplementedException();
//        }

//        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
//        {
//            throw new NotImplementedException();
//        }

//        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
//        {
//            throw new NotImplementedException();
//        }

//        #endregion
//    }
//}
