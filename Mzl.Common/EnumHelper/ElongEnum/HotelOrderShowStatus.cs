using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    public enum HotelOrderShowStatus
    {
        [Description("担保失败")]
        GuaranteeFail = 1,
        [Description("等待担保")]
        WaitGuarantee = 2,
        [Description("等待确认")]
        WaitConfirm = 4,
        [Description("等待支付")]
        WaitPayment = 8,
        [Description("等待核实入住")]
        WaitCheckIn = 16,
        [Description("酒店拒绝订单")]
        HotelReject = 32,
        [Description("未入住")]
        NoShow = 64,
        [Description("已经离店")]
        Departure = 128,
        [Description("已经取消")]
        Cancel = 256,
        [Description("已经确认")]
        Confirmation = 512,
        [Description("已经入住")]
        CheckIn = 1024,
        [Description("担保处理中")]
        Guaranteeing = 2048,
        [Description("支付处理中")]
        Paying = 4096,
        [Description("支付失败")]
        PaymentFail = 8192
    }
}
