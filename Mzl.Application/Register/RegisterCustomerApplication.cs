using Mzl.IApplication.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Register;
using Mzl.IBLL.Register;
using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Register;
using Mzl.BLL.Register;
using Mzl.Common.EmailHelper;
using Mzl.Common.ConfigHelper;

namespace Mzl.Application.Register
{
    public class RegisterCustomerApplication : IRegisterCustomerApplication
    {
        public readonly IRegisterCustomer _registrerCustomer;

        public RegisterCustomerApplication(IRegisterCustomer registrerCustomer) {
            _registrerCustomer = registrerCustomer;
        }

        public RegisterCustomerApplication()
        {
            _registrerCustomer = new RegisterCustomer();
        }
        public bool RegisterCustomer(RegisterViewModel model)
        {
            var result = AutoMapperHelper.DoMap<RegisterViewModel, RegisterCustomerModel>(model);
            EmailHelper.SendEmail("", 
                "公司名称：" + model.CorpName + ";" 
                + "联系人：" + model.Connector + ";" 
                + "联系电话：" + model.ConnectTel + ";"
                + "公司规模：" + model.CorpScale + ";"
                + "行业：" + model.Industry + ";"
                + "差旅体量：" + model.TripScale + ";"
                , null, null, "", AppSettingsHelper.GetAppSettings(AppSettingsEnum.ReginsterSendEmail));
            return _registrerCustomer.Add(result);
        }
    }
}
