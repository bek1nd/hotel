using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Enum
{
    /*
     当Token状态为0的时候，代表可以访问系统Api
     为1的时候，只能访问MojoryLogin的Api，其余跳转到登录页面
     为2的时候，静止访问一切Api，跳转登录页面
         */
    public enum TokenResultEnum
    {
        /// <summary>
        /// 允许访问
        /// </summary>
        [Description("允许访问")]
        Allow = 0,
        /// <summary>
        /// 初始状态
        /// </summary>
        [Description("初始状态")]
        Initial = 1,
        /// <summary>
        ///不许访问
        /// </summary>
        [Description("不许访问")]
        NoAllow = 2,
        /// <summary>
        ///已更换手机设备
        /// </summary>
        [Description("已更换手机设备")]
        MobileChanged =3
    }
}
