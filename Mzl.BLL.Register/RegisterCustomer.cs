using Mzl.IBLL.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Register;
using Mzl.EntityModel.Register;
using Mzl.Common.AutoMapperHelper;

namespace Mzl.BLL.Register
{
    public class RegisterCustomer : IRegisterCustomer
    {
        private readonly Mzl.IDAL.Register.IRegisterCustomer _registerCustomerDal;

        public RegisterCustomer(Mzl.IDAL.Register.IRegisterCustomer registerCustomerDal)
        {
            this._registerCustomerDal = registerCustomerDal;
        }

        public RegisterCustomer() {
            this._registerCustomerDal = new Mzl.DAL.Register.RegisterCustomer();
        }

        public bool Add(RegisterCustomerModel model)
        {
            RegisterCustomerEntity entity = AutoMapperHelper.DoMap<RegisterCustomerModel, RegisterCustomerEntity>(model);
            entity.CreateDate = DateTime.Now;
            entity.UpdateDate = DateTime.Now;
            return _registerCustomerDal.Inster(entity) > 0;
        }
    }
}
