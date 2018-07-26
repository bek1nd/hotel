using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Customer.Login
{
    public class AddAppClientIdModel
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 设备Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 客户端类型
        /// </summary>
        public string ClientType { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime=>DateTime.Now;
    }
}
