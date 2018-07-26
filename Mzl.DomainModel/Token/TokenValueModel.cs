using Mzl.DomainModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Token
{
    public class TokenValueModel
    {
        /// <summary>
        /// Token状态
        /// </summary>
        public TokenResultEnum Status { get; set; }
        /// <summary>
        /// 登录用户ID
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 用户信息id
        /// </summary>
        public int? Cid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime=>DateTime.Now;
        /// <summary>
        /// Token来源 A:Andriod，I:IOS，P:差旅线上网站 ，O：OA系统
        /// </summary>
        public string FromSource { get; set; }
    }
}
