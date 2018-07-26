using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.Factory;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Corporation.DAL
{
    public class ServiceFeeConfigDAL: IServiceFeeConfigDAL
    {
        public int Insert(ServiceFeeConfigEntity t)
        {
            throw new NotImplementedException();
        }

        public int Update(ServiceFeeConfigEntity t, string[] properties = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(ServiceFeeConfigEntity t)
        {
            throw new NotImplementedException();
        }

        public ServiceFeeConfigEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ServiceFeeConfig.Where(n=>n.SfcId==id).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        public ServiceFeeConfigEntity GetServiceFeeConfigByExpression(Expression<Func<ServiceFeeConfigEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ServiceFeeConfig.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }
    }
}
