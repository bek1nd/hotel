using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Base;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.EntityModel.Customer.Contact;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ContactInfo;
using Mzl.IDAL.Customer.ContactInfo;

namespace Mzl.BLL.Customer.ContactInfo
{
    public class EditContactServiceBll: BaseServiceBll,IEditContactServiceBll
    {
        private readonly IContactDal _contactDal;
        private readonly IContactIdentificationDal _contactIdentificationDal;
        public EditContactServiceBll(IContactDal contactDal, IContactIdentificationDal contactIdentificationDal)
        {
            _contactDal = contactDal;
            _contactIdentificationDal = contactIdentificationDal;
        }

        public AddResultBaseModel<int> Edit(EditContactModel model)
        {
            ContactInfoEntity contactInfoEntity = _contactDal.Find<ContactInfoEntity>(model.ContactId);
            if (model.Cname.Contains("/"))
            {
                contactInfoEntity.Ename = model.Cname;
                contactInfoEntity.Cname = string.Empty;
            }
            else
            {
                contactInfoEntity.Cname = model.Cname;
                contactInfoEntity.Ename = string.Empty;
            }

            contactInfoEntity.Mobile = model.Mobile;
            contactInfoEntity.LastUpdateTime = DateTime.Now;
            contactInfoEntity.UpdateOid = "sys";
            contactInfoEntity.DelTime = DateTime.Now;
            contactInfoEntity.Email = model.Email;
            if (!string.IsNullOrEmpty(model.IsDel))
                contactInfoEntity.IsDel = model.IsDel;

            _contactDal.Update(contactInfoEntity);

            ContactIdentificationInfoEntity contactIdentificationInfoEntity =
                _contactIdentificationDal.Query<ContactIdentificationInfoEntity>(
                    n => n.Contactid == model.ContactId && n.Iid == model.Iid, true).FirstOrDefault();
            if (contactIdentificationInfoEntity != null)
            {
                contactIdentificationInfoEntity.Iid = model.Iid;
                contactIdentificationInfoEntity.CardNo = model.CardNo;
                contactIdentificationInfoEntity.LastUpdateTime = DateTime.Now;
                _contactIdentificationDal.Update(contactIdentificationInfoEntity);
            }
            else
            {
                _contactIdentificationDal.Insert<ContactIdentificationInfoEntity>(new ContactIdentificationInfoEntity()
                {
                    Contactid = model.ContactId,
                    CardNo = model.CardNo,
                    Iid = model.Iid,
                    LastUpdateTime = DateTime.Now
                });
            }

            return new AddResultBaseModel<int>() {IsSuccessed = true, Id = model.ContactId};
        }
    }
}
