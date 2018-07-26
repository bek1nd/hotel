using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.BLL.Customer.Customer;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using Mzl.IBLL.Customer.MatchCorpPolicyAndAduit;
using Mzl.IDAL.Customer.Corporation;
using Mzl.EntityModel.Customer.Corporation.Department;
using Mzl.EntityModel.Customer.Corporation.Project;

namespace Mzl.BLL.Customer.MatchCorpPolicyAndAduit
{
    public class ChangeInfoFactory: IChangeInfoFactory
    {
        private readonly ICorpAduitConfigCustomerDal _corpAduitConfigCustomerDal;
        private readonly ICorpAduitConfigDepartmentDal _corpAduitConfigDepartmentDal;
        private readonly ICorpPolicyConfigCustomerDal _corpPolicyConfigCustomerDal;
        private readonly ICorpPolicyConfigDepartmentDal _corpPolicyConfigDepartmentDal;
        private readonly ICorpPolicyConfigDal _corpPolicyConfigDal;
        private readonly ICorpPolicyDetailConfigDal _corpPolicyDetailConfigDal;
        private readonly ICorpAduitConfigDal _corpAduitConfigDal;
        private readonly ICorpAduitConfigDetailDal _corpAduitConfigDetailDal;
        private readonly ICorpDepartmentDal _corpDepartmentDal;

        private readonly ICorpPolicyConfigProjectDal _corpPolicyConfigProjectDal;
        private readonly ICorpAduitConfigProjectDal _corpAduitConfigProjectDal;

        public ChangeInfoFactory(ICorpAduitConfigCustomerDal corpAduitConfigCustomerDal,
            ICorpAduitConfigDepartmentDal corpAduitConfigDepartmentDal,
            ICorpPolicyConfigCustomerDal corpPolicyConfigCustomerDal,
            ICorpPolicyConfigDepartmentDal corpPolicyConfigDepartmentDal,
            ICorpPolicyConfigDal corpPolicyConfigDal,
            ICorpAduitConfigDal corpAduitConfigDal, ICorpPolicyDetailConfigDal corpPolicyDetailConfigDal,
            ICorpAduitConfigDetailDal corpAduitConfigDetailDal, ICorpDepartmentDal corpDepartmentDal,
            ICorpPolicyConfigProjectDal corpPolicyConfigProjectDal, ICorpAduitConfigProjectDal corpAduitConfigProjectDal)
        {
            _corpAduitConfigCustomerDal = corpAduitConfigCustomerDal;
            _corpAduitConfigDepartmentDal = corpAduitConfigDepartmentDal;
            _corpPolicyConfigCustomerDal = corpPolicyConfigCustomerDal;
            _corpPolicyConfigDepartmentDal = corpPolicyConfigDepartmentDal;
            _corpPolicyConfigDal = corpPolicyConfigDal;
            _corpAduitConfigDal = corpAduitConfigDal;
            _corpPolicyDetailConfigDal = corpPolicyDetailConfigDal;
            _corpAduitConfigDetailDal = corpAduitConfigDetailDal;
            _corpDepartmentDal = corpDepartmentDal;
            _corpPolicyConfigProjectDal = corpPolicyConfigProjectDal;
            _corpAduitConfigProjectDal = corpAduitConfigProjectDal;
        }

