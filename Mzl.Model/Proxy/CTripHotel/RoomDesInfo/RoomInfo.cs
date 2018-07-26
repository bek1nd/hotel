using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomInfo
    {
        public ApplicabilityInfo ApplicabilityInfo { get; set; }
        public Smoking Smoking { get; set; }
        public BroadNet BroadNet { get; set; }
        public IList<RoomBedInfo> RoomBedInfos { get; set; }
        public RoomFGToPPInfo RoomFGToPPInfo { get; set; }
        public IList<RoomGiftInfo> RoomGiftInfos { get; set; }
        public ChannelLimit ChannelLimit { get; set; }
        public ExpressCheckout ExpressCheckout { get; set; }
        public IList<RoomTag> RoomTags { get; set; }
        public IList<BookingRule> BookingRules { get; set; }
        public IList<Description> Descriptions { get; set; }
        /// <summary>
        /// 售卖房型ID；
        /// 备注：售卖房型是真实售卖的房型，其父类为物理房型。同一个物理房型下，可以存在多个售卖房型。
        /// </summary>
        public int RoomID { get; set; }
        /// <summary>
        /// 售卖房型的名称
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// 售卖房型的数量
        /// </summary>
        public int RoomQuantity { get; set; }
        /// <summary>
        /// 最大入住人数
        /// </summary>
        public int MaxOccupancy { get; set; }
        /// <summary>
        /// 售卖房型的建筑面积
        /// </summary>
        public string AreaRange { get; set; }
        /// <summary>
        /// 售卖房型适用的楼层
        /// </summary>
        public int FloorRange { get; set; }
        /// <summary>
        /// 定义该售卖房型是否有窗：0-无窗；1-部分有窗；2-有窗；空-有窗；
        /// </summary>
        public int HasWindow { get; set; }
        /// <summary>
        /// 定义顾客是否需要支付额外加床费用：“Uknown”-不确定；空-不能加床；0-免费加床；若值大于0，则是所需额外加床费
        /// </summary>
        public double ExtraBedFee { get; set; }
        /// <summary>
        /// 该售卖房型是否是钟点房：True-是；False-否
        /// </summary>
        public bool IsHourlyRoom { get; set; }
        /// <summary>
        /// 定义该售卖房型是否是直连房型
        /// </summary>
        public bool IsFromAPI { get; set; }
        /// <summary>
        /// 是否展示代理商标签
        /// </summary>
        public bool IsShowAgencyTag { get; set; }
        /// <summary>
        /// 1-携程可提供发票；2-酒店可提供发票
        /// </summary>
        public int InvoiceType { get; set; }
        /// <summary>
        /// 酒店是否提供专票
        /// </summary>
        public string IsSupportSpecialInvoice { get; set; }
        /// <summary>
        /// 该售卖房型是否接受客人自定义备注：True-可接受；False-不接受 (默认)；
        /// </summary>
        public bool ReceiveTextRemark { get; set; }
    }
}
