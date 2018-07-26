using Mzl.EntityModel.Train.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IDAL.Train.Order.DAL
{
    public interface  ITraOrderListDAL
    {
        List<TraOrderListDataEntity> GetTraOrderByPageList(TraOrderListQueryEntity query, ref int totalCount);

        List<TraOrderListDataEntity> GetTraOrderByPageListNew(TraOrderListQueryEntity query, ref int totalCount);
    }
}
