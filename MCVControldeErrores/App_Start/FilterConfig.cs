using System.Web;
using System.Web.Mvc;
using MCVControldeErrores.Filters;

namespace MCVControldeErrores
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionControlSalariosAttribute());
        }
    }
}
