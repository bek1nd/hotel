using System;
using System.Collections.Generic;
using System.Linq;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Customer.MatchCorpPolicyAndAduit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.MatchCorpPolicyAndAduit;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.MatchCorpPolicyAndAduit
{
    public class MatchCorpPolicyAndAduitServiceBll : BaseServiceBll, IMatchCorpPolicyAndAduitServiceBll
    {
        private readonly IGetCustomerBll _getCustomerBll;
        private readonly IChangeInfoFactory _changeInfoFactory;
        private readonly IProjectNameDal _projectNameDal;


        public MatchCorpPolicyAndAduitServiceBll(IGetCustomerBll getCustomerBll,
            IChangeInfoFactory changeInfoFactory, IProjectNameDal projectNameDal)
        {
            _getCustomerBll = getCustomerBll;
            _changeInfoFactory = changeInfoFactory;
            _projectNameDal = projectNameDal;
        }

        public MatchCorpPolicyAndAduitResultModel Match(MatchCorpPolicyAndAduitModel model)
        {
            BaseMatchBll matchBll = null;
            if (model.PassengerCidList == null || model.PassengerCidList.Count == 0) //都是临时客人的情况
            {
                CustomerModel bookingCustomerModel = _getCustomerBll.GetCustomerByCid(model.BookingCid);
                matchBll = new AllTemporaryBll(null, null, bookingCustomerModel, model.IsAllowUserInsurance);
            }
            else
            {
                //根据乘客人id获取部门Id
                List<CustomerModel> customerModels = _getCustomerBll.GetCustomerByCidList(model.PassengerCidList);
                List<int> departIdList = new List<int>();
                customerModels.ForEach(n =>
                {
                    if (n.CorpDepartID.HasValue)
                        departIdList.Add(n.CorpDepartID.Value);
                });

                departIdList = departIdList.Distinct().ToList();
                if (departIdList.Count == 1) //只有一个部门id,则认为是相同部门
                {
                    matchBll = new SameDepartmentBll(model.PassengerCidList, customerModels, model.IsAllowUserInsurance);
                }
                else
                {
                    matchBll = new DiffDepartmentBll(model.PassengerCidList, customerModels, model.IsAllowUserInsurance);
                }
            }

            IMatchVisitor matchVisitor = new MatchVisitor(_changeInfoFactory, _projectNameDal);

            return matchBll.DoMatch(matchVisitor);
        }



    }
}
