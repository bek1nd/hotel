using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.IDAL.Customer.DAL;

namespace Mzl.BLL.Customer.ServiceFee.BLL
{
    public class ServiceFeeConfigBLL : IServiceFeeConfigBLL<ServiceFeeConfigModel>
    {
        private readonly IServiceFeeConfigDAL _dal;

        public ServiceFeeConfigBLL(IServiceFeeConfigDAL dal)
        {
            _dal = dal;
        }

        public ServiceFeeConfigModel GetServiceFeeConfigBySfcId(int sfcId)
        {
            ServiceFeeConfigEntity entity = _dal.Query(sfcId);
            if (entity == null)
                return null;
            return Mapper.Map<ServiceFeeConfigEntity, ServiceFeeConfigModel>(entity);
        }
    }
}
