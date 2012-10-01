using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcRssReader.Concrete
{
    public class AuthorizedOnlyAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            string login = (string) httpContext.Session["Username"];
            if (login == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 
    }
}