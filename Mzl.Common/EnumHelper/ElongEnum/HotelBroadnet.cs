using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    public enum HotelBroadnet
    {
        [Description("无宽带")]
        None = 0,
        [Description("免费宽带")]
        FreeBroadnet = 1,
        [Description("收费宽带")]
        ChargeBroadnet = 2,
        [Description("免费WIFI")]
        FreeWLAN = 3,
        [Description("收费WIFI")]
        ChargeWLAN = 4
    }
}
