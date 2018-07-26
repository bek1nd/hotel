using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;
using Mzl.IDAL.Customer.DAL;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.DomainModel.Customer.AppOpinion;

namespace Mzl.BLL.Customer.Customer
{
    public class AddAppOpinionServiceBll : BaseServiceBll, IAddAppOpinionServiceBll
    {
        private readonly IAppOpinionDal _appOpinionDal;
        private readonly ICustomerInfoDAL _customerInfoDal;
        private readonly ICorporationDAL _corporationDal;

        public AddAppOpinionServiceBll(IAppOpinionDal appOpinionDal,ICustomerInfoDAL customerInfoDal,ICorporationDAL corporationDal)
        {
            _appOpinionDal = appOpinionDal;
            _customerInfoDal = customerInfoDal;
            _corporationDal = corporationDal;
        }

        public AppOpinionDomainModel AddOpinion(AppOpinionModel appOpinionModel)
        {

             _appOpinionDal.Insert<AppOpinionEntity>(new AppOpinionEntity()
            {
                AppOpinion = appOpinionModel.AppOpinion,
                AppType = appOpinionModel.AppType,
                CreateCid = appOpinionModel.CreateCid,
                CreateTime = DateTime.Now
            });
            CustomerInfoEntity customerInfoEntity = _customerInfoDal.GetCustomerByExpression(x => x.Cid == appOpinionModel.CreateCid);
            CorporationEntity corporationEntity = _corporationDal.GetContactInfoByExpression(x => x.CorpId == customerInfoEntity.CorpID);
            AppOpinionDomainModel appOpinionDomainModel = new AppOpinionDomainModel { AppOpinion = appOpinionModel.AppOpinion, CustomerName = customerInfoEntity.RealName, ContactName = corporationEntity.CorpName };
            return appOpinionDomainModel;
        }
    }
}
