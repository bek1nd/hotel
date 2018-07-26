using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel
{
    /// <summary>
    /// 返回状态
    /// </summary>
    public  class ResponseStatusEntity
    {
        /// <summary>
        /// 请求时间戳
        /// </summary>
        public string Timestamp { get; set; }

        /// <summary>
        /// 请求成功标志
        /// </summary>
        public string Ack { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public IList<Error> Errors { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Build { get; set; }

        /// <summary>
        /// 请求接口版本号
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IList<Extension> Extension;
    }
}
