using System.Web;
using System.Web.Mvc;

namespace SSW.DataOnion.UserGroupDemo.WebUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
