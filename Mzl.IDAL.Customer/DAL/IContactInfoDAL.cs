using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Customer.DAL
{
    public interface IContactInfoDAL : IBaseDAL<ContactInfoEntity>
    {
        /// <summary>
        /// 获取联系人集合信息
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<ContactInfoEntity> GetContactInfoListByExpression(Expression<Func<ContactInfoEntity, bool>> predicate);
        ContactInfoEntity GetContactInfoByExpression(Expression<Func<ContactInfoEntity, bool>> predicate);
    }
}
