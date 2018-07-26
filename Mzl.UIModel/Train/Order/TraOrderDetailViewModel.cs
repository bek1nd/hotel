using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraOrderDetailViewModel
    {
        public int OdId { get; set; }
        public int OrderId { get; set; }
        /// <summary>
        /// 出发站Id
        /// </summary>
        public int StartNameId { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        public string StartName { get; set; }
        /// <summary>
        /// 出发站Code
        /// </summary>
        public string StartNameCode { get; set; }
        /// <summary>
        /// 出发城市
        /// </summary>
        public string StartCity { get; set; }

        /// <summary>
        /// 到达站
        /// </summary>
        public string EndName { get; set; }
        /// <summary>
        /// 到达站Code
        /// </summary>
        public string EndNameCode { get; set; }
        /// <summary>
        /// 到达城市
        /// </summary>
        public string EndCity { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 上车时间
        /// </summary>
        public DateTime OnTrainTime { get; set; }

        /// <summary>
        /// 到达时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 车次
        /// </summary>
        public string TrainNo { get; set; }
        /// <summary>
        /// 席位
        /// </summary>
        public string PlaceType { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        public string PlaceGrade { get; set; }
        /// <summary>
        /// 票数
        /// </summary>
        public int TicketNum { get; set; }
        /// <summary>
        /// 票面价
        /// </summary>
        public decimal FacePrice { get; set; }
        /// <summary>
        /// 小计
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 退票供应商金额
        /// </summary>
        public decimal? SupplierMoney { get; set; }
        /// <summary>
        /// 退票手续费
        /// </summary>
        public decimal? RefundFee { get; set; }
        /// <summary>
        /// 座位等级编码
        /// </summary>
        public string PlaceGradeCode { get; set; }
        /// <summary>
        /// 出发站Code
        /// </summary>
        public string StartCode { get; set; }
        /// <summary>
        /// 到达站Code
        /// </summary>
        public string EndCode { get; set; }
        /// <summary>
        /// 退票扣率
        /// </summary>
        public decimal? RefundRate { get; set; }
        /// <summary>
        /// 取票单号
        /// </summary>
        public string TicketNo { get; set; }
        /// <summary>
        /// 违反差旅政策描述
        /// </summary>
        public string CorpPolicy { get; set; }
        /// <summary>
        /// 违反差旅政策原因
        /// </summary>
        public string ChoiceReason { get; set; }
        public List<TraPassengerViewModel> PassengerList { get; set; }
    }
}
