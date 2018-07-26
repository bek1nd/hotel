using Mzl.Framework.Base;
using Mzl.IApplication.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.AppOpinion;
using Mzl.UIModel.Customer.AppOpinion;
using Mzl.IBLL.Customer.Customer;
using AutoMapper;

namespace Mzl.Application.Customer
{
    public class GetAppOpinionListApplication : BaseApplicationService,IGetAppOpinionListApplication
    {
        private readonly IGetAppOpinionListServiceBll _GetAppOpinionListServiceBll;
        public GetAppOpinionListApplication(IGetAppOpinionListServiceBll getAppOpinionListSeriviceBll)
        {
            _GetAppOpinionListServiceBll = getAppOpinionListSeriviceBll;
        }
        public GetAppOpinionListResponseViewModel GetAppinionList(GetAppOpinionListRequestViewModel query)
        {
            AppOpinionDomainModelList resultModel = _GetAppOpinionListServiceBll.GetAppOpinionList(new QueryAppOpinionDomainModel()
            {
                PageSize = query.PageSize,
                PageIndex = query.PageIndex

            });
            return Mapper.Map<AppOpinionDomainModelList, GetAppOpinionListResponseViewModel>(resultModel);
        }
    }
}
