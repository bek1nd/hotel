using Mzl.DomainModel.Customer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    /// <summary>
    /// 火车查询页面模型
    /// </summary>
    public class QueryTraTravelModel : BaseQueryTravelModel
    {

        /// <summary>
        /// 复制父级实体到子级实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public QueryTraTravelModel ConvertParentToSon(BaseQueryTravelModel entity)
        {
            var parentType = typeof(BaseQueryTravelModel);
            var properties = parentType.GetProperties();
            foreach (var propertie in properties)
            {
                if (propertie.CanRead && propertie.CanWrite)
                {
                    propertie.SetValue(this, propertie.GetValue(entity, null), null);
                }
            }

            return this;
        }
    }
}
