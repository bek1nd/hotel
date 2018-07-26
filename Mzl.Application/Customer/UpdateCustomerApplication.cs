using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    internal class UpdateCustomerApplication: BaseApplicationService,IUpdateCustomerApplication
    {
        private readonly IUpdateCustomerServiceBll _updateCustomerServiceBll;

        public UpdateCustomerApplication(IUpdateCustomerServiceBll updateCustomerServiceBll)
        {
            _updateCustomerServiceBll = updateCustomerServiceBll;
        }


        public UpdateCustomerHeadPictureResponseViewModel UpdateCustomerHeadPicture(UpdateCustomerHeadPictureRequestViewModel request)
        {
            bool flag = _updateCustomerServiceBll.UpdateCustomerHeadPicture(request.Cid, request.HeadPictureUri);
            return new UpdateCustomerHeadPictureResponseViewModel() {IsSuccessed = flag};
        }

        public UpdateCustomerInfoResponseViewModel UpdateCustomerInfo(UpdateCustomerInfoRequestViewModel request)
        {
            bool flag = false;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    flag = _updateCustomerServiceBll.UpdateCustomerInfo(new UpdateCustomerInfoModel()
                    {
                        Cid = request.Cid,
                        RealName = request.RealName,
                        Email = request.Email,
                        Mobile = request.Mobile,
                        Gender = request.Gender
                    });
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
           
            return new UpdateCustomerInfoResponseViewModel() {IsSuccessed = flag};
        }
    }
}
