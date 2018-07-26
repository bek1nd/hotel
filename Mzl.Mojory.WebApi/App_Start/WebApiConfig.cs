using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Microsoft.Owin.Security.OAuth;
using Mzl.Mojory.WebApi.Config;
using Newtonsoft.Json.Serialization;
using Mzl.Common.Ioc;

namespace Mzl.Mojory.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
          // config.SuppressDefaultHostAuthentication();
          // config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
          // GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // Web API 路由
            config.MapHttpAttributeRoutes();
            //带action的路由
            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "MojoryApi/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //默认路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "MojoryApi/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
           
            /***
             * 请在这里注册WebApi的过滤器
             * ****/
            config.Filters.Add(new TokenAuthentication());
            config.Filters.Add(new MojoryActionFilterAttribute());
            config.Filters.Add(new MojoryExceptionFilterAttribute());

            /***
           * 替换了ApiController创建类，使用了自定义的创建类结合Unity容器注入
           * ****/
            //config.Services.Replace(typeof(IHttpControllerSelector), new UnityHttpControllerSelector(config));
            config.Services.Replace(typeof(IHttpControllerActivator), new UnityHttpControllerActivator());

            //新增消息管道节点 只要类继承DelegatingHandler就行
            //config.MessageHandlers.Add(new HttpMethodChangeHandler());
        }
    }
}
