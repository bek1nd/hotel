using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.IBLL.Customer.CorpDepartment.BLL;
using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Mzl.BLL.Customer.CorpDepartment.BLL
{
    public class CorpDepartmentBLL: ICorpDepartmentBLL<CorpDepartmentModel>
    {
        private readonly ICorpDepartmentDAL _dal;

        public CorpDepartmentBLL(ICorpDepartmentDAL dal)
        {
            _dal = dal;
        }

        public List<CorpDepartmentModel> GetCorpDepartmentByIds(List<int> ids)
        {
            List<CorpDepartmentEntity> corpDepartmentEntities =
                _dal.GetCorpDepartmentList(n => ids.Contains(n.Id) && n.IsDel != "T");
            if (corpDepartmentEntities == null)
                return null;
            return Mapper.Map<List<CorpDepartmentEntity>, List<CorpDepartmentModel>>(corpDepartmentEntities);
        }

        public List<CorpDepartmentModel> GetCorpDepartmentByCorpId(string corpId)
        {
            List<CorpDepartmentEntity> corpDepartmentEntities =
                _dal.GetCorpDepartmentList(
                    n => !string.IsNullOrEmpty(n.CorpId) && n.CorpId.ToUpper() == corpId.ToUpper() && n.IsDel != "T");
            if (corpDepartmentEntities == null)
                return null;
            return Mapper.Map<List<CorpDepartmentEntity>, List<CorpDepartmentModel>>(corpDepartmentEntities);
        }
    }
}
