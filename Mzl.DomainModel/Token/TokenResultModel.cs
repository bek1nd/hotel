using Mzl.DomainModel.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Token
{
    public class TokenResultModel
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public TokenResultEnum Code { get; set; }
        /// <summary>
        /// Token信息
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public int? Cid { get; set; }
        /// <summary>
        /// 操作人Id
        /// </summary>
        public string Oid { get; set; }
    }
}
