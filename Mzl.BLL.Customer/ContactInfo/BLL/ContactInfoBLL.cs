using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Mzl.BLL.Customer.ContactInfo.BLL
{
    public class ContactInfoBLL : IContactInfoBLL<ContactInfoModel>
    {
        private readonly IContactInfoDAL _dal;

        public ContactInfoBLL(IContactInfoDAL dal)
        {
            _dal = dal;
        }

        public ContactInfoModel GetPassengerContactInfo(int cid)
        {
            ContactInfoEntity contactInfo = _dal.GetContactInfoByExpression(n => n.PCid == cid);
            return Mapper.Map<ContactInfoEntity, ContactInfoModel>(contactInfo);
        }

        public List<ContactInfoModel> GetPassengerContactInfoList(List<int> cidList)
        {
            List<ContactInfoEntity> contactInfoList = _dal.GetContactInfoListByExpression(
                n =>(n.PCid.HasValue && cidList.Contains(n.PCid.Value))
                     && n.IsDel.ToUpper() != "T" &&
                    (!string.IsNullOrEmpty(n.Cname) || !string.IsNullOrEmpty(n.Ename)));
            return Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoList);
        }

        public List<ContactInfoModel> GetPassengerContactInfoList(int cid)
        {
            List<ContactInfoEntity> contactInfoList = _dal.GetContactInfoListByExpression(
                n => n.Cid == cid
                     && n.IsDel.ToUpper() != "T" &&
                     (!string.IsNullOrEmpty(n.Cname) || !string.IsNullOrEmpty(n.Ename)));
            return Mapper.Map<List<ContactInfoEntity>, List<ContactInfoModel>>(contactInfoList);
        }

        public int AddContact(ContactInfoModel t)
        {
            ContactInfoEntity contactInfo= Mapper.Map<ContactInfoModel, ContactInfoEntity>(t);

            return _dal.Insert(contactInfo);
        }

        public int UpdateContact(ContactInfoModel t, string[] paramStrings = null)
        {
            ContactInfoEntity contactInfo = Mapper.Map<ContactInfoModel, ContactInfoEntity>(t);
            return _dal.Update(contactInfo, paramStrings);
        }
    }
}
