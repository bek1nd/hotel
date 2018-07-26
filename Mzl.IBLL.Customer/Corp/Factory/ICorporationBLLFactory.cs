using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.Corp;
using Mzl.IBLL.Customer.Corp.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Customer.Corp.Factory
{
    public interface ICorporationBLLFactory : IBaseBLLFactory<ICorporationBLL<CorporationModel>>
    {
    }
}