        /// <summary>
        /// 产生差旅政策信息
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="departId"></param>
        /// <param name="isAllowUserInsurance"></param>
        /// <returns></returns>
        public List<CorpPolicyChangeModel> GetCorpPolicyChangeInfo(int cid, int departId,int isAllowUserInsurance)
        {
            List<CorpPolicyChangeModel> resultList = null;
            #region 先根据cid查找员工的差旅政策
            List<CorpPolicyConfigCustomerEntity> corpPolicyConfigCustomerList =
                   _corpPolicyConfigCustomerDal.Query<CorpPolicyConfigCustomerEntity>(n => n.Cid == cid, true).ToList();
            if (corpPolicyConfigCustomerList != null && corpPolicyConfigCustomerList.Count > 0)
            {
                List<int> policyIdList = new List<int>();
                corpPolicyConfigCustomerList.ForEach(n => { policyIdList.Add(n.PolicyId); });
                //获取政策信息
                List<CorpPolicyConfigEntity> policyList = _corpPolicyConfigDal.Query<CorpPolicyConfigEntity>(
                     n => policyIdList.Contains(n.PolicyId) && !string.IsNullOrEmpty(n.IsDel) && n.IsDel.ToUpper() == "F",
                     true).ToList();

                resultList = new List<CorpPolicyChangeModel>();
                foreach (var entity in corpPolicyConfigCustomerList)
                {
                    var policy = policyList.Find(n => n.PolicyId == entity.PolicyId);
                    if (policy != null)
                    {
                        List<CorpPolicyDetailConfigEntity> policyDetailList =
                            _corpPolicyDetailConfigDal.Query<CorpPolicyDetailConfigEntity>(
                                n => n.PolicyId == entity.PolicyId, true).ToList();
                        CorpPolicyDetailConfigModel policyModel = CorpPolicyConvertFactory.Convert(policyDetailList);

                        if (isAllowUserInsurance == 0)//如果当前公司个性化不许购买保险，则统一设置F；如果允许购买保险，则看差标允许不允许
                            policyModel.NPolicyValI = "F";

                        resultList.Add(new CorpPolicyChangeModel()
                        {
                            PolicyId = entity.PolicyId,
                            PolicyName = policy.PolicyName,
                            ViolateNPolicyValL = policyModel.NPolicyValL,
                            ViolateNPolicyValT = policyModel.NPolicyValT,
                            ViolateNPolicyValR = policyModel.NPolicyValR,
                            ViolateNPolicyValY = policyModel.NPolicyValY,
                            ViolateNPolicyValI = policyModel.NPolicyValI,
                            ViolateTPolicyValQ = policyModel.TPolicyValQ,
                            ViolateTPolicyValM = policyModel.TPolicyValM,
                            ViolateTPolicyValS = policyModel.TPolicyValS
                        });
                    }
                } 
                return resultList;
            }

            #endregion

            #region 如果没有政策，则查找部门的差旅政策
            List<CorpPolicyConfigDepartmentEntity> corpPolicyConfigDepartmentEntities =
                   _corpPolicyConfigDepartmentDal.Query<CorpPolicyConfigDepartmentEntity>(n => n.DepartmentId == departId,
                       true)
                       .ToList();
            if (corpPolicyConfigDepartmentEntities != null && corpPolicyConfigDepartmentEntities.Count > 0)
            {
                List<int> policyIdList = new List<int>();
                corpPolicyConfigDepartmentEntities.ForEach(n => { policyIdList.Add(n.PolicyId); });

                //获取政策信息
                List<CorpPolicyConfigEntity> policyList = _corpPolicyConfigDal.Query<CorpPolicyConfigEntity>(
                     n => policyIdList.Contains(n.PolicyId) && !string.IsNullOrEmpty(n.IsDel) && n.IsDel.ToUpper() == "F",
                     true).ToList();
                resultList = new List<CorpPolicyChangeModel>();

                foreach (var entity in corpPolicyConfigDepartmentEntities)
                {
                    var policy = policyList.Find(n => n.PolicyId == entity.PolicyId);
                    if (policy != null)
                    {
                        List<CorpPolicyDetailConfigEntity> policyDetailList =
                           _corpPolicyDetailConfigDal.Query<CorpPolicyDetailConfigEntity>(
                               n => n.PolicyId == entity.PolicyId, true).ToList();
                        CorpPolicyDetailConfigModel policyModel = CorpPolicyConvertFactory.Convert(policyDetailList);
                        if (isAllowUserInsurance == 0)//如果当前公司个性化不许购买保险，则统一设置F；如果允许购买保险，则看差标允许不允许
                            policyModel.NPolicyValI = "F";
                        resultList.Add(new CorpPolicyChangeModel()
                        {
                            PolicyId = entity.PolicyId,
                            PolicyName = policy.PolicyName,
                            ViolateNPolicyValL = policyModel.NPolicyValL,
                            ViolateNPolicyValT = policyModel.NPolicyValT,
                            ViolateNPolicyValR = policyModel.NPolicyValR,
                            ViolateNPolicyValY = policyModel.NPolicyValY,
                            ViolateNPolicyValI = policyModel.NPolicyValI,
                            ViolateTPolicyValQ = policyModel.TPolicyValQ,
                            ViolateTPolicyValM = policyModel.TPolicyValM,
                            ViolateTPolicyValS = policyModel.TPolicyValS
                        });
                    }
                }
                return resultList;
            } 
            #endregion

            //都没找到则返回null
            return null;
        }

