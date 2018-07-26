using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Train.Order
{
    public class TraModOrderDetailViewModel
    {
        /// <summary>
        /// 改签行程ID
        /// </summary>
        [Description("改签行程ID")]
        public int TravelId { get; set; }


        /// <summary>
        /// 车次
        /// </summary>
        [Description("车次")]
        public string TrainNo { get; set; }
        /// <summary>
        /// 出发站
        /// </summary>
        [Description("出发站")]
        public string AddrName { get; set; }
        /// <summary>
        /// 到达站
        /// </summary>
        [Description("到达站")]
        public string EndName { get; set; }
        /// <summary>
        /// 出发时间
        /// </summary>
        [Description("出发时间")]
        public DateTime? SendTime { get; set; }
        /// <summary>
        /// 抵达时间
        /// </summary>
        [Description("抵达时间")]
        public DateTime? EndTime { get; set; }


        /// <summary>
        /// 数量
        /// </summary>
        [Description("数量")]
        public int? TicketNum { get; set; }
        /// <summary>
        /// 票面价
        /// </summary>
        [Description("票面价")]
        public decimal? TrainMoney { get; set; }
        /// <summary>
        /// 卧铺/座位
        /// </summary>
        [Description("卧铺/座位")]
        public string PlaceType { get; set; }
        /// <summary>
        /// 等级
        /// </summary>
        [Description("等级")]
        public string PlaceGrade { get; set; }

        public List<TraPassengerViewModel> PassengerList { get; set; }

    }
}
