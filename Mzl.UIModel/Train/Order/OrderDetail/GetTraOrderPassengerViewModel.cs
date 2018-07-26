using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.UIModel.Train.Order.OrderDetail
{
    public class GetTraOrderPassengerViewModel
    {
        /// <summary>
        /// 乘客Id
        /// </summary>
        [Description("火车订单号")]
        public int Pid { get; set; }
        /// <summary>
        /// 乘客名称
        /// </summary>
        [Description("乘客名称")]
        public string Name { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        [Description("证件号码")]
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        [Description("证件类型")]
        public int CardNoType { get; set; }
        /// <summary>
        /// 证件类型描述
        /// </summary>
        [Description("证件类型描述")]
        public string CardNoTypeDesc { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Description("手机号码")]
        public string Mobile { get; set; }
        /// <summary>
        /// 车厢号
        /// </summary>
        [Description("车厢号")]
        public string PlaceCar { get; set; }
        /// <summary>
        /// 座位号
        /// </summary>
        [Description("座位号")]
        public string PlaceSeatNo { get; set; }
        /// <summary>
        /// 坐席
        /// </summary>
        [Description("坐席")]
        public string PlaceGrade { get; set; }
        /// <summary>
        /// 服务费
        /// </summary>
        [Description("服务费")]
        public decimal? ServiceFee { get; set; }
        /// <summary>
        /// 票价
        /// </summary>
        [Description("票价")]
        public decimal? FacePrice { get; set; }
        /// <summary>
        /// 乘车人状态
        /// </summary>
        [Description("乘车人状态")]
        public string PassengerStatus { get; set; }
        /// <summary>
        /// 乘车人类型 成人 儿童
        /// </summary>
        [Description("乘车人类型 成人 儿童")]

        public AgeTypeEnum AgeType { get; set; }
        /// <summary>
        /// 乘车人类型描述
        /// </summary>
        [Description("乘车人类型描述")]
        public string AgeTypeDes => AgeType.ToDescription();

        public string TravelRemark { get; set; }
    }
}
