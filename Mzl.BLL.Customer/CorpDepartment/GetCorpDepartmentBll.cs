using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpDepartment;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.CorpDepartment
{
    public class GetCorpDepartmentBll : BaseBll, IGetCorpDepartmentBll
    {
        private readonly ICorpDepartmentDal _corpDepartmentDal;

        public GetCorpDepartmentBll(ICorpDepartmentDal corpDepartmentDal)
        {
            _corpDepartmentDal = corpDepartmentDal;
        }

        public List<CorpDepartmentModel> GetCorpDepartmentByCorpId(string corpId)
        {

            List<CorpDepartmentEntity> corpDepartmentEntities =
                _corpDepartmentDal.Query<CorpDepartmentEntity>(n => n.CorpId == corpId && n.IsDel.ToUpper() == "F", true)
                    .ToList();

            return Mapper.Map<List<CorpDepartmentEntity>, List<CorpDepartmentModel>>(corpDepartmentEntities);
        }

    }
}
