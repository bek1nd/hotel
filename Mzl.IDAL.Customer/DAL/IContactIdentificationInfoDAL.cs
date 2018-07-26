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
    public interface IContactIdentificationInfoDAL : IBaseDAL<ContactIdentificationInfoEntity>
    {
        /// <summary>
        /// 获取证件信息集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<ContactIdentificationInfoEntity> GetIdentificationInfoList(
            Expression<Func<ContactIdentificationInfoEntity, bool>> predicate);
    }
}
