using Mzl.DomainModel.Customer.AppOpinion;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Customer.Customer
{
    public class GetAppOpinionListServiceBll : BaseServiceBll, IGetAppOpinionListServiceBll
    {
        private readonly IAppOpinionDal _appOpinionDal;
        public GetAppOpinionListServiceBll(IAppOpinionDal appOptionDal)
        {
            _appOpinionDal = appOptionDal;
        }
        public AppOpinionDomainModelList GetAppOpinionList(QueryAppOpinionDomainModel query)
        {
            var select = from appoption in Context.Set<AppOpinionEntity>().AsNoTracking()
                         join customer in Context.Set<CustomerInfoEntity>().AsNoTracking() on appoption.CreateCid equals customer.Cid
                         join corp in Context.Set<CorporationEntity>().AsNoTracking() on customer.CorpID equals corp.CorpId
                         select new AppOpinionDomainModel
                         {
                             Id = appoption.Id,
                             AppOpinion = appoption.AppOpinion,
                             AppType = appoption.AppType,
                             ContactName = customer.RealName,
                             CreateCid = appoption.CreateCid,
                             CreateTime = appoption.CreateTime,
                             CustomerName = corp.CorpName
                         };
            AppOpinionDomainModelList appOpinionList = new AppOpinionDomainModelList();
            appOpinionList.TotalCount = select.Count();
            if (appOpinionList.TotalCount>0)
            {
                appOpinionList.AppOpinionList = new List<AppOpinionDomainModel>();
                appOpinionList.AppOpinionList.AddRange(select.OrderByDescending(x => x.CreateTime).Skip((query.PageIndex - 1) * query.PageSize).Take(query.PageSize));
            }
            return appOpinionList;
        }
    }
}
