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
    internal class AddContactServiceBll: BaseServiceBll,IAddContactServiceBll
    {
        private readonly IContactDal _contactDal;
        private readonly IContactIdentificationDal _contactIdentificationDal;

        public AddContactServiceBll(IContactDal contactDal, IContactIdentificationDal contactIdentificationDal)
        {
            _contactDal = contactDal;
            _contactIdentificationDal = contactIdentificationDal;
        }

        public AddResultBaseModel<int> Add(AddContactModel model)
        {
            string cName = model.Cname;
            string eName = string.Empty;
            if (model.Cname.Contains("/"))
            {
                eName = model.Cname;
                cName = string.Empty;
            }
            List<ContactInfoEntity> contactInfoEntities = _contactDal.Query<ContactInfoEntity>(
                n => n.Cid == model.Cid && n.IsDel == "F" && (n.Cname == model.Cname || n.Ename == model.Cname), true)
                .ToList();
            if (contactInfoEntities != null && contactInfoEntities.Count > 0)
            {
                List<int> contactId = new List<int>();
                contactInfoEntities.ForEach(n=> contactId.Add(n.Contactid));
                int count=_contactIdentificationDal.Query<ContactIdentificationInfoEntity>(
                    n => contactId.Contains(n.Contactid) && n.CardNo == model.CardNo,true).Count();
                if (count > 0)
                {
                    throw new Exception("当前已经存在该信息");
                }
            }


            ContactInfoEntity contactInfo = new ContactInfoEntity()
            {
                Cname = cName,
                Ename = eName,
                Mobile = model.Mobile,
                Cid = model.Cid,
                LastUpdateTime = DateTime.Now,
                IsDel = "F",
                IsPassenger = model.IsPassenger,
                UpdateOid = "sys",
                DelTime = DateTime.Now,
                Email = model.Email,
                IsOnline = (model.OrderSource == "O" ? 0 : 1)
            };
            contactInfo = _contactDal.Insert<ContactInfoEntity>(contactInfo);

            _contactIdentificationDal.Insert<ContactIdentificationInfoEntity>(new ContactIdentificationInfoEntity()
            {
                Contactid = contactInfo.Contactid,
                CardNo = model.CardNo,
                Iid = model.Iid,
                LastUpdateTime = DateTime.Now
            });

            return new AddResultBaseModel<int>()
            {
                IsSuccessed = true,
                Id = contactInfo.Contactid
            };
        }
    }
}
