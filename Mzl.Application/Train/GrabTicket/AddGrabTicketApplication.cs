using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Application.Customer.Factory;
using Mzl.Common.EnumHelper.Train;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.Framework.Base;
using Mzl.IApplication.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Mzl.UIModel.Train.GrabTicket;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.IApplication.Customer.Domain;
using Mzl.IApplication.Customer.Factory;
using Mzl.IBLL.Customer.Customer;

namespace Mzl.Application.Train.GrabTicket
{
    public class AddGrabTicketApplication: BaseApplicationService,IAddGrabTicketApplication
    {
        private readonly IAddTraGrabTicketServiceBll _addTraGrabTicketServiceBll;
        private readonly IUpdateTraGrabTicketStatusServiceBll _updateTraGrabTicketStatusServiceBll;
        private readonly IRequestGrabTicketServiceBll _requestGrabTicketServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public AddGrabTicketApplication(IAddTraGrabTicketServiceBll addTraGrabTicketServiceBll, 
            IUpdateTraGrabTicketStatusServiceBll updateTraGrabTicketStatusServiceBll,
            IRequestGrabTicketServiceBll requestGrabTicketServiceBll,
             IGetCustomerServiceBll getCustomerServiceBll)
        {
            _addTraGrabTicketServiceBll = addTraGrabTicketServiceBll;
            _updateTraGrabTicketStatusServiceBll = updateTraGrabTicketStatusServiceBll;
            _requestGrabTicketServiceBll = requestGrabTicketServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }

        public AddGrabTicketResponseViewModel AddGrabTicket(AddGrabTicketRequestViewModel request)
        {
            AddTraGrabTicketModel addTraGrabTicketModel =
               Mapper.Map<AddGrabTicketRequestViewModel, AddTraGrabTicketModel>(request);
            if(addTraGrabTicketModel.SeatType.Contains("无座"))
                throw new Exception("座位类型中不能包含无座");
            addTraGrabTicketModel.CreateOid = request.Oid;
            //0.获取客户信息
            addTraGrabTicketModel.Customer = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            
            //1.添加抢票信息
            int grabId = 0;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    ICustomerDomainFactory customerDomainFactory = new CustomerDomainFactory();
                    ICustomerDomain customerDomain = customerDomainFactory.CreatePassengerInfoDomainObj();

                    _addTraGrabTicketServiceBll.AddContactEvent += customerDomain.AddContactEventListener;
                    grabId = _addTraGrabTicketServiceBll.AddTraGrabTicket(addTraGrabTicketModel);
                    _addTraGrabTicketServiceBll.AddContactEvent -= customerDomain.AddContactEventListener;

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            //2.访问抢票接口
           
            GrabTicketResponseModel responseModel= _requestGrabTicketServiceBll.RequestGrabTicketInterface(addTraGrabTicketModel);
            bool isSuccess = false;
            //3.根据结果更新抢票状态
            UpdateTraGrabTicketStatusModel updateTraGrabTicketStatusModel = new UpdateTraGrabTicketStatusModel()
            {
                GrabId = grabId
            };
            if (responseModel.success)
            {
                updateTraGrabTicketStatusModel.GrabStatus = TrainGrabStatusEnum.P;
                isSuccess = true;
            }
            else
            {
                updateTraGrabTicketStatusModel.GrabStatus = TrainGrabStatusEnum.D;
                updateTraGrabTicketStatusModel.SubmitFailedReason = responseModel.msg;
            }


            _updateTraGrabTicketStatusServiceBll.UpdateTraGrabTicketStatusByAfterSubmit(
                updateTraGrabTicketStatusModel);


            return new AddGrabTicketResponseViewModel() {IsSuccess = isSuccess, Message = responseModel.msg};
        }
    }
}
