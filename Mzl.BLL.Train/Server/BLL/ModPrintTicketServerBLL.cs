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
using System.Web;

namespace Mzl.BLL.Train.Server.BLL
{
    public class ModPrintTicketServerBLL : IModPrintTicketServerBLL<TraModPrintTicketCallBackLogModel>
    {



        private readonly IModPrintTicketServerDALFactory factory;

        public ModPrintTicketServerBLL()
        {
        }

        public ModPrintTicketServerBLL(IModPrintTicketServerDALFactory factory)
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

        public string ReceivePrintTicketInof()
        {
            return PostHelper.ReceivePostInfo();
        }

        public void SaveLog(string logInfo)
        {


            LogHelper.WriteLog("改签出票回调:" + logInfo, "CallBack");

            LogHelper.WriteLog("改签出票回调:" + HttpUtility.UrlDecode(logInfo), "CallBack");


        }

        public bool SaveModPrintTicketLog(TraModPrintTicketCallBackLogModel t)
        {
            IModPrintTicketServerDAL dal = factory.CreateSampleDalObj();
            //TraHoldSeatCallBackLogEntity log = new TraHoldSeatCallBackLogEntity {LogOriginalContent = "233333"};
            //将DomainModel转为DbModel
            TraModPrintTicketCallBackLogEntity log2 =
                AutoMapperHelper.DoMap<TraModPrintTicketCallBackLogModel, TraModPrintTicketCallBackLogEntity>(t);
            List<TraModPrintTicketCallBackLogModel> list = new List<TraModPrintTicketCallBackLogModel>();
            list.Add(t);
            List<TraModPrintTicketCallBackLogEntity> logList =
                (List<TraModPrintTicketCallBackLogEntity>)AutoMapperHelper.DoMapList<TraModPrintTicketCallBackLogModel, TraModPrintTicketCallBackLogEntity>(list);
            dal.Insert(log2);
            //dal.Query(1);
            //log.Orderid = "3333323";
            //dal.Update(log);
            //dal.Delete(log);
            return true;
        }
    }
}
