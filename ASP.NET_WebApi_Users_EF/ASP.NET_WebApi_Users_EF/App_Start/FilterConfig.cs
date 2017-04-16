using System.Web;
using System.Web.Mvc;

namespace ASP.NET_WebApi_Users_EF
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
