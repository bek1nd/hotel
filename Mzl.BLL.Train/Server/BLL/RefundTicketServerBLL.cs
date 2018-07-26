using Mzl.Common.AutoMapperHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Train.Server;
using Mzl.EntityModel.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Train.Server.BLL
{
    public class RefundTicketServerBLL : IRefundTicketServerBLL<TraRefundTicketCallBackLogModel>
    {

        private readonly IRefundTicketServerDALFactory factory;

        public RefundTicketServerBLL()
        {
        }

        public RefundTicketServerBLL(IRefundTicketServerDALFactory factory)
        {
            this.factory = factory;
        }




        public string Data { get; set; }

        public string DoGetRequest()
        {
            throw new NotImplementedException();
        }

        public string DoPostRequest()
        {
            throw new NotImplementedException();
        }

        public string ReceiveRefundTicketInof()
        {
            return PostHelper.ReceivePostInfo();
        }

        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("退票回调:" + logInfo, "CallBack");
        }

        public bool SaveRefundTicketLog(TraRefundTicketCallBackLogModel t)
        {
            IRefundTicketServerDAL dal = factory.CreateSampleDalObj();
            //TraHoldSeatCallBackLogEntity log = new TraHoldSeatCallBackLogEntity {LogOriginalContent = "233333"};
            //将DomainModel转为DbModel
            TraRefundTicketCallBackLogEntity log2 =
                AutoMapperHelper.DoMap<TraRefundTicketCallBackLogModel, TraRefundTicketCallBackLogEntity>(t);
            List<TraRefundTicketCallBackLogModel> list = new List<TraRefundTicketCallBackLogModel>();
            list.Add(t);
            List<TraRefundTicketCallBackLogEntity> logList =
                (List<TraRefundTicketCallBackLogEntity>)AutoMapperHelper.DoMapList<TraRefundTicketCallBackLogModel, TraRefundTicketCallBackLogEntity>(list);
            dal.Insert(log2);
            //dal.Query(1);
            //log.Orderid = "3333323";
            //dal.Update(log);
            //dal.Delete(log);
            return true;
        }
    }
}
