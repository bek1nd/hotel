using System;
using System.Linq;
using System.Linq.Expressions;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.IDAL.Customer.DAL;
using System.Collections.Generic;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Customer.Customer.DAL
{
    public class CustomerInfoDAL : ICustomerInfoDAL
    {
        public int Delete(CustomerInfoEntity t)
        {
            throw new NotImplementedException();
        }

        public int Insert(CustomerInfoEntity t)
        {
            throw new NotImplementedException();
        }

        public CustomerInfoEntity Query(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(CustomerInfoEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }
        
        public CustomerInfoEntity GetCustomerByExpression(Expression<Func<CustomerInfoEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.CustomerInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        public List<CustomerInfoEntity> GetCustomerListByExpression(Expression<Func<CustomerInfoEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.CustomerInfo.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }
    }
}
