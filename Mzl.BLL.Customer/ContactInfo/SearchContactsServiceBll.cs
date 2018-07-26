using System.Collections.Generic;
using System.Linq;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IBLL.Customer.Customer;

namespace Mzl.BLL.Customer.ContactInfo
{
    internal class SearchContactsServiceBll: BaseServiceBll,ISearchContactsServiceBll
    {
        private readonly IGetCustomerBll _getCustomerBll;
        private readonly IGetContactBll _getContactBll;
        public SearchContactsServiceBll(IGetCustomerBll getCustomerBll, IGetContactBll getContactBll)
        {
            _getCustomerBll = getCustomerBll;
            _getContactBll = getContactBll;
        }

        public List<ContactInfoModel> SearchContacts(string args, int cid)
        {
            List<ContactInfoModel> contactInfoModels = new List<ContactInfoModel>();
            CustomerModel customerModel = _getCustomerBll.GetCustomerByCid(cid);

            if (!string.IsNullOrEmpty(customerModel.CorpID) && customerModel.Corporation!=null)
            {
                if (customerModel.Corporation.IsAmplitudeCorp == "T")
                {
                    if (customerModel.IsMaster == "T")
                    {
                        //查询当前公司下所有的联系人信息
                        //List<CustomerModel> customerModels = _getCustomerBll.GetCustomerByCorpId(customerModel.CorpID);
                        //List<int> cidList = customerModels.Select(n => n.Cid).ToList();
                        //contactInfoModels = _getContactBll.GetContactByCid(cidList, args);

                        //查询当前客户名下的联系人信息
                        contactInfoModels = _getContactBll.GetContactByCid(customerModel.Cid, args);
                    }
                    else
                    {
                        //查询当前客户名下的联系人信息
                        contactInfoModels = _getContactBll.GetContactByCid(customerModel.Cid, args);
                    }
                }
                else
                {
                    //查询当前公司下所有的联系人信息
                    List<CustomerModel> customerModels = _getCustomerBll.GetCustomerByCorpId(customerModel.CorpID);
                    List<int> cidList = customerModels.Select(n => n.Cid).ToList();
                    contactInfoModels = _getContactBll.GetContactByCid(cidList, args);
                }
                
            }
            else
            {
                //查询当前客户名下的联系人信息
                contactInfoModels = _getContactBll.GetContactByCid(customerModel.Cid, args);
            }


            return contactInfoModels;
        }
    }
}
