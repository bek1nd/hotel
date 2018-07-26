using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.IApplication.Common;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.AuditOrder;
using Mzl.UIModel.Common.AuditOrder;

namespace Mzl.Application.Common
{
    [Obsolete("该审批功能已废弃")]
    internal class AuditOrderApplication : BaseApplicationService, IAuditOrderApplication
    {
        private readonly IAuditFltOrderServiceBll _auditFltOrderServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;
        private readonly IAddSendAppMessageServiceBll _addSendAppMessageServiceBll;

        public AuditOrderApplication(IAuditFltOrderServiceBll auditFltOrderServiceBll,
            IGetCustomerServiceBll getCustomerServiceBll, IAddSendAppMessageServiceBll addSendAppMessageServiceBll)
        {
            _auditFltOrderServiceBll = auditFltOrderServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
            _addSendAppMessageServiceBll = addSendAppMessageServiceBll;
        }

        public AuditOrderResponseViewModel RunAudit(AuditOrderRequestViewModel request)
        {
            //1.根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);
            if (string.IsNullOrEmpty(customerModel.IsCheckPerson) || customerModel.IsCheckPerson.ToUpper() != "T")
                throw new Exception("当前用户无权审批");

            AuditOrderResponseViewModel responseViewModel = new AuditOrderResponseViewModel();
            AuditTypeQueryModel query = new AuditTypeQueryModel()
            {
                OrderSourceType = request.OrderSourceType,
                Cid = request.Cid,
                Id = request.Id,
                AuditCustomer = customerModel,
                IsAgree = request.IsAgree,
                AuditStep = request.AuditStep
            };

            //机票类型审批
            List<OrderSourceTypeEnum> fltOrderSourceTypeList = new List<OrderSourceTypeEnum>()
            {
                OrderSourceTypeEnum.Flt,
                OrderSourceTypeEnum.FltModApply,
                OrderSourceTypeEnum.FltRetApply
            };

            if (fltOrderSourceTypeList.Contains(query.OrderSourceType))
            {
                using (var transaction = this.Context.Database.BeginTransaction())
                {
                    try
                    {
                        //1.进行审批
                        AuditResultModel  auditResultModel= _auditFltOrderServiceBll.RunAudit(query);
                        responseViewModel.Code = auditResultModel.Code;
                        if (auditResultModel.OwnCid != 0)
                        {
                            #region 推送app信息
                            /**
                             * 这里推送app消息分为两种：
                             * 1.推送审核结果给订单所属用户
                             * 2.如果存在下一级审核并且当前审核通过，则推送审核给下一级审核人
                             * */
                            //1.推送审核结果给订单所属用户
                            _addSendAppMessageServiceBll.AddAppAuditResultMessage(new SendAppAuditResultMessageModel()
                            {
                                IsAgree = request.IsAgree,
                                AuditResult = auditResultModel.AuditResult,
                                Cid = auditResultModel.OwnCid,
                                OrderId = auditResultModel.Id,
                                OrderType = auditResultModel.OrderType,
                                SendType = SendAppMessageTypeEnum.AuditResultNotice
                            });

                            //2.如果存在下一级审核并且当前审核通过，则推送审核给下一级审核人
                            if (auditResultModel.NextAuditCid.HasValue && request.IsAgree)
                            {
                                _addSendAppMessageServiceBll.AddAppWaitAuditMessage(new SendAppAuditResultMessageModel()
                                {
                                    Cid = auditResultModel.NextAuditCid.Value,
                                    OrderId = auditResultModel.Id,
                                    OrderType = auditResultModel.OrderType,
                                    SendType = SendAppMessageTypeEnum.WaitAuditNotice
                                });
                            } 
                            #endregion
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            else
            {
                throw new Exception("审批类型不正确！");
            }

            

            return responseViewModel;
        }
    }
}
