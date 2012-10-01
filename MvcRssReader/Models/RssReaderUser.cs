using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MvcRssReader.Models
{
    public class RssReaderUser
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public RssReaderUser()
        {
        }

        public RssReaderUser(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public RssReaderUser(string username, string password, string salt) 
            : this(username, password)
        {
            Salt = salt;
        }
    }
}