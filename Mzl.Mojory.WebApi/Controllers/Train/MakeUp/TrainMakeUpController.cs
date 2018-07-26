using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Mzl.Application.Train.Order.Factory;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IApplication.Train.Order.Factory;
using Mzl.Mojory.WebApi.Config;
using Mzl.Common.LogHelper;
using Mzl.DomainModel.Train.Server;
using Newtonsoft.Json;
using Mzl.DomainModel.Enum;
using System.Threading.Tasks;
using Mzl.Common.EmailHelper;

namespace Mzl.Mojory.WebApi.Controllers.Train.MakeUp
{
    /// <summary>
    /// 火车票弥补服务Api
    /// </summary>
    [AllowAnonymous]
    public class TrainMakeUpController : ApiController
    {
        /// <summary>
        /// 火车票占位弥补服务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string HoldSeateMakeUp()
        {
            IServerDomainFactory makeUpFactory = new MakeUpFactory();
            IServerDomain serverDomain = makeUpFactory.CreateDomainObj();

            IServerDomainFactory orderCancelFactory = new OrderCancelFactory();
            IServerDomain orderCancelDomain = orderCancelFactory.CreateDomainObj();

            IServerDomainFactory requestCancelfactory = new RequestCancelFactory();
            IServerDomain requestCancelDomain = requestCancelfactory.CreateDomainObj();

            serverDomain.HoldSeateMakeUpInfo(orderCancelDomain, requestCancelDomain);
            return "Ok";
        }
        /// <summary>
        /// 火车票正在出票弥补服务
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string MakingPrintMakeUp()
        {
            //获取三十分还是正在出票的信息，并访问接口获取实际信息，如果依旧是正在出票，则提醒；如果已经出票，但没有回执，则提醒
            IServerDomainFactory makeUpFactory = new MakeUpFactory();
            IServerDomain serverDomain = makeUpFactory.CreateDomainObj();
            IServerDomainFactory serverDomainFactory = new OrderInfoFactory();
            IServerDomain requestInterfaceOrderDomain = serverDomainFactory.CreateDomainObj();
            serverDomain.PrintingMakeUp(requestInterfaceOrderDomain);

            return "ok";
        }
    }
}