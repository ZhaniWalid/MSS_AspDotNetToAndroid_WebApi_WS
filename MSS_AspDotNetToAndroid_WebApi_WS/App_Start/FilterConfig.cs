using System.Web;
using System.Web.Mvc;

namespace MSS_AspDotNetToAndroid_WebApi_WS
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
