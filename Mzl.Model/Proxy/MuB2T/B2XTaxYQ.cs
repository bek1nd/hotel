using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 税费查询条件
    /// </summary>
    public class B2XTaxYQ
    {
        /// <summary>
        /// 
        /// </summary>
        public List<PsgFare> pfList { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public string returnCode { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string returnMsg { get; set; }
        /// <summary>
        /// 售卖国家
        /// </summary>
        public string salesCountry { get; set; }
        /// <summary>
        /// 售卖币种
        /// </summary>
        public List<Segment> segList { get; set; }
        /// <summary>
        /// 订票时间
        /// </summary>
        public string ticketingDate { get; set; }
        #region 2017-09-06 新增字段
        /// <summary>
        /// 
        /// </summary>
        public string salesCurrency { get; set; }
        #endregion
    }
}
