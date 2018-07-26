using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Login;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.Customer
{
    public class AddAppClientIdServiceBll : BaseServiceBll, IAddAppClientIdServiceBll
    {
        private readonly ICustomerAppClientIdDal _customerAppClientIdDal;

        public AddAppClientIdServiceBll(ICustomerAppClientIdDal customerAppClientIdDal)
        {
            _customerAppClientIdDal = customerAppClientIdDal;
        }

        public int AddAppClientId(AddAppClientIdModel query)
        {
            //判断是否存在该设备信息
            CustomerAppClientIdEntity entity = _customerAppClientIdDal.Query<CustomerAppClientIdEntity>(
                n => n.Cid == query.Cid, true).FirstOrDefault();
          
            if (entity != null)
            {
                if (entity.ClientId != query.ClientId)
                {
                    //更新
                    entity.ClientId = query.ClientId;
                    entity.ClientType = query.ClientType;
                    entity.CreateTime=DateTime.Now;
                    _customerAppClientIdDal.Update(entity, new string[] { "ClientId", "ClientType", "CreateTime" });
                }
            }
            else
            {
                CustomerAppClientIdEntity customerAppClientIdEntity =
                    Mapper.Map<AddAppClientIdModel, CustomerAppClientIdEntity>(query);
                //新增
                customerAppClientIdEntity = _customerAppClientIdDal.Insert(customerAppClientIdEntity);
            }

            return 0;
        }

        public string GetAppClientId(int cid) {
            var entities = _customerAppClientIdDal.Query<CustomerAppClientIdEntity>(a => a.Cid == cid);
            if (entities.Any()) {
                return entities.First().ClientId;
            }
            return "";
        }
    }
}
