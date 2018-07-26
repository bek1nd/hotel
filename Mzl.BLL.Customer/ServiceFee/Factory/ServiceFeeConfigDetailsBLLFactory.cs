using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using Mzl.IBLL.Customer.ServiceFee.Factory;
using Mzl.BLL.Customer.ServiceFee.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Corporation.Factory;

namespace Mzl.BLL.Customer.ServiceFee.Factory
{
    public class ServiceFeeConfigDetailsBLLFactory: IServiceFeeConfigDetailsBLLFactory
    {
        public IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel> CreateBllObj()
        {
            IServiceFeeConfigDetailsDALFactory serviceFeeConfigDetailsDalFactory = new ServiceFeeConfigDetailsDALFactory();
            return new ServiceFeeConfigDetailsBLL(serviceFeeConfigDetailsDalFactory.CreateSampleDalObj());
        }

        public IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
