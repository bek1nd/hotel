using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.DomainModel.Flight.CopyOrder;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Flight.CopyOrder;
using Mzl.UIModel.Flight.CopyOrder;

namespace Mzl.Application.Flight
{
    internal class CopyFltDomesticOrderApplication : BaseApplicationService, ICopyFltDomesticOrderApplication
    {
        private readonly ICopyFltDomesticOrderServiceBll _copyFltDomesticOrderServiceBll;
        private readonly ICopyAduitOrderServiceBll _corpAduitOrderServiceBll;

        public CopyFltDomesticOrderApplication(ICopyFltDomesticOrderServiceBll copyFltDomesticOrderServiceBll,
            ICopyAduitOrderServiceBll corpAduitOrderServiceBll)
        {
            _copyFltDomesticOrderServiceBll = copyFltDomesticOrderServiceBll;
            _corpAduitOrderServiceBll = corpAduitOrderServiceBll;
        }

        /// <summary>
        /// 复制国内机票订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public CopyFltDomesticOrderResponseViewModel CopyFltDomesticOrder(CopyFltDomesticOrderRequestViewModel request)
        {
            if (request.CopyFromOrderId == 0)
                throw new Exception("请传入复制来源订单号");

            //1.获取原始订单详情
            //2.新增新订单(订单主体信息，行程信息，乘机人信息，保险信息，票号信息，审批信息)，并关联原始订单号
            //3.如果是虚退复制，则将原订单设置线上隐藏
            CopyFltOrderModel copyFltOrderModel = Mapper.Map<CopyFltDomesticOrderRequestViewModel, CopyFltOrderModel>(request);
            int orderid = 0;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    orderid = _copyFltDomesticOrderServiceBll.CopyOrder(copyFltOrderModel);
                    _corpAduitOrderServiceBll.Copy(copyFltOrderModel.CopyFromOrderId, orderid);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new CopyFltDomesticOrderResponseViewModel() {OrderId = orderid};
        }
    }
}
