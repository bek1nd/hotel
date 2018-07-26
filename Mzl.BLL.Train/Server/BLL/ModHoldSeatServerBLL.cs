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
    public class ModHoldSeatServerBLL : IModHoldSeatServerBLL<TraModHoldSeatCallBackLogModel>
    {

        private readonly IModHoldSeatServerDALFactory factory;


        public ModHoldSeatServerBLL(IModHoldSeatServerDALFactory factory)
        {
            this.factory = factory;
        }

        public ModHoldSeatServerBLL()
        {
        }

        public string Data  { get; set; }

        public string DoGetRequest()
        {
            throw new NotImplementedException();
        }

        public string DoPostRequest()
        {
            throw new NotImplementedException();
        }

        public string ReceiveModHoldSeatInof()
        {
            return PostHelper.ReceivePostInfo();
        }

        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("改签占座回调:" + logInfo, "CallBack");
            LogHelper.WriteLog("改签占座回调:" + HttpUtility.UrlDecode(logInfo), "CallBack");
        }

        public bool SaveModHoldSeatLog(TraModHoldSeatCallBackLogModel t)
        {
            IModHoldSeatServerDAL dal = factory.CreateSampleDalObj();
            //TraHoldSeatCallBackLogEntity log = new TraHoldSeatCallBackLogEntity {LogOriginalContent = "233333"};
            //将DomainModel转为DbModel
            TraModHoldSeatCallBackLogEntity log2 =
                AutoMapperHelper.DoMap<TraModHoldSeatCallBackLogModel, TraModHoldSeatCallBackLogEntity>(t);
            List<TraModHoldSeatCallBackLogModel> list = new List<TraModHoldSeatCallBackLogModel>();
            list.Add(t);
            List<TraModHoldSeatCallBackLogEntity> logList =
                (List<TraModHoldSeatCallBackLogEntity>)AutoMapperHelper.DoMapList<TraModHoldSeatCallBackLogModel, TraModHoldSeatCallBackLogEntity>(list);
            dal.Insert(log2);
            //dal.Query(1);
            //log.Orderid = "3333323";
            //dal.Update(log);
            //dal.Delete(log);
            return true;
        }
    }
}
