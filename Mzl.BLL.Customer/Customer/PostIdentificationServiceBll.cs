using Mzl.IBLL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Identification;
using Mzl.IDAL.Customer.ContactInfo;
using Mzl.EntityModel.Customer.Contact;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IDAL.Customer.Customer;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.BLL.Customer.Customer
{

    public class PostIdentificationServiceBll : BaseServiceBll, IPostIdentificationServiceBll
    {
        private readonly IContactDal _contactDal;
        private readonly IContactIdentificationDal _contactIdentificationDal;
        private readonly IGetCustomerBll _getCustomerBll;


        public PostIdentificationServiceBll(IContactDal contactDal, IContactIdentificationDal contactIdentificationDal, IGetCustomerBll getCustomerBll)
        {
            this._contactDal = contactDal;
            this._contactIdentificationDal = contactIdentificationDal;
            _getCustomerBll = getCustomerBll;
        }

        public bool PostIdentification(IdentificationModel model, int cid)
        {
            var contact = _contactDal.Query<ContactInfoEntity>(a => a.PCid == cid).FirstOrDefault();
            if (contact == null)
                throw new Exception("当前客户信息异常，不能修改");

            if (model.IsDefault == 1)
            {
                contact.DefaultIdentificationId = model.Iid;
                _contactDal.Update<ContactInfoEntity>(contact, new string[] { "DefaultIdentificationId" });
            }
            else
            {
                if (contact.DefaultIdentificationId.HasValue&& contact.DefaultIdentificationId.Value == model.Iid)
                {
                    contact.DefaultIdentificationId = 0;
                    _contactDal.Update<ContactInfoEntity>(contact, new string[] { "DefaultIdentificationId" });
                }
            }

            model.ContactId = contact.Contactid;
            //判断当前公司下，是否存在相同证件，如果存在，则不许修改
            CustomerModel customerModel = _getCustomerBll.GetCustomerByCid(cid);
            if (!string.IsNullOrEmpty(customerModel.CorpID))
            {
                List<CustomerModel> customerModels = _getCustomerBll.GetCustomerByCorpId(customerModel.CorpID);
                List<int> cidList = new List<int>();
                customerModels.ForEach(n =>
                {
                    if (n.Cid != cid)
                        cidList.Add(n.Cid);
                });

                List<ContactInfoEntity> contactInfoEntities =
                    _contactDal.Query<ContactInfoEntity>(a => cidList.Contains(a.PCid ?? 0)).ToList();

                List<int> contactIdList = new List<int>();

                contactInfoEntities.ForEach(n => contactIdList.Add(n.Contactid));

                List<ContactIdentificationInfoEntity> infoList =
                    _contactIdentificationDal.Query<ContactIdentificationInfoEntity>(
                        n =>
                            contactIdList.Contains(n.Contactid) && !string.IsNullOrEmpty(n.CardNo) &&
                            n.CardNo.ToUpper() == model.CardNo.ToUpper() && n.Iid == model.Iid)
                        .ToList();

                if (infoList != null && infoList.Count > 0)
                    throw new Exception("当前公司存在相同证件号，不能修改");
            }


            var identifications = _contactIdentificationDal.Query<ContactIdentificationInfoEntity>(a => a.Contactid == model.ContactId && a.Iid == model.Iid);
            var entity = Mapper.Map<IdentificationModel, ContactIdentificationInfoEntity>(model);

            entity.LastUpdateTime = DateTime.Now;
            entity.CardNo = entity.CardNo ?? "";
            if (identifications != null && identifications.Any())
            {
                _contactIdentificationDal.Update<ContactIdentificationInfoEntity>(entity);
            }
            else
            {
                _contactIdentificationDal.Insert<ContactIdentificationInfoEntity>(entity);
            }
            return true;
        }
    }
}
