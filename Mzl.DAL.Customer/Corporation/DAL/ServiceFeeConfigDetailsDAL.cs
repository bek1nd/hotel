using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.IDAL.Customer.DAL;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Corporation.DAL
{
    public class ServiceFeeConfigDetailsDAL: IServiceFeeConfigDetailsDAL
    {
        public int Insert(ServiceFeeConfigDetailsEntity t)
        {
            throw new NotImplementedException();
        }

        public int Update(ServiceFeeConfigDetailsEntity t, string[] properties = null)
        {
            throw new NotImplementedException();
        }

        public int Delete(ServiceFeeConfigDetailsEntity t)
        {
            throw new NotImplementedException();
        }

        public ServiceFeeConfigDetailsEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public List<ServiceFeeConfigDetailsEntity> GetServiceFeeConfigDetailsListByExpression(Expression<Func<ServiceFeeConfigDetailsEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.ServiceFeeConfigDetails.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }
    }
}
