using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.EntityModel.Customer.Corporation.Project;
using Mzl.IBLL.Customer.MatchCorpPolicyAndAduit;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.MatchCorpPolicyAndAduit
{
    internal class MatchVisitor : IMatchVisitor
    {
        private readonly IChangeInfoFactory _changeInfoFactory;
        private readonly IProjectNameDal _projectNameDal;

        public MatchVisitor(IChangeInfoFactory changeInfoFactory, IProjectNameDal projectNameDal)
        {
            _changeInfoFactory = changeInfoFactory;
            _projectNameDal = projectNameDal;
        }

        /// <summary>
        /// 针对所有临时客人的匹配规则
        /// </summary>
        /// <param name="matchBll"></param>
        /// <returns></returns>
        public MatchCorpPolicyAndAduitResultModel DoMatch(AllTemporaryBll matchBll)
        {
            /**
             * 不存在冲突，允许下一步
             * 如果要选择差旅政策或审批规则，按照当前预定人的政策和审批规则
             * **/

            MatchCorpPolicyAndAduitResultModel resultModel = new MatchCorpPolicyAndAduitResultModel()
            {
                IsConflict = false,
                ChangeInfoList = new List<CorpPolicyAndAduitChangeModel>()
            };
            //按照当前预定人的政策和审批规则
            if (matchBll.BookingCustomerModel.CorpDepartID.HasValue &&
                !string.IsNullOrEmpty(matchBll.BookingCustomerModel.DepartmentName))
            {
                CorpPolicyAndAduitChangeModel changeInfo = new CorpPolicyAndAduitChangeModel();
                changeInfo.DepartmentId = matchBll.BookingCustomerModel.CorpDepartID;
                changeInfo.DepartmentName = matchBll.BookingCustomerModel.DepartmentName;
                changeInfo.CorpPolicyChangeList =
                    _changeInfoFactory.GetCorpPolicyChangeInfo(matchBll.BookingCustomerModel.Cid,
                        matchBll.BookingCustomerModel.CorpDepartID.Value, matchBll.IsAllowUserInsurance);
                changeInfo.CorpAduitChangeList =
                    _changeInfoFactory.GetCorpAduitChangeInfo(matchBll.BookingCustomerModel.Cid,
                        matchBll.BookingCustomerModel.CorpDepartID.Value);
                resultModel.ChangeInfoList.Add(changeInfo);

                //放开部门限制
                AddOtherChangeInfo(matchBll.BookingCustomerModel.CorpID,
                    new List<int>() {matchBll.BookingCustomerModel.CorpDepartID.Value}, resultModel.ChangeInfoList,
                    matchBll.IsAllowUserInsurance);


                #region 获取项目成本中心
                List<ProjectNameEntity> projectNameEntities = _projectNameDal.Query<ProjectNameEntity>(
                          n => n.CorpId.ToLower() == matchBll.BookingCustomerModel.CorpID.ToLower() && n.IsDelete == "F")
                          .ToList();
                List<int> projectIdList = projectNameEntities.Select(n => n.ProjectId)
                    .Distinct()
                    .ToList();



                if (projectIdList != null && projectIdList.Count > 0)
                {
                    resultModel.ProjectChangeInfoList = new List<CorpPolicyAndAduitChangeProjectModel>();

                    foreach (var projectId in projectIdList)
                    {
                        var project = projectNameEntities.Find(n => n.ProjectId == projectId);
                        CorpPolicyAndAduitChangeProjectModel p = new CorpPolicyAndAduitChangeProjectModel();
                        p.ProjectId = projectId;
                        p.ProjectName = project.ProjectName;
                        p.CorpPolicyChangeList =
                            _changeInfoFactory.GetCorpPolicyChangeInfoByProjectId(projectId,
                                matchBll.IsAllowUserInsurance);
                        p.CorpAduitChangeList = _changeInfoFactory.GetCorpAduitChangeInfoByProjectId(projectId);

                        resultModel.ProjectChangeInfoList.Add(p);
                    }
                } 
                #endregion

            }

          

            return resultModel;
        }
        /// <summary>
        /// 针对不同部门的匹配规则
        /// </summary>
        /// <param name="matchBll"></param>
        /// <returns></returns>
        public MatchCorpPolicyAndAduitResultModel DoMatch(DiffDepartmentBll matchBll)
        {
            /**
             * 存在冲突，不许下一步，必须变更规则
             * 获取所有部门下的规则信息
             */

            if (matchBll.CustomerList == null)
                throw new Exception("未找到乘客对应的信息");

            MatchCorpPolicyAndAduitResultModel resultModel = new MatchCorpPolicyAndAduitResultModel()
            {
                IsConflict = true,
                ChangeInfoList = new List<CorpPolicyAndAduitChangeModel>()
            };

            //循环遍历乘客信息,获取对应的差旅政策和审批规则
            List<int> departIdList = new List<int>();//部门id信息
            matchBll.CustomerList.ForEach(n => { departIdList.Add(n.CorpDepartID ?? 0); });
            departIdList = departIdList.Distinct().ToList();//去除重复部门id

            foreach (int departId in departIdList)//循环部门id
            {
                var changeInfo=GetChange(departId, matchBll.CustomerList, matchBll.IsAllowUserInsurance);
                resultModel.ChangeInfoList.Add(changeInfo);
            }

            //放开部门限制
            AddOtherChangeInfo(matchBll.CustomerList[0].CorpID, departIdList, resultModel.ChangeInfoList,
                matchBll.IsAllowUserInsurance);

            #region 获取项目成本中心
            string corpId = matchBll.CustomerList[0].CorpID.ToLower();
            List<ProjectNameEntity> projectNameEntities = _projectNameDal.Query<ProjectNameEntity>(
                      n => n.CorpId.ToLower() == corpId && n.IsDelete == "F")
                      .ToList();
            List<int> projectIdList = projectNameEntities.Select(n => n.ProjectId)
                .Distinct()
                .ToList();



            if (projectIdList != null && projectIdList.Count > 0)
            {
                resultModel.ProjectChangeInfoList = new List<CorpPolicyAndAduitChangeProjectModel>();

                foreach (var projectId in projectIdList)
                {
                    var project = projectNameEntities.Find(n => n.ProjectId == projectId);
                    CorpPolicyAndAduitChangeProjectModel p = new CorpPolicyAndAduitChangeProjectModel();
                    p.ProjectId = projectId;
                    p.ProjectName = project.ProjectName;
                    p.CorpPolicyChangeList =
                        _changeInfoFactory.GetCorpPolicyChangeInfoByProjectId(projectId,
                            matchBll.IsAllowUserInsurance);
                    p.CorpAduitChangeList = _changeInfoFactory.GetCorpAduitChangeInfoByProjectId(projectId);

                    resultModel.ProjectChangeInfoList.Add(p);
                }
            }
            #endregion

            return resultModel;
        }
        /// <summary>
        /// 针对同一部门的匹配规则
        /// </summary>
        /// <param name="matchBll"></param>
        /// <returns></returns>
        public MatchCorpPolicyAndAduitResultModel DoMatch(SameDepartmentBll matchBll)
        {
            /**
             如果当前乘客的差旅或者审批规则都一致，则不冲突；有冲突的时候，获取对应的乘客的差旅和审批规则
             */
            if (matchBll.CustomerList == null)
                throw new Exception("未找到乘客对应的信息");

            MatchCorpPolicyAndAduitResultModel resultModel = new MatchCorpPolicyAndAduitResultModel()
            {
                IsConflict = true,//默认冲突
                ChangeInfoList = new List<CorpPolicyAndAduitChangeModel>()
            };

            if (matchBll.CustomerList[0].CorpDepartID.HasValue)
            {
                var changeInfo = GetChange(matchBll.CustomerList[0].CorpDepartID.Value, matchBll.CustomerList, matchBll.IsAllowUserInsurance);
                resultModel.ChangeInfoList.Add(changeInfo);

                List<int> policyIdList = new List<int>();
                List<int> aduitIdList = new List<int>();

                if (changeInfo != null)
                {
                    if (changeInfo.CorpPolicyChangeList!=null&& changeInfo.CorpPolicyChangeList.Count>0)
                    {
                        changeInfo.CorpPolicyChangeList.ForEach(n => { policyIdList.Add(n.PolicyId); });
                    }

                    if (changeInfo.CorpAduitChangeList != null && changeInfo.CorpAduitChangeList.Count > 0)
                    {
                        changeInfo.CorpAduitChangeList.ForEach(n => { aduitIdList.Add(n.AduitId); });
                    }
                }

                if (policyIdList.Count == 1 && aduitIdList.Count == 1)//当前只存在一条政策并且一条审批规则的时候，设置不冲突
                {
                    resultModel.IsConflict = false;
                    resultModel.DefaultPolicyId = policyIdList[0];
                    resultModel.DefaultAduitId = aduitIdList[0];
                    resultModel.DefaultDepartmentId = resultModel.ChangeInfoList[0].DepartmentId;
                    resultModel.DefaultDepartmentName = resultModel.ChangeInfoList[0].DepartmentName;

                    var temp =
                        changeInfo?.CorpPolicyChangeList?.Find(n => n.PolicyId == resultModel.DefaultPolicyId.Value);

                    resultModel.DefaultInsuranceLimit = temp?.ViolateNPolicyValI;
                    resultModel.DefaultViolateTPolicyValQ = temp?.ViolateTPolicyValQ;
                    resultModel.DefaultViolateTPolicyValM = temp ?.ViolateTPolicyValM;
                    resultModel.DefaultViolateTPolicyValS = temp?.ViolateTPolicyValS;
                }

                if (policyIdList.Count == 0 && aduitIdList.Count == 0)//当政策和审批规则都不存在的时候，设置不冲突
                {
                    resultModel.IsConflict = false;
                }
                //放开部门限制
                AddOtherChangeInfo(matchBll.CustomerList[0].CorpID,
                    new List<int>() {matchBll.CustomerList[0].CorpDepartID.Value}, resultModel.ChangeInfoList,
                    matchBll.IsAllowUserInsurance);

                #region 获取项目成本中心

                string corpId = matchBll.CustomerList[0].CorpID.ToLower();
                List<ProjectNameEntity> projectNameEntities = _projectNameDal.Query<ProjectNameEntity>(
                    n => n.CorpId.ToLower() == corpId && n.IsDelete == "F")
                    .ToList();
                List<int> projectIdList = projectNameEntities.Select(n => n.ProjectId)
                    .Distinct()
                    .ToList();



                if (projectIdList != null && projectIdList.Count > 0)
                {
                    resultModel.ProjectChangeInfoList = new List<CorpPolicyAndAduitChangeProjectModel>();

                    foreach (var projectId in projectIdList)
                    {
                        var project = projectNameEntities.Find(n => n.ProjectId == projectId);
                        CorpPolicyAndAduitChangeProjectModel p = new CorpPolicyAndAduitChangeProjectModel();
                        p.ProjectId = projectId;
                        p.ProjectName = project.ProjectName;
                        p.CorpPolicyChangeList =
                            _changeInfoFactory.GetCorpPolicyChangeInfoByProjectId(projectId,
                                matchBll.IsAllowUserInsurance);
                        p.CorpAduitChangeList = _changeInfoFactory.GetCorpAduitChangeInfoByProjectId(projectId);

                        resultModel.ProjectChangeInfoList.Add(p);
                    }
                }
                #endregion
            }

            return resultModel;
        }



        private CorpPolicyAndAduitChangeModel GetChange(int departId, List<CustomerModel> customerList,int isAllowUserInsurance)
        {
            CorpPolicyAndAduitChangeModel changeModel = new CorpPolicyAndAduitChangeModel()
            {
                DepartmentId = departId
            };

            List<CustomerModel> customerModels = customerList.FindAll(n => n.CorpDepartID == departId);//获取部门对应的客户信息
            if (customerModels != null && customerModels.Count > 0)
            {
                changeModel.DepartmentName = customerModels[0].DepartmentName;

                List<CorpPolicyChangeModel> policyChangeList = new List<CorpPolicyChangeModel>();//政策池子
                List<CorpAduitChangeModel> aduitChangeList = new List<CorpAduitChangeModel>();//审批池子
                List<int> policyIdList = new List<int>();
                List<int> aduitIdList = new List<int>();

                foreach (var customerModel in customerModels)
                {
                    List<CorpPolicyChangeModel> policyChangeModels =
                        _changeInfoFactory.GetCorpPolicyChangeInfo(customerModel.Cid,
                            customerModel.CorpDepartID ?? 0, isAllowUserInsurance);
                    if (policyChangeModels != null && policyChangeModels.Count > 0)
                    {
                        policyChangeList.AddRange(policyChangeModels);//合并政策信息
                        policyChangeModels.ForEach(n => { policyIdList.Add(n.PolicyId); });
                    }

                    List<CorpAduitChangeModel> aduitChangeModels =
                        _changeInfoFactory.GetCorpAduitChangeInfo(customerModel.Cid, customerModel.CorpDepartID ?? 0);
                    if (aduitChangeModels != null && aduitChangeModels.Count > 0)
                    {
                        aduitChangeList.AddRange(aduitChangeModels);//合并审批规则信息
                        aduitChangeList.ForEach(n => { aduitIdList.Add(n.AduitId); });
                    }
                }

                //去除重复Id
                policyIdList = policyIdList.Distinct().ToList();
                aduitIdList = aduitIdList.Distinct().ToList();
                changeModel.CorpPolicyChangeList = new List<CorpPolicyChangeModel>();
                changeModel.CorpAduitChangeList = new List<CorpAduitChangeModel>();

                policyIdList.ForEach(n =>
                {
                    changeModel.CorpPolicyChangeList.Add(policyChangeList.Find(x => x.PolicyId == n));
                });
                aduitIdList.ForEach(n =>
                {
                    changeModel.CorpAduitChangeList.Add(aduitChangeList.Find(x => x.AduitId == n));
                });
            }

            return changeModel;
        }

        /// <summary>
        /// 获取除参数部门外的部门信息，并且根据这些部门信息获取审批与差旅政策，累加到当前ChangeInfoList上
        /// </summary>
        /// <param name="corpId"></param>
        /// <param name="removeDepartIdList"></param>
        /// <param name="changeInfoList"></param>
        /// <param name="isAllowUserInsurance"></param>
        private void AddOtherChangeInfo(string corpId,List<int> removeDepartIdList, List<CorpPolicyAndAduitChangeModel> changeInfoList,int isAllowUserInsurance)
        {
            if (changeInfoList == null)
                changeInfoList = new List<CorpPolicyAndAduitChangeModel>();

            List<CorpDepartmentModel> departmentModels =
                _changeInfoFactory.GetCorpDepart(corpId, removeDepartIdList);

            if (departmentModels != null && departmentModels.Count > 0)
            {
                foreach (var corpDepartmentModel in departmentModels)
                {
                    CorpPolicyAndAduitChangeModel otherChangeInfo = new CorpPolicyAndAduitChangeModel();

                    otherChangeInfo.DepartmentId = corpDepartmentModel.Id;
                    otherChangeInfo.DepartmentName = corpDepartmentModel.DepartName;
                    otherChangeInfo.CorpPolicyChangeList =
                        _changeInfoFactory.GetCorpPolicyChangeInfo(0, corpDepartmentModel.Id, isAllowUserInsurance);
                    otherChangeInfo.CorpAduitChangeList =
                        _changeInfoFactory.GetCorpAduitChangeInfo(0, corpDepartmentModel.Id);

                    changeInfoList.Add(otherChangeInfo);

                }
            }

        }
    }

}
