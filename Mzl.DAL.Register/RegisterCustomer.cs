using Mzl.IDAL.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Register;
using Mzl.EntityModel.EFContext;

namespace Mzl.DAL.Register
{
    public class RegisterCustomer : IRegisterCustomer
    {
        public int Inster(RegisterCustomerEntity entity)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.RegisterCustomer.Add(entity);
                db.SaveChanges();
                return log.Id;
            }
        }
    }
}
