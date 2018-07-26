using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Base
{
    public abstract class RequestBaseViewModel
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 订单来源 A:Andriod，I:IOS，P:差旅线上网站 ，O：OA系统
        /// </summary>
        [Description("订单来源 A:Andriod，I:IOS，P:差旅线上网站 ，O：OA系统")]
        public string OrderSource { get; set; }
        /// <summary>
        /// 员工Id
        /// </summary>
        [Description("员工Id")]
        public string Oid { get; set; }
    }
}
