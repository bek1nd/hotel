using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Mzl.DomainModel.Train.Order.OrderDetail
{
    public class GetTraOrderTravelModel
    {
        /// <summary>
        /// 行程Id
        /// </summary>
        [Description("行程Id")]
        public int OdId { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        [Description("出发站")]
        public string StartName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        [Description("火车订单号")]
        public string EndName { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        [Description("出发时间")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        [Description("到达时间")]
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        [Description("车次")]
        public string TrainNo { get; set; }
        /// <summary>
        /// 出发站Code
        /// </summary>
        [Description("出发站Code")]
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站Code
        /// </summary>
        [Description("到达站Code")]
        public string EndCode { get; set; }
        /// <summary>
        /// 违反差旅政策描述
        /// </summary>
        [Description("违反差旅政策描述")]
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 违反差旅政策原因
        /// </summary>
        [Description("违反差旅政策原因")]
        public string ChoiceReason { get; set; }
        /// <summary>
        /// 乘客信息集合
        /// </summary>
        [Description("乘客信息集合")]
        public List<GetTraOrderPassengerModel> PassengerList { get; set; }
    }
}
