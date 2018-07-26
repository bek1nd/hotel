using System;
using System.Collections.Generic;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.Base;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.IBLL.Customer.Customer;
using Mzl.IBLL.Customer.Customer.BLL;
using Mzl.IDAL.Customer.DAL;

namespace Mzl.BLL.Customer.Customer.BLL
{
    public class CustomerBLL : ICustomerBLL<CustomerInfoModel>, ICustomerUnionBLL<CustomerUnionInfoModel>
    {
        private readonly ICustomerInfoDAL _dal;
        private readonly ICustomerUnionInfoDAL _unionDal;
        public CustomerBLL(ICustomerInfoDAL dal)
        {
            _dal = dal;
        }

        public CustomerBLL(ICustomerUnionInfoDAL unionDal)
        {
            _unionDal = unionDal;
        }

        public CustomerInfoModel GetCustomerByCid(int cid)
        {
            CustomerInfoEntity customer = _dal.GetCustomerByExpression(n => n.Cid == cid);

            return Mapper.Map<CustomerInfoEntity, CustomerInfoModel>(customer);
        }

        public List<CustomerInfoModel> GetCustomerByDepartId(List<int> departIds)
        {
            List<CustomerInfoEntity> list =
                _dal.GetCustomerListByExpression(
                    n => n.CorpDepartID.HasValue && departIds.Contains(n.CorpDepartID.Value));
            if (list == null)
                return null;
            return Mapper.Map<List<CustomerInfoEntity>, List<CustomerInfoModel>>(list);
        }

        public List<CustomerInfoModel> GetCustomerByDepartId(int departId,string name="")
        {
            List<CustomerInfoEntity> list = null;
            if (string.IsNullOrEmpty(name))
            {
                list =
                    _dal.GetCustomerListByExpression(
                        n => n.CorpDepartID == departId && n.IsDel == "F" && n.IsLock == "F");
            }
            else
            {
                list =
                    _dal.GetCustomerListByExpression(
                        n =>
                            n.CorpDepartID == departId && n.RealName.Contains(name) && n.IsDel == "F" && n.IsLock == "F");
            }

            if (list == null)
                return null;
            return Mapper.Map<List<CustomerInfoEntity>, List<CustomerInfoModel>>(list);
        }

        public CustomerUnionInfoModel GetCustomerUnionByCid(int cid)
        {
            CustomerUnionInfoEntity customerUnionInfoEntity = _unionDal.Query(cid);
            if (customerUnionInfoEntity == null)
                return null;

            return Mapper.Map<CustomerUnionInfoEntity, CustomerUnionInfoModel>(customerUnionInfoEntity);
        }
    }
}
