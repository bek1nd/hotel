using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.Train;

namespace Mzl.DomainModel.Train.GrabTicket
{
    public class TraGrabTicketModel
    {
        public int GrabId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int? Cid { get; set; }
        /// <summary>
        /// 创建人Id
        /// </summary>
        public string CreateOid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 抢票任务开始时间
        /// </summary>
        public DateTime GrabBeginTime { get; set; }
        /// <summary>
        /// 抢票任务结束时间
        /// </summary>
        public DateTime GrabEndTime { get; set; }
        /// <summary>
        /// 出发站三字码
        /// </summary>
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站三字码
        /// </summary>
        public string EndCode { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        public string StartCodeName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        public string EndCodeName { get; set; }
        /// <summary>
        /// 出发日期
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 抢票的具体车次，以“,”隔开
        /// </summary>
        public string TrainNo { get; set; }

        /// <summary>
        /// 车次类型，与具体车次对应；Q表示其他类型，包括临客，数字列车等
        /// </summary>
        public string TrainType
        {
            get
            {
                if (string.IsNullOrEmpty(TrainNo))
                    return string.Empty;

                List<string> trainNoList = TrainNo.Split(',').ToList();
                List<string> tempList = new List<string>()
                {
                    "K",
                    "T",
                    "C",
                    "Z",
                    "L",
                    "A",
                    "Y",
                    "D",
                    "G"
                };

                List<string> resultList = new List<string>();

                foreach (string trainNo in trainNoList)
                {
                    if(trainNo.Length<2)
                        continue;
                    string trainCode = trainNo.Substring(0, 1);
                    if (!tempList.Contains(trainCode))
                        resultList.Add("Q");
                    else
                        resultList.Add(trainCode);
                }

                if (resultList.Count == 0)
                    return string.Empty;

                resultList = resultList.Distinct().ToList();
                string s = "";
                foreach (string result in resultList)
                {
                    s += "," + result;
                }

                return s.Substring(1);
            }
        }

        /// <summary>
        /// 座位类型
        /// </summary>
        public string SeatType { get; set; }
        /// <summary>
        /// 是否要无座票
        /// </summary>
        public bool IsNeedNoSeatTicket { get; set; }
        /// <summary>
        /// 抢票状态 W提交抢票 P抢票中 S抢票成功 F抢票失败 C抢票取消 D提交抢票失败
        /// </summary>
        public TrainGrabStatusEnum GrabStatus { get; set; }

        public string GrabStatusDesc => GrabStatus.ToDescription();
        /// <summary>
        /// 火车订单号
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// 提交抢票失败原因
        /// </summary>
        public string SubmitFailedReason { get; set; }
        /// <summary>
        /// 抢票失败原因
        /// </summary>
        public string GrabFailedReason { get; set; }
    }
}