        /// <summary>
        /// 根据项目成本中心对应的差旅政策信息
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="isAllowUserInsurance"></param>
        /// <returns></returns>
        public List<CorpPolicyChangeModel> GetCorpPolicyChangeInfoByProjectId(int projectId,
            int isAllowUserInsurance)
        {

            List<int> policyIdList =
                _corpPolicyConfigProjectDal.Query<CorpPolicyConfigProjectEntity>(
                    n => projectId == n.ProjectId, true).Select(n => n.PolicyId).ToList();//根据项目Id获取对应的差标信息

         
            if (policyIdList == null || policyIdList.Count == 0)
                return null;


            List<CorpPolicyChangeModel> resultList = new List<CorpPolicyChangeModel>();

            List<CorpPolicyConfigEntity> policyList = _corpPolicyConfigDal.Query<CorpPolicyConfigEntity>(
                   n => policyIdList.Contains(n.PolicyId) && !string.IsNullOrEmpty(n.IsDel) && n.IsDel.ToUpper() == "F",
                   true).ToList();

            foreach (var entity in policyList)
            {
                List<CorpPolicyDetailConfigEntity> policyDetailList =
                         _corpPolicyDetailConfigDal.Query<CorpPolicyDetailConfigEntity>(
                             n => n.PolicyId == entity.PolicyId, true).ToList();
                CorpPolicyDetailConfigModel policyModel = CorpPolicyConvertFactory.Convert(policyDetailList);
                if (isAllowUserInsurance == 0)//如果当前公司个性化不许购买保险，则统一设置F；如果允许购买保险，则看差标允许不允许
                    policyModel.NPolicyValI = "F";
                resultList.Add(new CorpPolicyChangeModel()
                {
                    PolicyId = entity.PolicyId,
                    PolicyName = entity.PolicyName,
                    ViolateNPolicyValL = policyModel.NPolicyValL,
                    ViolateNPolicyValT = policyModel.NPolicyValT,
                    ViolateNPolicyValR = policyModel.NPolicyValR,
                    ViolateNPolicyValY = policyModel.NPolicyValY,
                    ViolateNPolicyValI = policyModel.NPolicyValI,
                    ViolateTPolicyValQ = policyModel.TPolicyValQ,
                    ViolateTPolicyValM = policyModel.TPolicyValM,
                    ViolateTPolicyValS = policyModel.TPolicyValS
                });
            }



            return resultList;
        }

