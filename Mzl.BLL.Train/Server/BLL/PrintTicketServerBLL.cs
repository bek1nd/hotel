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
    public class PrintTicketServerBLL : IPrintTicketServerBLL<TraPrintTicketCallBackLogModel>
    {


        private readonly IPrintTicketServerDALFactory factory;

        public PrintTicketServerBLL()
        {
        }

        public PrintTicketServerBLL(IPrintTicketServerDALFactory factory)
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

        public string ReceiveHoldTicketInof()
        {
            return PostHelper.ReceivePostInfo();
        }

        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("出票回调:" + logInfo, "CallBack");
        }

        public bool SavePrintTicketLog(TraPrintTicketCallBackLogModel t)
        {
            IPrintTicketServerDAL dal = factory.CreateSampleDalObj();
            //TraHoldSeatCallBackLogEntity log = new TraHoldSeatCallBackLogEntity {LogOriginalContent = "233333"};
            //将DomainModel转为DbModel
            TraPrintTicketCallBackLogEntity log2 =
                AutoMapperHelper.DoMap<TraPrintTicketCallBackLogModel, TraPrintTicketCallBackLogEntity>(t);
            List<TraPrintTicketCallBackLogModel> list = new List<TraPrintTicketCallBackLogModel>();
            list.Add(t);
            List<TraPrintTicketCallBackLogEntity> logList =
                (List<TraPrintTicketCallBackLogEntity>)AutoMapperHelper.DoMapList<TraPrintTicketCallBackLogModel, TraPrintTicketCallBackLogEntity>(list);
            dal.Insert(log2);
            //dal.Query(1);
            //log.Orderid = "3333323";
            //dal.Update(log);
            //dal.Delete(log);
            return true;
        }
    }
}
