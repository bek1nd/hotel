using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Customer.AppClient;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Customer;
using Mzl.IDAL.Customer.Corporation;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.BLL.Customer.Customer
{
    public class AddSendAppMessageBll: BaseBll,IAddSendAppMessageBll
    {
        private readonly ISendAppMessageDal _sendAppMessageDal;
        private readonly ICustomerDal _customerDal;
        private readonly ICorporationDal _corporationDal;
        public AddSendAppMessageBll(ISendAppMessageDal sendAppMessageDal, ICustomerDal customerDal, ICorporationDal corporationDal)
        {
            _sendAppMessageDal = sendAppMessageDal;
            _customerDal = customerDal;
            _corporationDal = corporationDal;
        }


        public void AddAppMessage(SendAppMessageModel sendAppMessageModel)
        {
            //判断当前接受人是否是差旅客户
            CustomerInfoEntity customerInfoEntity = _customerDal.Find<CustomerInfoEntity>(sendAppMessageModel.Cid);
            if (string.IsNullOrEmpty(customerInfoEntity.CorpID))
            {
                return;
            }

            CorporationEntity corporationEntity =
                    _corporationDal.Query<CorporationEntity>(n => n.CorpId == customerInfoEntity.CorpID)
                        .FirstOrDefault();
            if (corporationEntity == null || corporationEntity.IsAmplitudeCorp != "T")
            {
                return;
            }

            SendAppMessageEntity sendAppMessageEntity =
                Mapper.Map<SendAppMessageModel, SendAppMessageEntity>(sendAppMessageModel);
            sendAppMessageEntity.CreateTime = DateTime.Now;
            _sendAppMessageDal.Insert(sendAppMessageEntity);
        }

       
    }
}
