using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.Identification;
using Mzl.EntityModel.Customer.Contact;
using Mzl.IBLL.Customer.ContactInfo.BLL;
using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Common.Insurance;
using Mzl.EntityModel.Common;

namespace Mzl.BLL.Customer.ContactInfo.BLL
{
    public class ContactIdentificationInfoBLL : IContactIdentificationInfoBLL<IdentificationModel>
    {
        private readonly IContactIdentificationInfoDAL _dal;

        public ContactIdentificationInfoBLL(IContactIdentificationInfoDAL dal)
        {
            _dal = dal;
        }

        public List<IdentificationModel> GetIdentificationInfoByContactId(List<int> contactIdList)
        {
           List<ContactIdentificationInfoEntity > identificationInfoList= _dal.GetIdentificationInfoList(n => contactIdList.Contains(n.Contactid));
            if (identificationInfoList == null)
                return null;
            return Mapper.Map<List<ContactIdentificationInfoEntity>, List<IdentificationModel>>(identificationInfoList);
        }

        public int AddIdentificationInfo(IdentificationModel t)
        {
            ContactIdentificationInfoEntity contactIdentificationInfoEntity =
                Mapper.Map<IdentificationModel, ContactIdentificationInfoEntity>(t);
           contactIdentificationInfoEntity.LastUpdateTime = DateTime.Now;
            return  _dal.Insert(contactIdentificationInfoEntity);
        }

        public int UpdateIdentificationInfo(IdentificationModel t, string[] paramStrings = null)
        {
            ContactIdentificationInfoEntity contactIdentificationInfoEntity =
                Mapper.Map<IdentificationModel, ContactIdentificationInfoEntity>(t);
            contactIdentificationInfoEntity.LastUpdateTime = DateTime.Now;
            return _dal.Update(contactIdentificationInfoEntity, paramStrings);
        }
    }
}
