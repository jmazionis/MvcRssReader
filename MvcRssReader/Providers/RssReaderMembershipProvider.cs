using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using MvcRssReader.Concrete;
using MvcRssReader.Models;
using MvcRssReader.ViewModels;
using MvcRssReader.Abstract;

namespace MvcRssReader.Providers
{
    public class RssReaderMembershipProvider : MembershipProvider
    {
        RssReaderDbContext db;
        PasswordProvider passwordProvider;
        IUsersRepository usersRepository;

        public RssReaderMembershipProvider(IUsersRepository repo):base()
        {
            usersRepository = repo;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(AccountViewModel user)
        {
            if (!(IsNullOrEmpty(user.Username) && IsNullOrEmpty(user.Password)))
            {
                usersRepository.CreateUser(user.Username, user.Password);
            }    
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        private bool IsNullOrEmpty(string str)
        {
            return str != null && str.Trim() != "";
        }

        public bool UsernameExists(string username)
        {
            RssReaderUser user;
            if (IsNullOrEmpty(username))
            {
                return false;
            }
            else
            {
                user = usersRepository.GetUser(username);
                return user == null; //no duplicates were found
            }

        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool ValidateUser(string username, string password)
        {
            RssReaderUser user;
            if (!(IsNullOrEmpty(username) && IsNullOrEmpty(password)))
            {
                return false;
            }
            else
            {
                passwordProvider = new PasswordProvider();
                using (db = new RssReaderDbContext())
                {
                    user = usersRepository.GetUser(username);
                    if (user == null) //user does not exist
                    {
                        return false;
                    }
                    string hashedPassword = passwordProvider.CreateHashedPassword(password, user.Salt);
                    return hashedPassword == user.Password;  
                }
            }
        }
    }
}