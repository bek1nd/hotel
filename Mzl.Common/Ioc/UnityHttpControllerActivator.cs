using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Microsoft.Practices.Unity;
using Mzl.Common.ConfigHelper;

namespace Mzl.Common.Ioc
{
    public class UnityHttpControllerActivator: IHttpControllerActivator
    {
        private static readonly List<string> BlackList = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IOCBlackList).Split(',').ToList();

        /// <summary>
        /// 创建IHttpController
        /// </summary>
        /// <param name="request"></param>
        /// <param name="controllerDescriptor"></param>
        /// <param name="controllerType"></param>
        /// <returns></returns>
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            if (request == null)
            {
                throw new Exception("request");
            }

            //获取没有使用IOC注入的控制器
            if (!BlackList.Contains(controllerDescriptor.ControllerName))
            {
                //结合Unity容器创建，注意Unity容器名称规定为"{控制器名称}+api"形式
                IUnityContainer unityContainer = new IocHelper(controllerDescriptor.ControllerName + "Api").GetUnityContainer();
                if (unityContainer != null)
                {
                    IHttpController controller = (IHttpController)unityContainer.Resolve(controllerType);
                    return controller;
                }
            }

            return new DefaultHttpControllerActivator().Create(request, controllerDescriptor, controllerType);
        }
    }
}
