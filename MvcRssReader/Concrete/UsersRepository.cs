using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcRssReader.Abstract;
using MvcRssReader.Models;
using MvcRssReader.Providers;

namespace MvcRssReader.Concrete
{
    public class UsersRepository : IUsersRepository
    {
        private RssReaderDbContext db;

        public void CreateUser(string username, string password)
        {
            var passwordProvider = new PasswordProvider();
            string salt = passwordProvider.CreateSalt();
            string hashedPassword = passwordProvider.CreateHashedPassword(username, salt);

            using (db = new RssReaderDbContext())
            {
                db.RssReaderUsers.Add(new RssReaderUser(username, hashedPassword, salt));
                db.SaveChanges();
            }
        }

        public RssReaderUser GetUser(string username)
        {
            RssReaderUser user;
            using (db = new RssReaderDbContext())
            {
                user = db.RssReaderUsers.FirstOrDefault(u => u.Username == username);
                return user;
            }
        }
    }
}