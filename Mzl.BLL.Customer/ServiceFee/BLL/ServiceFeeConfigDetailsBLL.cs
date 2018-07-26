using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.IDAL.Customer.DAL;

namespace Mzl.BLL.Customer.ServiceFee.BLL
{
    public class ServiceFeeConfigDetailsBLL: IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel>
    {
        private readonly IServiceFeeConfigDetailsDAL _dal;

        public ServiceFeeConfigDetailsBLL(IServiceFeeConfigDetailsDAL dal)
        {
            _dal = dal;
        }

        public List<ServiceFeeConfigDetailsModel> GetServiceFeeConfigDetailsBySfcId(int sfcId)
        {
            List<ServiceFeeConfigDetailsEntity> serviceFeeConfigDetailsEntities =
                _dal.GetServiceFeeConfigDetailsListByExpression(n => n.SfcId == sfcId);
            if (serviceFeeConfigDetailsEntities == null)
                return null;
            return Mapper.Map < List<ServiceFeeConfigDetailsEntity>, List<ServiceFeeConfigDetailsModel>>(serviceFeeConfigDetailsEntities);
        }
    }
}
