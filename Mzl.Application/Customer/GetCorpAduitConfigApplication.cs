using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IBLL.Customer.Customer;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.CorpAduit;

namespace Mzl.Application.Customer
{
    public class GetCorpAduitConfigApplication : BaseApplicationService, IGetCorpAduitConfigApplication
    {
        private readonly IGetCorpAduitConfigServiceBll _getCorpAduitConfigServiceBll;
        private readonly IGetCustomerServiceBll _getCustomerServiceBll;

        public GetCorpAduitConfigApplication(IGetCorpAduitConfigServiceBll getCorpAduitConfigServiceBll, IGetCustomerServiceBll getCustomerServiceBll)
        {
            _getCorpAduitConfigServiceBll = getCorpAduitConfigServiceBll;
            _getCustomerServiceBll = getCustomerServiceBll;
        }
        /// <summary>
        /// 获取差旅公司下的审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetCorpAduitConfigListResponseViewModel GetCorpAduitConfigList(
            GetCorpAduitConfigListRequestViewModel request)
        {
            List<CorpAduitConfigModel> corpAduitConfigModels =
                _getCorpAduitConfigServiceBll.GetCorpAduitConfigListByCorpId(request.CorpId);

            GetCorpAduitConfigListResponseViewModel viewMode = new GetCorpAduitConfigListResponseViewModel();
            viewMode.AduitConfigList = new List<CorpAduitConfigListViewModel>();

            foreach (var corpAduitConfigModel in corpAduitConfigModels)
            {

                viewMode.AduitConfigList.Add(new CorpAduitConfigListViewModel()
                {
                    ConfigId= corpAduitConfigModel.ConfigId,
                    AduitName = corpAduitConfigModel.AduitName,
                    AduitOName = corpAduitConfigModel.AduitOName,
                    IsNeedAduitDes = corpAduitConfigModel.IsNeedAduitDes
                });
            }

            return viewMode;
        }
        /// <summary>
        /// 根据id获取审批规则
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetCorpAduitConfigResponseViewModel GetCorpAduitConfigById(GetCorpAduitConfigRequestViewModel request)
        {
            GetCorpAduitConfigResponseViewModel viewModel = new GetCorpAduitConfigResponseViewModel();
            if (request.ConfigId.HasValue)
            {
                CorpAduitConfigModel corpAduitConfigModel =
                    _getCorpAduitConfigServiceBll.GetCorpAduitConfigById(request.ConfigId.Value);
                viewModel.AduitConfigRule =
                    Mapper.Map<CorpAduitConfigModel, CorpAduitConfigViewModel>(corpAduitConfigModel);

            }

            viewModel.AduitONameList = new List<SortedListViewModel>();

            List<CustomerModel> customerModels = _getCustomerServiceBll.GetCustomerByCorpId(request.CorpId);
            customerModels = customerModels.FindAll(n => n.IsCheckPerson == "T"&&n.IsDel=="F"&&n.IsLock=="F");
            customerModels.ForEach(n =>
            {
                viewModel.AduitONameList.Add(new SortedListViewModel()
                {
                    Key = n.Cid,
                    Value = n.RealName
                });
            });

            return viewModel;
        }
    }
}
