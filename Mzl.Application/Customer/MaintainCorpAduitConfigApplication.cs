using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    public class MaintainCorpAduitConfigApplication : BaseApplicationService, IMaintainCorpAduitConfigApplication
    {
        private readonly IAddCorpAduitConfigServiceBll _addCorpAduitConfigServiceBll;
        private readonly IEditCorpAduitConfigServiceBll _editCorpAduitConfigServiceBll;

        public MaintainCorpAduitConfigApplication(IAddCorpAduitConfigServiceBll addCorpAduitConfigServiceBll,
            IEditCorpAduitConfigServiceBll editCorpAduitConfigServiceBll)
        {
            _addCorpAduitConfigServiceBll = addCorpAduitConfigServiceBll;
            _editCorpAduitConfigServiceBll = editCorpAduitConfigServiceBll;
        }

        public AddCorpAduitConfigResponseViewModel Add(AddCorpAduitConfigRequestViewModel request)
        {
            CorpAduitConfigModel corpAduitConfigModel =
                Mapper.Map<AddCorpAduitConfigRequestViewModel, CorpAduitConfigModel>(request);
            corpAduitConfigModel.CreateCid = request.Cid;

            bool flag = false;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    flag = _addCorpAduitConfigServiceBll.AddCorpAduitConfig(corpAduitConfigModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new AddCorpAduitConfigResponseViewModel() {IsSuccessed = flag};
        }

        public UpdateCorpAduitConfigResponseViewModel Update(UpdateCorpAduitConfigRequestViewModel request)
        {
            CorpAduitConfigModel corpAduitConfigModel =
               Mapper.Map<UpdateCorpAduitConfigRequestViewModel, CorpAduitConfigModel>(request);


            bool flag = false;
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    flag = _editCorpAduitConfigServiceBll.EditCorpAduitConfig(corpAduitConfigModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new UpdateCorpAduitConfigResponseViewModel() { IsSuccessed = flag };
        }
    }
}
