using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    internal class CancelFltOrderApplication: BaseApplicationService,ICancelFltOrderApplication
    {
        private readonly ICancelFltOrderServiceBll _cancelFltOrderServiceBll;
        private readonly IGetCorpAduitOrderServiceBll _getCorpAduitOrderServiceBll;

        public CancelFltOrderApplication(ICancelFltOrderServiceBll cancelFltOrderServiceBll,
            IGetCorpAduitOrderServiceBll getCorpAduitOrderServiceBll)
        {
            _cancelFltOrderServiceBll = cancelFltOrderServiceBll;
            _getCorpAduitOrderServiceBll = getCorpAduitOrderServiceBll;
        }

        public CancelFltOrderResponseViewModel CancelOnlineCorpOrder(CancelFltOrderRequestViewModel request)
        {
            List<CorpAduitOrderInfoModel> aduitOrderInfoModels =
                _getCorpAduitOrderServiceBll.GetAduitOrderInfoByOrderId(request.OrderId);
            if (aduitOrderInfoModels != null && aduitOrderInfoModels.Count > 0)
            {
                if (aduitOrderInfoModels[0].Status != (int) CorpAduitOrderStatusEnum.F &&
                    aduitOrderInfoModels[0].Status != (int) CorpAduitOrderStatusEnum.J)
                {
                    throw new Exception("当前订单处于审批中，不能取消");
                }
            }

            int code = 0;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    code = _cancelFltOrderServiceBll.CancelOnlineCorpOrder(request.OrderId, request.Cid, "线上客户取消订单");
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new CancelFltOrderResponseViewModel() {Code = code};
        }
    }
}
