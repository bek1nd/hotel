using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 国内B2C国际运价查询条件
    /// </summary>
    public class OdInfoInput
    {
        /// <summary>
        /// 验证账号
        /// </summary>
        public string USR_ID { get; set; }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string USR_PWD { get; set; }
        /// <summary>
        /// 渠道代码
        /// </summary>
        public int? channelNo { get; set; }
        /// <summary>
        /// 目的币种
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 航程类型
        /// </summary>
        public string routeType { get; set; }
        /// <summary>
        /// 开票日期
        /// </summary>
        public string saleDate { get; set; }
        /// <summary>
        /// 舱位等级
        /// </summary>
        public string cabinRank { get; set; }
        /// <summary>
        /// 语言种类
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 旅客类型
        /// </summary>
        public string paxType { get; set; }
        /// <summary>
        /// 航程组合列表
        /// </summary>
        public List<RouteInfo> routeList { get; set; }
        /// <summary>
        /// 特殊运价代码
        /// </summary>
        public string specialFareCode { get; set; }
        /// <summary>
        /// 集团客户编号
        /// </summary>
        public string kamNo { get; set; }
        /// <summary>
        /// 查询类型
        /// </summary>
        public string queryType { get; set; }
        /// <summary>
        /// 是否增加税费的标注
        /// </summary>
        public bool? taxesFlag { get; set; }
        /// <summary>
        /// 促销代码
        /// </summary>
        public string promotionCode { get; set; }
    }
}
