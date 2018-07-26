using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.BaseInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface ICustomerInfoDAL : IBaseDAL<CustomerInfoEntity>
    {
        /// <summary>
        /// 根据不同的表达式获取客户信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        CustomerInfoEntity GetCustomerByExpression(Expression<Func<CustomerInfoEntity, bool>> predicate);
        /// <summary>
        /// 根据不同的表达式获取客户集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<CustomerInfoEntity> GetCustomerListByExpression(Expression<Func<CustomerInfoEntity, bool>> predicate);
    }
}
