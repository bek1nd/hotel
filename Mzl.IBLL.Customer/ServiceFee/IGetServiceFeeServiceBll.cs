using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ServiceFee
{
    public interface IGetServiceFeeServiceBll : IBaseServiceBll
    {
        ServiceFeeInfoModel GetServiceFeeByCorpId(string corpId, int sfcId);
        ServiceFeeInfoModel GetServiceFeeBySfcid(int sfcId);
    }
}
