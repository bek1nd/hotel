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
    internal class AddContactApplication : BaseApplicationService, IAddContactApplication
    {
        private readonly IAddContactServiceBll _addContactServiceBll;

        public AddContactApplication(IAddContactServiceBll addContactServiceBll)
        {
            _addContactServiceBll = addContactServiceBll;
        }

        public AddContactResponseViewModel AddContact(AddContactRequestViewModel request)
        {
            AddContactModel addContactModel= Mapper
                .Map<AddContactRequestViewModel, AddContactModel>(request);
            AddResultBaseModel<int> flag = new AddResultBaseModel<int>()
            {
                IsSuccessed = false,
                Id = 0
            };
            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    flag = _addContactServiceBll.Add(addContactModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
         
            return new AddContactResponseViewModel() {IsSuccessed = flag.IsSuccessed, ContactId = flag.Id};
        }
    }
}
