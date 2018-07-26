using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    internal class ConfirmRetAuditPriceApplication : BaseApplicationService, IConfirmRetAuditPriceApplication
    {
        private readonly IConfirmRetAuditPriceServiceBll _confirmRetAuditPriceServiceBll;
        private readonly ISubmitCorpAduitOrderServiceBll _submitCorpAduitOrderServiceBll;//送审服务
        public ConfirmRetAuditPriceApplication(IConfirmRetAuditPriceServiceBll confirmRetAuditPriceServiceBll,
           ISubmitCorpAduitOrderServiceBll submitCorpAduitOrderServiceBll) 
        {
            _confirmRetAuditPriceServiceBll = confirmRetAuditPriceServiceBll;
            _submitCorpAduitOrderServiceBll = submitCorpAduitOrderServiceBll;
        }

        public bool ConfirmRetAuditPrice(ConfirmRetModAuditPriceRequestViewModel request)
        {
            ConfirmRetModAuditPriceModel query = new ConfirmRetModAuditPriceModel();
            query.Cid = request.Cid;
            query.Rmid = request.Rmid;
            query.DetailList = (from n in request.PolicyReasonList
                                select new ConfirmRetModAuditPriceDetailModel()
                                {
                                    Sequence = n.Sequence,
                                    ChoiceReasonId = n.ChoiceReasonId,
                                    Pid = n.Pid
                                }).ToList();
            ConfirmRetModAuditPriceResultModel resultModel = null;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    resultModel = _confirmRetAuditPriceServiceBll.ConfirmRetAuditPrice(query);

                    #region 核价完毕后，送审
                    if (resultModel != null && resultModel.IsSuccess)
                    {
                        SubmitCorpAduitOrderModel submitCorpAduitOrder = new SubmitCorpAduitOrderModel()
                        {
                            OrderInfoList = new List<SubmitCorpAduitOrderDetailModel>()
                            {
                                new SubmitCorpAduitOrderDetailModel()
                                {
                                    OrderId = resultModel.Rmid,
                                    OrderType = OrderSourceTypeEnum.FltRetApply
                                }
                            },
                            PolicyId = resultModel.CorpPolicyId,
                            AduitConfigId = resultModel.CorpAduitId,
                            Source = request.OrderSource,
                            SubmitCid = request.Cid,
                            SubmitOid = request.Oid,
                            IsViolatePolicy = resultModel.IsViolatePolicy,
                            OrderType = OrderSourceTypeEnum.FltRetApply
                        };
                        _submitCorpAduitOrderServiceBll.Submit(submitCorpAduitOrder);
                    }
                    #endregion

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }

            }

            if (resultModel == null)
                return false;
            return resultModel.IsSuccess;
        }
    }
}
