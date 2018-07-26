using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Mzl.Common.ConfigHelper;

namespace Mzl.Common.Ioc
{
    /// <summary>
    ///自定义创建WebApi控制器
    /// </summary>
    public class UnityHttpControllerDescriptor : HttpControllerDescriptor
    {
        private static readonly List<string> BlackList = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IOCBlackList).Split(',').ToList();
        public UnityHttpControllerDescriptor(HttpConfiguration configuration, string controllerName, Type controllerType)
            : base(configuration, controllerName, controllerType)
        {

        }

        public override IHttpController CreateController(HttpRequestMessage request)
        {
            if (request == null)
            {
                throw new Exception("request");
            }
               
            //获取没有使用IOC注入的控制器（不在webconfig配置也可以）
            if (!BlackList.Contains(base.ControllerName))
            {
                //结合Unity容器创建，注意Unity容器名称规定为"{控制器名称}+api"形式
                IUnityContainer unityContainer = new IocHelper(base.ControllerName+"Api").GetUnityContainer();
                if (unityContainer != null)
                {
                    IHttpController controller = (IHttpController)unityContainer.Resolve(this.ControllerType);
                    return controller;
                }
            }

            //没有使用的IOC注入的控制器,使用框架提供的方式返回
            IHttpControllerActivator httpControllerActivator = this.Configuration.Services.GetHttpControllerActivator();
            return httpControllerActivator.Create(request, this, this.ControllerType);
        }

       
    }
}
