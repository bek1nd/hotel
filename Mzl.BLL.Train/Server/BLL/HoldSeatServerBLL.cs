using System;
using Mzl.DomainModel.Train.Server;
using Mzl.EntityModel.Train.Server;
using Mzl.IBLL.Train.Server;
using Mzl.IBLL.Train.Server.BLL;
using Mzl.IDAL.Train.Server;
using Mzl.IDAL.Train.Server.DAL;
using Mzl.IDAL.Train.Server.Factory;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using System.Collections.Generic;

namespace Mzl.BLL.Train.Server.BLL
{
    public class HoldSeatServerBLL : IHoldSeatServerBLL<TraHoldSeatCallBackLogModel>
    {
        private readonly IHoldSeatServerDALFactory factory;


        public HoldSeatServerBLL(IHoldSeatServerDALFactory factory)
        {
            this.factory = factory;
        }

        public HoldSeatServerBLL()
        {
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

        

        public string ReceiveHoldSeatInof()
        {
            return PostHelper.ReceivePostInfo();
        }

        public bool SaveHoldSeatLog(TraHoldSeatCallBackLogModel t)
        {
            IHoldSeatServerDAL dal = factory.CreateSampleDalObj();
            //TraHoldSeatCallBackLogEntity log = new TraHoldSeatCallBackLogEntity {LogOriginalContent = "233333"};
            //将DomainModel转为DbModel
            TraHoldSeatCallBackLogEntity log2 =
                AutoMapperHelper.DoMap<TraHoldSeatCallBackLogModel, TraHoldSeatCallBackLogEntity>(t);
            List<TraHoldSeatCallBackLogModel> list=new List<TraHoldSeatCallBackLogModel>();
            list.Add(t);
            List<TraHoldSeatCallBackLogEntity> logList =
                (List<TraHoldSeatCallBackLogEntity>) AutoMapperHelper.DoMapList<TraHoldSeatCallBackLogModel, TraHoldSeatCallBackLogEntity>(list);
            dal.Insert(log2);
            //dal.Query(1);
            //log.Orderid = "3333323";
            //dal.Update(log);
            //dal.Delete(log);
            return true;
        }

        public void SaveLog(string logInfo)
        {
            LogHelper.WriteLog("占座回调:" + logInfo, "CallBack");
        }
    }
}
