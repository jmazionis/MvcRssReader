using System.Web.Mvc;
using System.Web.Routing;
using MvcRssReader.Providers;
using MvcRssReader.Concrete;

namespace MvcRssReader.Controllers
{
    public class BaseController : Controller
    {
        protected RssReaderMembershipProvider MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null)
            {
                MembershipService = new RssReaderMembershipProvider(new UsersRepository());
            }
            base.Initialize(requestContext);
        }
    }
}
