using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Train.Order.CopyOrder;
using Mzl.Framework.Base;
using Mzl.IApplication.Train;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Train.Order;
using Mzl.UIModel.Train.Order.CopyOrder;
using Mzl.UIModel.Flight.SplitOrder;

namespace Mzl.Application.Train
{

    public class SplitTraOrderApplication : BaseApplicationService, ISplitTraOrderApplication
    {

        private readonly ISplitTraOrderServiceBll _SplitTraOrderServiceBll;
        public SplitTraOrderApplication(ISplitTraOrderServiceBll SplitTraOrderServiceBll)
        {
            _SplitTraOrderServiceBll = SplitTraOrderServiceBll;
        }


        public SplitTraOrderResponseViewModel SplitTraOrder(SplitTraOrderRequestViewModel request,out string Message)
        {
            Message = "";
            SplitTraOrderResponseViewModel responseViewModel = new SplitTraOrderResponseViewModel();
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    //返回生成的订单号组
                    responseViewModel.OrderIdList = _SplitTraOrderServiceBll.SplitOrder(request.OrderId, request.Oid);
                    if (responseViewModel.OrderIdList.Count > 0)
                    {
                        Message = "订单拆分成功";
                    }
                  
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Message = ex.Message;
                    transaction.Rollback();
                    throw;
                }
            }
            return responseViewModel;
        }
    }
}
