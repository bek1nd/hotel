using Mzl.IBLL.Customer.Corp.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DAL.Customer.Corporation.Factory;
using Mzl.DomainModel.Customer.Corp;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.IDAL.Customer.Factory;
using Mzl.BLL.Customer.Corp.BLL;

namespace Mzl.BLL.Customer.Corp.Factory
{
    public class CorporationBLLFactory : ICorporationBLLFactory
    {
        public ICorporationBLL<CorporationModel> CreateBllObj()
        {
            ICorporationDALFactory corporationDalFactory = new CorporationDALFactory();
            return new CorporationBLL(corporationDalFactory.CreateSampleDalObj());
        }

        public ICorporationBLL<CorporationModel> CreateSampleBllObj()
        {
            throw new NotImplementedException();
        }
    }
}
