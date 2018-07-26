using Mzl.Common.EnumHelper;
using System;

namespace Mzl.DomainModel.Customer.Login
{
    /// <summary>
    /// 客户登录信息模型
    /// </summary>
    public class CustomerLoginModel
    {
        /// <summary>
        /// 公司ID
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 登录id
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Token信息
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 设备Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 客户端类型
        /// </summary>
        public string ClientType { get; set; }


        /// <summary>
        /// 是否检测ClientId，如果为空，则默认为否
        /// 
        /// 如果否，则直接覆盖原先ClientId；
        /// 如果是，则如果ClientId与原先不同，需要短信验证
        /// </summary>
        public Nullable<bool> IsCheckClientId { get; set; }
    }
}
