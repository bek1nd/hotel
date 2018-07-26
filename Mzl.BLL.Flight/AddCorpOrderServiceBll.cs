using Mzl.BLL.Flight.OrderValidate;
using Mzl.Common.LogHelper;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Flight;

namespace Mzl.BLL.Flight
{
    /// <summary>
    /// 添加国内差旅订单服务
    /// </summary>
    public class AddCorpOrderServiceBll : BaseServiceBll, IAddOrderServiceBll
    {
        private readonly IAddOrderBll _addOrderBll;
        private readonly IValidateOrderBll _validateOrderBll;
        private readonly IFltCorpCostCenterDal _fltCorpCostCenterDal;

        public AddCorpOrderServiceBll(IAddOrderBll addOrderBll, IValidateOrderBll validateOrderBll, IFltCorpCostCenterDal fltCorpCostCenterDal) : base()
        {
            _addOrderBll = addOrderBll;
            _validateOrderBll = validateOrderBll;
            _fltCorpCostCenterDal = fltCorpCostCenterDal;
        }

        public int AddDomesticOrder(AddOrderModel fltAddOrderModel)
        {
            //1.订单数据验证 
            _validateOrderBll.Validate(fltAddOrderModel);
           

            //2.添加订单
            int orderid = _addOrderBll.AddOrder(fltAddOrderModel);

            //3.添加成本中心
            if (!string.IsNullOrEmpty(fltAddOrderModel.CostCenter) && fltAddOrderModel.Customer != null &&
                !string.IsNullOrEmpty(fltAddOrderModel.Customer.CorpID))
            {
                _fltCorpCostCenterDal.Insert<FltCorpCostCenterEntity>(new FltCorpCostCenterEntity()
                {
                    Orderid = orderid,
                    Depart = fltAddOrderModel.CostCenter,
                    CorpID = fltAddOrderModel.Customer.CorpID
                });
            }

            return orderid;
        }
    }
}
