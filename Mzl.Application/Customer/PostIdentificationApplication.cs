using Mzl.IApplication.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Customer.Identification;
using Mzl.IBLL.Customer.Customer;
using AutoMapper;
using Mzl.DomainModel.Customer.Identification;
using Mzl.Framework.Base;

namespace Mzl.Application.Customer
{
    public class PostIdentificationApplication : BaseApplicationService, IPostIdentificationApplication
    {
        public readonly IPostIdentificationServiceBll _postIdentificationServiceBll;

        public PostIdentificationApplication(IPostIdentificationServiceBll postIdentificationServiceBll)
        {
            this._postIdentificationServiceBll = postIdentificationServiceBll;
        }

        public bool PostIdentification(IdentificationViewModel model, int cid)
        {
            using (var transport = this.Context.Database.BeginTransaction())
            {
                try
                {
                    var m = Mapper.Map<IdentificationViewModel, IdentificationModel>(model);
                    var result = _postIdentificationServiceBll.PostIdentification(m, cid);
                    transport.Commit();
                    return result;
                }
                catch (Exception)
                {
                    transport.Rollback();
                    throw;
                }
               
            }
        }
    }
}
