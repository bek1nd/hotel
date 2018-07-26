using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Customer.Customer;
using Mzl.Common.EmailHelper;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Customer.AppOpinion;

namespace Mzl.Application.Customer
{
    public class AddAppOpinionApplication : BaseApplicationService, IAddAppOpinionApplication
    {
        private readonly IAddAppOpinionServiceBll _addAppOpinionServiceBll;

        public AddAppOpinionApplication(IAddAppOpinionServiceBll addAppOpinionServiceBll)
        {
            _addAppOpinionServiceBll = addAppOpinionServiceBll;
        }

        public bool AddMojoryOpinion(AppOpinionRequestViewModel request)
        {
            AppOpinionDomainModel appOpinionDoaminModel =  _addAppOpinionServiceBll.AddOpinion(new AppOpinionModel()
            {
                AppOpinion = request.AppOpinion,
                AppType = 0,
                CreateCid = request.Cid
            });
            string formartContent = "公司：" + appOpinionDoaminModel.ContactName + "<br/>" + "客户：" + appOpinionDoaminModel.CustomerName + "<br/>" + request.AppOpinion;
            Task task = new Task(() =>
            {
                EmailHelper.SendEmail("", "APP意见反馈", null, null, formartContent, AppSettingsHelper.GetAppSettings(AppSettingsEnum.AppOptionEmailTo));
            });
            task.Start();
            return true;
        }
    }
}
