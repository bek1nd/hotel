using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using Mzl.Application.Account.Factory;
using Mzl.IApplication.Train.Order;
using Mzl.Application.Train.Order;
using Mzl.Application.Train.Order.Factory;
using Mzl.IApplication.Train.Order.Domain;
using Mzl.IApplication.Train.Order.Factory;
using Mzl.Mojory.WebApi.Config;
using Mzl.Common.Exceptions;
using Mzl.Common.EnumHelper;
using Mzl.Common.LogHelper;
using Mzl.Application.Train.Order.Domain;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.Server;
using Newtonsoft.Json;
using Mzl.DomainModel.Enum;
using Mzl.IApplication.Account.Domain;
using Mzl.IApplication.Account.Factory;

namespace Mzl.Mojory.WebApi.Controllers.Train.CallBack
{
    [AllowAnonymous]
    public class TrainCallBackController : ApiController
    {
       
        private IServerDomain domain = null;
        private IServerDomainFactory factory = null;

        public TrainCallBackController() : base()
        {
           
        }

        [HttpGet, HttpPost]
        public void Index()
        {
            //OrderDomain domain2=new OrderDomain();
            //string d = domain2.DoGetNumberIdentity(102132);

            LogHelper.WriteLog("B2T测试出票通知:" + PostHelper.ReceivePostInfo(), "CallBack");
        }

        /// <summary>
        /// 占座回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage HoldSeatCallBack()
        {
            IOrderDomainFactory orderDomainFactory=new OrderDomainFactory();
            IOrderDomain traOrderDomain= orderDomainFactory.CreateUpdateOrderDomainObj();
            factory = new HoldSeatFactory();
            domain = factory.CreateDomainObj();

            domain.TraHoldSeatCallBackEvent += traOrderDomain.DoTraHoldSeatCallBackEvent;
            bool flag=domain.DoHoldSeat();
            domain.TraHoldSeatCallBackEvent -= traOrderDomain.DoTraHoldSeatCallBackEvent;
            var response = Request.CreateResponse(HttpStatusCode.OK);
            if (flag)
            {

                
                response.Content = new StringContent("SUCCESS", Encoding.UTF8);
                return response;
            }
             
            response.Content = new StringContent("ERROR", Encoding.UTF8);
            return response;
        }
        /// <summary>
        /// 确认出票回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PrintTicketCallBack()
        {
            factory = new PrintTicketFactory();
            domain = factory.CreateDomainObj();

            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain orderDomain = orderDomainFactory.CreateUpdateOrderDomainObj();

            IAccountDomainFactory accountDomainFactory = new AccountDomainFactory();
            IAccountDomain accountDomain= accountDomainFactory.CreateDomainObj();

            domain.OrderTicketEvent += orderDomain.DoOrderTicketEvent;
            orderDomain.PaySupplierEvent += accountDomain.DoPaySupplierEvent;
            var str = domain.DoPrintTicket();
            domain.OrderTicketEvent -= orderDomain.DoOrderTicketEvent;
            orderDomain.PaySupplierEvent -= accountDomain.DoPaySupplierEvent;

            LogHelper.WriteLog("确认出票回调:"+ str , "CallBack");

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("SUCCESS", Encoding.UTF8);
            return response;
        }
        /// <summary>
        /// 退票回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage RefundCallBack()
        {
            try
            {
                factory = new RefundTicketFactory();
                domain = factory.CreateDomainObj();
                IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
                IOrderDomain traOrderDomain = orderDomainFactory.CreateUpdateOrderDomainObj();

                IAccountDomainFactory accountDomainFactory = new AccountDomainFactory();
                IAccountDomain accountDomain = accountDomainFactory.CreateDomainObj();

                domain.RefundCallBackEvent += traOrderDomain.RefundTicketCallBackEvent;
                traOrderDomain.CollectSupplierEvent += accountDomain.DoCollectSupplierEvent;
                domain.DoRefundTicket();
                domain.RefundCallBackEvent -= traOrderDomain.RefundTicketCallBackEvent;
                traOrderDomain.CollectSupplierEvent -= accountDomain.DoCollectSupplierEvent;
             
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Api异常信息:" + ex.Message + "||||||报错路径:" + ex.StackTrace, "MojoryException");
            }
            //不用管异常处理，强制返回一个success，这样就能收到退款
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("SUCCESS", Encoding.UTF8);
            return response;

        }
        /// <summary>
        /// 改签占座回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ModHoldSeatCallBack()
        {
            factory = new ModHoldSeatFactory();
            domain = factory.CreateDomainObj();
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain traOrderDomain = orderDomainFactory.CreateAddModOrderDomainObj();

            domain.ModCallBackEvent += traOrderDomain.DoModCallBackEvent;
            domain.DoModHoldSeat();
            domain.ModCallBackEvent -= traOrderDomain.DoModCallBackEvent;



            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("SUCCESS", Encoding.UTF8);
            return response;
        }
        /// <summary>
        /// 改签出票回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage ModPrintTicketCallBack()
        {
            factory = new ModPrintTicketFactory();
            domain = factory.CreateDomainObj();
            IOrderDomainFactory orderDomainFactory = new OrderDomainFactory();
            IOrderDomain traOrderDomain = orderDomainFactory.CreateUpdateOrderDomainObj();
            domain.ModPrintTicketEvent += traOrderDomain.DoModPrintTicketEvent;
            domain.DoModPrintTicket();
            domain.ModPrintTicketEvent -= traOrderDomain.DoModPrintTicketEvent;
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent("SUCCESS", Encoding.UTF8);
            return response;
        }
       
    }
}
