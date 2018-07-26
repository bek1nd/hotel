using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Identification;
using Mzl.EntityModel.Customer.Contact;
using Mzl.EntityModel.Customer.Identification;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IDAL.Customer.ContactInfo;

namespace Mzl.BLL.Customer.ContactInfo
{
    public class GetContactServiceBll: BaseServiceBll,IGetContactServiceBll
    {
        private readonly IGetContactBll _getContactBll;
        private readonly IContactIdentificationDal _contactIdentificationDal;

        public GetContactServiceBll(IGetContactBll getContactBll, IContactIdentificationDal contactIdentificationDal)
        {
            _getContactBll = getContactBll;
            _contactIdentificationDal = contactIdentificationDal;
        }

        public GetContactInfoModel GetCorpContactByCid(int cid)
        {
            ContactInfoModel  contactInfoModel= _getContactBll.GetCorpContactByCid(cid);
            if (contactInfoModel == null)
            {
                return null;
            }
            GetContactInfoModel getContactInfoModel = new GetContactInfoModel().ConvertEntity(contactInfoModel);

            List< ContactIdentificationInfoEntity > contactIdentificationInfoEntities= _contactIdentificationDal.Query<ContactIdentificationInfoEntity>(
                n => n.Contactid == getContactInfoModel.ContactId,true).ToList();

            getContactInfoModel.IdentificationList = Mapper
                .Map<List<ContactIdentificationInfoEntity>, List<IdentificationModel>>(contactIdentificationInfoEntities);

            return getContactInfoModel;
        }

        public List<GetContactInfoModel> GetContactByCid(int cid)
        {
            List<GetContactInfoModel> getContactInfoModels = new List<GetContactInfoModel>();

            List<ContactInfoModel> contactInfoModelList = _getContactBll.GetContactByCid(cid);

            foreach (var contactInfoModel in contactInfoModelList)
            {
                GetContactInfoModel  getContactInfoModel= new GetContactInfoModel().ConvertEntity(contactInfoModel);
                getContactInfoModels.Add(getContactInfoModel);
            }

            return getContactInfoModels;
        }
    }
}
