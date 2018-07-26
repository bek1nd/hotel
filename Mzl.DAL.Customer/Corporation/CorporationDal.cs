using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.DAL.Customer.Corporation
{
    public class CorporationDal : BaseDal, ICorporationDal
    {
       

        public T Find<T>(string id) where T : class
        {
            return this.Context.Set<T>().Find(id);
        }
    }
}
