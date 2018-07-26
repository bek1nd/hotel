using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.UIModel.Customer.Customer;

namespace Mzl.Application.Customer
{
    internal class EditContactApplication: BaseApplicationService,IEditContactApplication
    {
        private readonly IEditContactServiceBll _editContactServiceBll;

        public EditContactApplication(IEditContactServiceBll editContactServiceBll)
        {
            _editContactServiceBll = editContactServiceBll;
        }
        public EditContactResponseViewModel EditContact(EditContactRequestViewModel request)
        {
            EditContactModel editContactModel = Mapper
               .Map<EditContactRequestViewModel, EditContactModel>(request);
            AddResultBaseModel<int> flag = new AddResultBaseModel<int>()
            {
                IsSuccessed = false,
                Id = request.ContactId
            };
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    flag = _editContactServiceBll.Edit(editContactModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new EditContactResponseViewModel() { IsSuccessed = flag.IsSuccessed, ContactId = flag.Id };
        }
    }
}
