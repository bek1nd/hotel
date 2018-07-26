using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.XingA
{
    /// <summary>
    /// 响应数据实体
    /// </summary>
    public class XingAModel
    {
        /// <summary>
        /// 数据标识符
        /// </summary>        
        public int? ID { get; set; }
        /// <summary>
        /// 数据接收时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 数据代码:1-同步成功	0-同步失败
        /// </summary>
        public string msgCode { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string errMsg { get; set; }
        /// <summary>
        /// 未解密的数据
        /// </summary>
        public string EncryptGetData { get; set; }
        /// <summary>
        /// 解密后的数据
        /// </summary>
        public string DecryptGetData { get; set; }
        /// <summary>
        /// 推送信息是否已在内部OA系统创建订单:0-表示未创建，1-表示已创建
        /// </summary>
        public int? IsUseCreateOrder { get; set; }
    }
}
