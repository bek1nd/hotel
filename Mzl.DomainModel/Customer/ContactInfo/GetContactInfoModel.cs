using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Identification;

namespace Mzl.DomainModel.Customer.ContactInfo
{
    public class GetContactInfoModel : ContactInfoModel
    {
        public List<IdentificationModel> IdentificationList { get; set; }

        public GetContactInfoModel ConvertEntity(ContactInfoModel entity)
        {
            if (entity == null)
                return null;
            var parentType = typeof(ContactInfoModel);
            var properties = parentType.GetProperties();
            foreach (var propertie in properties)
            {
                if (propertie.CanRead && propertie.CanWrite)
                {
                    propertie.SetValue(this, propertie.GetValue(entity, null), null);
                }
            }

            return this;
        }
    }
}
