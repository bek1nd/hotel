using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 国内B2C国际运价查询回传结果
    /// </summary>
    public class OdInfoOutput
    {
        /// <summary>
        /// 错误代码
        /// </summary>
        public string errId { get; set; }
        /// <summary>
        /// 错误代码描述
        /// </summary>
        public string errMsg { get; set; }
        /// <summary>
        /// 渠道代码
        /// </summary>
        public string channelNo { get; set; }
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
        /// 语言种类
        /// </summary>
        public string language { get; set; }
        /// <summary>
        /// 舱位等级
        /// </summary>
        public string cabinRank { get; set; }
        /// <summary>
        /// 旅客类型
        /// </summary>
        public string paxType { get; set; }
        /// <summary>
        /// 输出列表
        /// </summary>
        public List<RouteCombine> routeCombineList { get; set; }
        /// <summary>
        /// 政策促销码
        /// </summary>
        public string promotionCode { get; set; }
        /// <summary>
        /// 国际货币对人民币汇率
        /// </summary>
        public string exRate { get; set; }
        /// <summary>
        /// 万事达计算后返回结果解析
        /// </summary>
        public List<OdGiftFileInfo> odGiftList { get; set; }
    }
}
