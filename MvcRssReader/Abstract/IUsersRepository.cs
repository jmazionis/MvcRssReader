using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvcRssReader.Models;
using System.Linq.Expressions;

namespace MvcRssReader.Abstract
{
    public interface IUsersRepository
    {
        void CreateUser(string username, string password);
        RssReaderUser GetUser(string username);
    }
}
