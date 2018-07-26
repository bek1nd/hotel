using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 
    /// </summary>
    public class Segment
    {
        /// <summary>
        /// 仓位信息
        /// </summary>
        public string clazz { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string count { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        public string destcd { get; set; }
        /// <summary>
        /// 到达时间
        /// </summary>
        public string destdt { get; set; }
        /// <summary>
        /// 起飞地点
        /// </summary>
        public string orgcd { get; set; }
        /// <summary>
        /// 起飞时间
        /// </summary>
        public string orgdt { get; set; }
        /// <summary>
        /// 飞机类型
        /// </summary>
        public string planeType { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string segSeq { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Tax> segTax { get; set; }
        /// <summary>
        /// 航权类型
        /// </summary>
        public string segType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string stopover { get; set; }
    }
}
