using Mzl.Framework.Base;
using Mzl.IDAL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DAL.Flight
{
    public class FltFlightDal : BaseDal, IFltFlightDal
    {
        public List<T> GetFlightByOrderId<T>(int orderid, int sequence) where T : class
        {
            List<T> tList =
               base.ExcuteQueryBySql<T>(
                   @"exec sp1_Flt_Flight_select @Orderid,@Sequence ",
                     new SqlParameter("@Orderid", orderid),
                     new SqlParameter("@Sequence", sequence)
                   ).ToList();
            return tList;
        }
    }
}
