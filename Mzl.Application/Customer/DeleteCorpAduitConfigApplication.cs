using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    internal class DeleteCorpAduitConfigApplication : BaseApplicationService, IDeleteCorpAduitConfigApplication
    {
        private readonly IEditCorpAduitConfigServiceBll _editCorpAduitConfigServiceBll;

        public DeleteCorpAduitConfigApplication(IEditCorpAduitConfigServiceBll editCorpAduitConfigServiceBll)
        {
            _editCorpAduitConfigServiceBll = editCorpAduitConfigServiceBll;
        }

        public DeleteCorpAduitConfigResponseViewModel DeleteCorpAduitConfig(DeleteCorpAduitConfigRequestViewModel request)
        {
            bool flag = false;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    flag = _editCorpAduitConfigServiceBll.DeleteCorpAduitConfig(request.ConfigIdList);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new DeleteCorpAduitConfigResponseViewModel() {IsSuccessed = flag};
        }
    }
}
