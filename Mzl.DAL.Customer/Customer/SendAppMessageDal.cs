using System.Collections.Generic;
using System.Linq;
using Mzl.Framework.Base;
using Mzl.IDAL.Customer.Customer;

namespace Mzl.DAL.Customer.Customer
{
    public class SendAppMessageDal : BaseDal, ISendAppMessageDal
    {
        public List<T> GetAuditUrgeMessage<T>() where T : class
        {
            string sql = @"select distinct s.* from P_SendAppMessage (nolock) s
                                    left join P_CorpAduitOrder(nolock)a on s.OrderId=a.AduitOrderId
                                    left join P_CorpAduitOrder_Flow(nolock) af on af.AduitOrderId=a.AduitOrderId and af.FlowCid=s.Cid
                                    where orderType='AduitOrder' and SendType=2  --是待审批推送的审批单
                                    and s.SendStatus=1 --已经推送成功过
                                    and af.DealResult is null --没有进行审批处理
                                    and a.status>0 and a.status<>6 and a.status<>7 --审批没有结束
                                    and s.CreateTime>'20180503'
                                    and 
                                    (
                                    SendCount=1 and  dateadd(minute,5,s.SendLastTime)<GETDATE() --发送一次 间隔10分钟
                                    or
                                    SendCount=2 and  dateadd(minute,10,s.SendLastTime)<GETDATE() --发送第二次 间隔20分钟
                                    )";
            List<T> tList = base.ExcuteQueryBySql<T>(sql).ToList();
            return tList;
        }
    }
}
