using Mzl.Common.Factory;
using Mzl.DomainModel.Customer.Base;
using Mzl.IBLL.Customer.Verify.BLL;

namespace Mzl.IBLL.Customer.Verify.Factory
{
    public interface ICustomerVerifyBLLFactory: IBaseBLLFactory<ICustomerVerifyBLL<CustomerInfoModel>>
    {
    }
}
