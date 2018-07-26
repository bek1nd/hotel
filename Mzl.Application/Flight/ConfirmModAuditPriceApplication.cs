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
using Mzl.Framework.UnitOfWork;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.CorpAduit.SubmitCorpAduitOrder;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    internal class ConfirmModAuditPriceApplication : BaseApplicationService, IConfirmModAuditPriceApplication
    {
        private readonly IConfirmModAuditPriceServiceBll _confirmModAuditPriceServiceBll;
        private readonly ISubmitCorpAduitOrderServiceBll _submitCorpAduitOrderServiceBll;//送审服务
        public ConfirmModAuditPriceApplication(IConfirmModAuditPriceServiceBll confirmModAuditPriceServiceBll,
            ISubmitCorpAduitOrderServiceBll submitCorpAduitOrderServiceBll)
        {
            _confirmModAuditPriceServiceBll = confirmModAuditPriceServiceBll;
            _submitCorpAduitOrderServiceBll = submitCorpAduitOrderServiceBll;
        }

        public bool ConfirmModAuditPrice(ConfirmRetModAuditPriceRequestViewModel request)
        {
            ConfirmRetModAuditPriceModel query=new ConfirmRetModAuditPriceModel();
            query.Cid = request.Cid;
            query.Rmid = request.Rmid;
            query.DetailList = (from n in request.PolicyReasonList
                select new ConfirmRetModAuditPriceDetailModel()
                {
                    Sequence =  n.Sequence,
                    ChoiceReasonId =  n.ChoiceReasonId,
                    Pid = n.Pid
                }).ToList();

            ConfirmRetModAuditPriceResultModel resultModel;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    //确认核价
                    resultModel = _confirmModAuditPriceServiceBll.ConfirmModAuditPrice(query);

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
                                    OrderType = OrderSourceTypeEnum.FltModApply
                                }
                            },
                            PolicyId = resultModel.CorpPolicyId,
                            AduitConfigId = resultModel.CorpAduitId,
                            Source = request.OrderSource,
                            SubmitCid = request.Cid,
                            SubmitOid = request.Oid,
                            IsViolatePolicy = resultModel.IsViolatePolicy,
                            OrderType = OrderSourceTypeEnum.FltModApply
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
