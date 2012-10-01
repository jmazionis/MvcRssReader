using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Web.Security;

namespace MvcRssReader.Providers
{
    public class PasswordProvider
    {
        public string CreateSalt()
        {
            RNGCryptoServiceProvider cryptoService = new RNGCryptoServiceProvider();
            byte[] salt = new byte[32];
            cryptoService.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        public string CreateHashedPassword(string password, string salt)
        {
            string saltedPassword = String.Concat(salt, password);
            return FormsAuthentication.HashPasswordForStoringInConfigFile(saltedPassword, "sha1");
        }
    }
}