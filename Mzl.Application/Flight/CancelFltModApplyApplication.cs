using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.UIModel.Flight;

namespace Mzl.Application.Flight
{
    internal class CancelFltModApplyApplication : BaseApplicationService, ICancelFltModApplyApplication
    {
        private readonly ICancelRetModOrderServiceBll _cancelRetModOrderServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public CancelFltModApplyApplication(ICancelRetModOrderServiceBll cancelRetModOrderServiceBll, IGetCustomerServiceBll getCustomerServiceBll)
        {
            _cancelRetModOrderServiceBll = cancelRetModOrderServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }


        /// <summary>
        /// 待核价确认阶段取消改签申请
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CancelFltModApplyResponseViewModel CancelFltModApplyByWaitAuditStep(
            CancelFltModApplyRequestViewModel request)
        {

            //根据Cid查询客户信息
            CustomerModel customerModel = _getCustomerServiceBll.GetCustomerByCid(request.Cid);

            CancelFltRetModApplyModel query =
                Mapper.Map<CancelFltModApplyRequestViewModel, CancelFltRetModApplyModel>(request);
            query.CorpId = customerModel.CorpID;
            query.Customer = customerModel;

            int code = 0;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    code = _cancelRetModOrderServiceBll.CancelFltModApplyByWaitAuditStep(query);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new CancelFltModApplyResponseViewModel() {Code = code};
        }
    }
}
