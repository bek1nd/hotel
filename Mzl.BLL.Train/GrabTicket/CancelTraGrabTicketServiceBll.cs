using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.EntityModel.Train;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Mzl.IDAL.Train;

namespace Mzl.BLL.Train.GrabTicket
{
    internal class CancelTraGrabTicketServiceBll : BaseServiceBll, ICancelTraGrabTicketServiceBll
    {
        private readonly IRequestGrabTicketCancelBll _requestGrabTicketCancelBll;
        private readonly ITraGrabTicketDal _traGrabTicketDal;

        public CancelTraGrabTicketServiceBll(IRequestGrabTicketCancelBll requestGrabTicketCancelBll, ITraGrabTicketDal traGrabTicketDal)
        {
            _requestGrabTicketCancelBll = requestGrabTicketCancelBll;
            _traGrabTicketDal = traGrabTicketDal;
        }

        /// <summary>
        /// 取消抢票
        /// </summary>
        /// <param name="cancelTraGrabTicketModel"></param>
        /// <returns></returns>
        public CancelTraGrabTicketResultModel CancelTraGrabTicket(CancelTraGrabTicketModel cancelTraGrabTicketModel)
        {
            TraGrabTicketEntity traGrabTicketEntity =
                _traGrabTicketDal.Find<TraGrabTicketEntity>(cancelTraGrabTicketModel.GrabId);
            if(traGrabTicketEntity==null)
                throw new Exception("未找到抢票信息");
            //请求取消接口
            GrabTicketCancelResponseModel grabTicketCancelResponseModel =
                _requestGrabTicketCancelBll.CancelGrabTicket(new GrabTicketCancelRequestModel()
                {
                    qorderid = traGrabTicketEntity.OrderId.ToString()
                });

            CancelTraGrabTicketResultModel cancelTraGrabTicketResultModel=new CancelTraGrabTicketResultModel();
            if (!grabTicketCancelResponseModel.isSuccess)
            {
                cancelTraGrabTicketResultModel.IsSuccess = false;
                cancelTraGrabTicketResultModel.Message = grabTicketCancelResponseModel.msg;
            }
            else
            {
                cancelTraGrabTicketResultModel.IsSuccess = true;
                traGrabTicketEntity.GrabStatus = "C";
                _traGrabTicketDal.Update(traGrabTicketEntity);
            }

            return cancelTraGrabTicketResultModel;
        }
    }
}
