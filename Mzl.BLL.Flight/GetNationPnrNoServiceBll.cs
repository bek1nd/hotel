using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Flight;
using Mzl.IDAL.Flight;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EmailHelper;

namespace Mzl.BLL.Flight
{
    public class GetNationPnrNoServiceBll : BaseServiceBll, IGetPnrNoServiceBll
    {
        private readonly IDoPnrNoBll _doPnrNoBll;
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;

        public GetNationPnrNoServiceBll(IDoPnrNoBll doPnrNoBll, IFltOrderDal fltOrderDal,
            IFltFlightDal fltFlightDal, IFltOrderLogDal fltOrderLogDal) 
        {
            _doPnrNoBll = doPnrNoBll;
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltOrderLogDal = fltOrderLogDal;
        }

        public string GetPnrNo(int orderid,string email)
        {
            string isServer = AppSettingsHelper.GetAppSettings(AppSettingsEnum.IsServer);
            if (isServer!="T")//如果不是生产环境，不定位
            {
                return string.Empty;
            }
            FltOrderEntity orderEntity = _fltOrderDal.Find<FltOrderEntity>(orderid);
            if ((orderEntity.ProcessStatus & 1) == 1)//如果已经定位，则不再定位
                return string.Empty;
            string pnrNo = _doPnrNoBll.DoPnrNo(orderid, orderEntity.CreateOid);
            if (!string.IsNullOrEmpty(pnrNo))
            {
                //定位成功之后，设置已定位
                orderEntity.ProcessStatus = orderEntity.ProcessStatus + 1;
                _fltOrderDal.Update(orderEntity, new string[] {"ProcessStatus"});
                _fltOrderLogDal.Insert(new FltOrderLogEntity()
                {
                    OrderId = orderEntity.OrderId,
                    LogTime = DateTime.Now,
                    LogType = "修改订单",
                    Oid = "sys",
                    Remark = "线上订单，设置已定位"+ pnrNo
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(email))
                {
                    string url = string.Format("http://192.168.1.188/orderprocess/Flt_order.asp?orderid={0}",
                                       orderid);
                    string content = string.Format("订单号:<a  href='{0}' >{1}</a>", url, orderid);
                    new TaskFactory().StartNew(() =>
                    {
                        EmailHelper.SendEmail("", "国内机票定位异常", null, null, content, email);
                    });
                }
            }
            return pnrNo;
        }
    }
}
