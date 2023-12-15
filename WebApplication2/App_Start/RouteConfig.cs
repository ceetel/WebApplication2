using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2
{
    // RouteConfig 类用于配置应用程序的路由规则
    public class RouteConfig
    {
        // RegisterRoutes 方法用于注册应用程序的路由
        // 参数 RouteCollection routes 包含了所有路由的集合
        public static void RegisterRoutes(RouteCollection routes)
        {
            // 忽略特定的路由，这里忽略以 ".axd" 结尾的请求路径
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // // 启用MVC注解路由
            //routes.MapMvcAttributeRoutes();
            //// 自定义路由规则
            //// 可以被控制器action变量所取代,但是需要进行较为复杂的逻辑判断
            //routes.MapRoute(
            //    name: "BookReleaseDate", // 路由的名称
            //    url: "Book/released/{year}/{month}", // URL 的模式
            //    new { controller = "Book", action = "ByReleaseData"}, // 默认的控制器、动作和参数值
            //    // 限定变量范围
            //    new { year = @"\d{4}", month = @"\d{2}"}
            //);

            // 定义一个名为 "Default" 的路由规则
            routes.MapRoute(
                name: "Default", // 路由的名称
                url: "{controller}/{action}/{id}", // URL 的模式
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 默认的控制器、动作和参数值
            );
        }
    }
}
