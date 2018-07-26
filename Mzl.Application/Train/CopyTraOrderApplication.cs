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

namespace Mzl.Application.Train
{
    internal class CopyTraOrderApplication : BaseApplicationService, ICopyTraOrderApplication
    {
        private readonly ICopyAduitOrderServiceBll _corpAduitOrderServiceBll;
        private readonly ICopyTraOrderServiceBll _copyTraOrderServiceBll;

        public CopyTraOrderApplication(ICopyAduitOrderServiceBll corpAduitOrderServiceBll, ICopyTraOrderServiceBll copyTraOrderServiceBll)
        {
            _corpAduitOrderServiceBll = corpAduitOrderServiceBll;
            _copyTraOrderServiceBll = copyTraOrderServiceBll;
        }

        public CopyTraOrderResponseViewModel CopyTraOrder(CopyTraOrderRequestViewModel request)
        {
            //1.获取原始订单详情
            //2.新增新订单(订单主体信息，订单状态，行程信息，乘车人信息，审批信息)，并关联原始订单号
            //3.如果是虚退复制，则将原订单设置线上隐藏
            int orderid = 0;
            CopyTraOrderModel copyTraOrderModel = Mapper.Map<CopyTraOrderRequestViewModel, CopyTraOrderModel>(request);

            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    //新增复制订单
                    orderid = _copyTraOrderServiceBll.CopyOrder(copyTraOrderModel);
                    _corpAduitOrderServiceBll.Copy(request.CopyFromOrderId, orderid);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new CopyTraOrderResponseViewModel() { OrderId = orderid };
        }
    }
}
