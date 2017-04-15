using System.Web;
using System.Web.Mvc;

namespace ASP.NET_Web_Api_JSON_Sending_Receiving
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
