using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// B2T响应数据
    /// </summary>
    public class FlightSearchResponse
    {
        /// <summary>
        /// 返回信息类型
        /// </summary>
        public string msgTp { get; set; }
        /// <summary>
        /// 返回信息描述
        /// </summary>
        public string msgDesc { get; set; }
        /// <summary>
        /// 中转航班组合列表
        /// </summary>
        public List<OdFlightInfo> OdFlightInfo;
               
    }
}
