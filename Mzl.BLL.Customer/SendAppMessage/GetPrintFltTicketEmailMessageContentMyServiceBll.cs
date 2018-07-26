using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.IDAL.Customer.DAL;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.EntityModel.Operator;
using Mzl.Common.ConfigHelper;

namespace Mzl.BLL.Customer.SendAppMessage
{
    public class GetPrintFltTicketEmailMessageContentMyServiceBll : BaseServiceBll, IGetPrintFltTicketEmailMessageContentMyServiceBll
    {
        private readonly ICustomerInfoDAL _customerInfoDal;
        private readonly ICorporationDAL _corporationDal;
        public GetPrintFltTicketEmailMessageContentMyServiceBll(ICustomerInfoDAL customerInfoDAL, ICorporationDAL corporationDal)
        {
            _customerInfoDal = customerInfoDAL;
            _corporationDal = corporationDal;
        }
        public void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels)
        {
            
            foreach (var item in sendAppMessageModels)
            {
                CustomerInfoEntity customerInfoEntity = _customerInfoDal.GetCustomerByExpression(x => x.Cid == item.Cid);
                CorporationEntity corporationEntity = _corporationDal.GetContactInfoByExpression(x => x.CorpId == customerInfoEntity.CorpID);
                OperatorEntity operatorEntity =
                                   base.Context.Set<OperatorEntity>().Where(n =>
                                       n.Oid.ToUpper() == corporationEntity.ResponsibleOid).FirstOrDefault();
                item.Email = operatorEntity?.Email;
                
                item.SendContent = corporationEntity.CorpName + " 公司已生成订单 " + item.OrderId + "，请差旅顾问及时处理！";
            }
        }
    }
}
