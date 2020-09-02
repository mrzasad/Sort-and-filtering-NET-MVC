using System.Web;
using System.Web.Mvc;

namespace trustedi10_mvc_Assessment_asad
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
