using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using Mzl.IBLL.Customer.ServiceFee.Factory;
using Mzl.BLL.Customer.ServiceFee.BLL;
using Mzl.IDAL.Customer.DAL;
using Mzl.IDAL.Customer.Factory;
using Mzl.DAL.Customer.Corporation.Factory;

namespace Mzl.BLL.Customer.ServiceFee.Factory
{
    public class ServiceFeeConfigBLLFactory: IServiceFeeConfigBLLFactory
    {
        public IServiceFeeConfigBLL<ServiceFeeConfigModel> CreateBllObj()
        {
            IServiceFeeConfigDALFactory serviceFeeConfigDalFactory = new ServiceFeeConfigDALFactory();
            return new ServiceFeeConfigBLL(serviceFeeConfigDalFactory.CreateSampleDalObj());
        }

        public IServiceFeeConfigBLL<ServiceFeeConfigModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