        /// <summary>
        /// 产生审批规则
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="departId"></param>
        /// <returns></returns>
        public List<CorpAduitChangeModel> GetCorpAduitChangeInfo(int cid, int departId)
        {
            List<CorpAduitChangeModel> resultList = null;
            #region 先根据cid查找员工的审批规则
            List<CorpAduitConfigCustomerEntity> corpAduitConfigCustomerEntities =
                   _corpAduitConfigCustomerDal.Query<CorpAduitConfigCustomerEntity>(n => n.Cid == cid, true).ToList();

            if (corpAduitConfigCustomerEntities != null && corpAduitConfigCustomerEntities.Count > 0)
            {
                List<int> aduitIdList = new List<int>();
                corpAduitConfigCustomerEntities.ForEach(n => { aduitIdList.Add(n.AduitId); });
                //获取审批规则
                List<CorpAduitConfigEntity> aduitList = _corpAduitConfigDal.Query<CorpAduitConfigEntity>(
                    n => aduitIdList.Contains(n.ConfigId) && n.IsDel == 0,
                    true).ToList();

                resultList = new List<CorpAduitChangeModel>();
                foreach (var entity in corpAduitConfigCustomerEntities)
                {
                    var aduit = aduitList.Find(n => n.ConfigId == entity.AduitId);
                    if (aduit != null)
                    {
                        List<CorpAduitConfigDetailEntity> corpAduitConfigDetailEntities =
                            _corpAduitConfigDetailDal.Query<CorpAduitConfigDetailEntity>(
                                n => n.AduitCid == entity.AduitId, true).ToList();
                        
                        resultList.Add(new CorpAduitChangeModel()
                        {
                            AduitId = entity.AduitId,
                            AduitName = aduit.AduitName
                        });
                    }
                }
                return resultList;
            }

            #endregion

            #region 如果没有审批规则，则查找部门的审批规则
            List<CorpAduitConfigDepartmentEntity> corpAduitConfigDepartmentEntities =
                   _corpAduitConfigDepartmentDal.Query<CorpAduitConfigDepartmentEntity>(n => n.DepartmentId == departId,
                       true)
                       .ToList();
            if (corpAduitConfigDepartmentEntities != null && corpAduitConfigDepartmentEntities.Count > 0)
            {
                List<int> aduitIdList = new List<int>();
                corpAduitConfigDepartmentEntities.ForEach(n => { aduitIdList.Add(n.AduitId); });

                //获取审批规则信息
                List<CorpAduitConfigEntity> aduitList = _corpPolicyConfigDal.Query<CorpAduitConfigEntity>(
                    n => aduitIdList.Contains(n.ConfigId) && n.IsDel == 0,
                    true).ToList();
                resultList = new List<CorpAduitChangeModel>();

                foreach (var entity in corpAduitConfigDepartmentEntities)
                {
                    var aduit = aduitList.Find(n => n.ConfigId == entity.AduitId);
                    if (aduit != null)
                    {
                        resultList.Add(new CorpAduitChangeModel()
                        {
                            AduitId = entity.AduitId,
                            AduitName = aduit.AduitName
                        });
                    }
                }
                return resultList;
            }
            #endregion

            return null;
        }

        public List<CorpAduitChangeModel> GetCorpAduitChangeInfoByProjectId(int projectId)
        {
            List<int> aduitIdList =
               _corpAduitConfigProjectDal.Query<CorpAduitConfigProjectEntity>(
                   n => projectId == n.ProjectId, true).Select(n => n.AduitId).ToList();//根据项目Id获取对应的审批信息

            if (aduitIdList == null || aduitIdList.Count == 0)
                return null;

            List<CorpAduitConfigEntity> aduitList = _corpPolicyConfigDal.Query<CorpAduitConfigEntity>(
                  n => aduitIdList.Contains(n.ConfigId) && n.IsDel == 0,
                  true).ToList();

            List<CorpAduitChangeModel> resultList=new List<CorpAduitChangeModel>();
            foreach (var entity in aduitList)
            {
                var aduit = aduitList.Find(n => n.ConfigId == entity.ConfigId);
                if (aduit != null)
                {
                    resultList.Add(new CorpAduitChangeModel()
                    {
                        AduitId = aduit.ConfigId,
                        AduitName = aduit.AduitName
                    });
                }
            }

            return resultList;
        }

        /// <summary>
        /// 获取当前公司下的除参数外的所有部门
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="removeDepartIdList"></param>
        /// <returns></returns>
        public List<CorpDepartmentModel> GetCorpDepart(string corpId, List<int> removeDepartIdList)
        {
            IQueryable<CorpDepartmentEntity> queryable =
                _corpDepartmentDal.Query<CorpDepartmentEntity>(n => n.CorpId.ToUpper() == corpId.ToUpper() && n.IsDel.ToUpper() == "F", true);
            if (removeDepartIdList != null && removeDepartIdList.Count > 0)
            {
                queryable = queryable.Where(n => !removeDepartIdList.Contains(n.Id)).AsNoTracking();
            }

            List<CorpDepartmentEntity> list = queryable.ToList();

            return Mapper.Map<List<CorpDepartmentEntity>, List<CorpDepartmentModel>>(list);
        }

        
    }
}
