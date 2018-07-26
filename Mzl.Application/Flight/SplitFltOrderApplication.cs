using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Flight.SplitOrder;
using Mzl.UIModel.Flight.SplitOrder;

namespace Mzl.Application.Flight
{
    internal class SplitFltOrderApplication : BaseApplicationService, ISplitFltOrderApplication
    {
        private readonly ISplitFltOrderServiceBll _splitFltOrderServiceBll;
        private readonly ICopyAduitOrderServiceBll _corpAduitOrderServiceBll;

        public SplitFltOrderApplication(ISplitFltOrderServiceBll splitFltOrderServiceBll, ICopyAduitOrderServiceBll corpAduitOrderServiceBll)
        {
            _splitFltOrderServiceBll = splitFltOrderServiceBll;
            _corpAduitOrderServiceBll = corpAduitOrderServiceBll;
        }

        public SplitFltOrderResponseViewModel SplitFltOrder(SplitFltOrderRequestViewModel request)
        {
            SplitFltOrderResponseViewModel responseViewModel = new SplitFltOrderResponseViewModel();
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    responseViewModel.OrderIdList = _splitFltOrderServiceBll.SplitFltOrderByPassenger(request.OrderId,
                        request.Oid);
                    if (responseViewModel.OrderIdList == null || responseViewModel.OrderIdList.Count == 0)
                        throw new Exception("拆分异常");

                    foreach (var orderid in responseViewModel.OrderIdList)
                    {
                        _corpAduitOrderServiceBll.Copy(request.OrderId, orderid);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return responseViewModel;
        }
    }
}
