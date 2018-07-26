using Mzl.Framework.Base;
using Mzl.IBLL.Common.Insurance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.CacheHelper;
using Mzl.DomainModel.Common.Insurance;
using Mzl.EntityModel.Common;
using Mzl.IDAL.Common;
using AutoMapper;

namespace Mzl.BLL.Common.Insurance
{
    internal class GetInsuranceCompanyServiceBll : BaseServiceBll, IGetInsuranceCompanyServiceBll
    {
        private readonly IInsuranceCompanyDal _insuranceCompanyDal;

        public GetInsuranceCompanyServiceBll(IInsuranceCompanyDal insuranceCompanyDal)
            : base()
        {
            _insuranceCompanyDal = insuranceCompanyDal;
        }

        public List<InsuranceCompanyModel> GetInsuranceCompany()
        {
            return CacheManager.Get(CacheKeyEnum.InsuranceProduct.ToString(), Get, 60*24);
        }

        public List<InsuranceCompanyModel> GetOnlineInsuranceCompany()
        {
            return CacheManager.Get(CacheKeyEnum.InsuranceProduct.ToString(), GetOnline, 60 * 24);
        }

        private List<InsuranceCompanyModel> Get()
        {
            List<InsuranceCompanyEntity> insuranceCompanyEntities =
                _insuranceCompanyDal.Query<InsuranceCompanyEntity>(n => n.IsDel == "F",true).ToList();

            return Mapper.Map<List<InsuranceCompanyEntity>, List<InsuranceCompanyModel>>(insuranceCompanyEntities);
        }

        private List<InsuranceCompanyModel> GetOnline()
        {
            return Get().FindAll(n => n.UpOnLine == "T");
        }
    }
}
