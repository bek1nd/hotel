using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpDepartment;

namespace Mzl.DomainModel.Flight
{
    /// <summary>
    /// 差旅乘机人对应客户信息
    /// </summary>
    public class CorpPassengerCustomerModel : CustomerModel
    {
        public CorpDepartmentModel Department { get; set; }

        public CorpPassengerCustomerModel ConvertFatherToSon(CustomerModel entity)
        {
            var parentType = typeof(CustomerModel);
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
