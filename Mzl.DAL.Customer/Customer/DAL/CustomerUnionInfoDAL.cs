using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Customer.DAL
{
    public class CustomerUnionInfoDAL : ICustomerUnionInfoDAL
    {
        public int Delete(CustomerUnionInfoEntity t)
        {
            throw new NotImplementedException();
        }

        public int Insert(CustomerUnionInfoEntity t)
        {
            throw new NotImplementedException();
        }

        public CustomerUnionInfoEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.CustomerUnionInfo.Where(n=>n.Cid==id).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        public int Update(CustomerUnionInfoEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
    }
}
