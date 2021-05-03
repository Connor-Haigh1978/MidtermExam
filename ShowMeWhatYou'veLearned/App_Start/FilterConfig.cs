using System.Web;
using System.Web.Mvc;

namespace ShowMeWhatYou_veLearned
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
