using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Train.Order
{
    public class TraPassengerViewModel
    {
        public int Pid { get; set; }
        public string Name { get; set; }
        public string CardNo { get; set; }
        public int CardNoType { get; set; }
        public string CardNoTypeDesc { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 车厢号
        /// </summary>
        public string PlaceCar { get; set; }
        /// <summary>
        /// 座位号
        /// </summary>
        public string PlaceSeatNo { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        public string TicketNo { get; set; }
        /// <summary>
        /// 改签后的票号
        /// </summary>
        public string ModTicketNo { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        public decimal? ServiceFee { get; set; }
        /// <summary>
        /// 票价
        /// </summary>
        public decimal? FacePrice { get; set; }
        /// <summary>
        /// 坐席
        /// </summary>
        public string PlaceGrade { get; set; }
        /// <summary>
        /// 乘车人状态
        /// </summary>
        public string PassengerStatus { get; set; }
        /// <summary>
        /// 是否退票
        /// </summary>
        public bool IsRefund { get; set; }
        /// <summary>
        /// 乘车人退票信息
        /// </summary>
        public TrainPassengerModRetTravelViewModel RefundTravelInfo { get; set; }

        /// <summary>
        /// 退票手续费
        /// </summary>
        public decimal? RefundFee { get; set; }
        /// <summary>
        /// 是否改签
        /// </summary>
        public bool IsMod { get; set; }
        /// <summary>
        /// 乘车人改签信息
        /// </summary>
        public TrainPassengerModRetTravelViewModel ModTravelInfo { get; set; }

        /// <summary>
        /// 乘车人类别
        /// </summary>
        public AgeTypeEnum AgeType { get; set; } = AgeTypeEnum.C;
        /// <summary>
        /// 联系人Id
        /// </summary>
        public int ContactId { get; set; }

    }
}
