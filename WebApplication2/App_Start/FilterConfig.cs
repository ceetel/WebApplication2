using System.Web;
using System.Web.Mvc;

namespace WebApplication2
{
    // FilterConfig类用于配置全局过滤器
    public class FilterConfig
    {
        // RegisterGlobalFilters方法用于注册全局过滤器
        // 参数GlobalFilterCollection filters包含了所有全局过滤器的集合
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // 向全局过滤器集合中添加一个HandleErrorAttribute
            // HandleErrorAttribute用于处理发生在应用程序中的未处理异常
            filters.Add(new HandleErrorAttribute());
            // 全局鉴权，添加这层过滤器之后无需在每个方法中单独添加authorize
            filters.Add(new AuthorizeAttribute());
        }
    }
}
