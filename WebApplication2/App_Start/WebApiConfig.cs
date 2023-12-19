using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication2.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            // 配置 Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 配置其他 Web API 设置，例如消息处理管道、格式化器等
            // config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            // 配置跨域访问
            // config.EnableCors(new EnableCorsAttribute("*", "*", "*"));

            // 配置其他设置...

            // 如果需要，你还可以注册过滤器、消息处理程序等
            // config.Filters.Add(new MyExceptionFilter());
            // config.MessageHandlers.Add(new MyMessageHandler());
        }
    }
}