using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.Customer
{
    public interface IUpdateCustomerServiceBll : IBaseServiceBll
    {
        bool UpdateCustomerHeadPicture(int cid, string pictureUri);

        bool UpdateCustomerInfo(UpdateCustomerInfoModel up);

        bool UpdateCustomerCorpDepartIdList(int cid,List<int> corpDepartIdList, bool isAll);
    }
}
