using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.EnumHelper.ElongEnum
{
    /// <summary>
    /// 性别
    /// </summary>
    public enum HotelGender
    {
        [Description("男")]
        Female,
        [Description("女")]
        Maile,
        [Description("保密")]
        Unknown,
    }
}
