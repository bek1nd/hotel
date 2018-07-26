using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Customer.BaseInfo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Flight
{
    public abstract class AddOrderAbstractContext
    {
        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        public DbContext DbContext { get; set; }
        /// <summary>
        /// 添加机票订单信息
        /// </summary>
        public AddOrderModel AddOrderModel { get; set; }
        /// <summary>
        /// 添加改签/退票申请信息
        /// </summary>
        public AddRetModApplyModel AddRetModApplyModel { get; set; }
    }
}
