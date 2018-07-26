using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.EntityModel.Customer.Corporation.Project;
using Mzl.IBLL.Customer.ProjectName.BLL;
using Mzl.IDAL.Customer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Mzl.BLL.Customer.ProjectName.BLL
{
    public class ProjectNameBLL : IProjectNameBLL<ProjectNameModel>
    {
        private readonly IProjectNameDAL _dal;

        public ProjectNameBLL(IProjectNameDAL dal)
        {
            _dal = dal;
        }

        public List<ProjectNameModel> GetProjectNameByCorpId(string corpId)
        {
            List<ProjectNameEntity> projectNameList =
                _dal.GetProjectNameListByExpression(n => n.CorpId == corpId && n.IsDelete != "T");
            if (projectNameList == null)
                return null;
            return Mapper.Map<List<ProjectNameEntity>, List<ProjectNameModel>>(projectNameList);
        }

        public ProjectNameModel GetProjectNameById(int id)
        {
            ProjectNameEntity projectNameEntity = _dal.Query(id);
            if (projectNameEntity == null)
                return null;
            return Mapper.Map<ProjectNameEntity, ProjectNameModel>(projectNameEntity);
        }

        public List<ProjectNameModel> GetProjectNameByIds(List<int> ids)
        {
            List<ProjectNameEntity> projectNameList =
                _dal.GetProjectNameListByExpression(n => ids.Contains(n.ProjectId) && n.IsDelete != "T");
            if (projectNameList == null)
                return null;
            return Mapper.Map<List<ProjectNameEntity>, List<ProjectNameModel>>(projectNameList);
        }
    }
}
