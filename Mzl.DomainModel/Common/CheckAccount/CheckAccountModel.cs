using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Common.CheckAccount
{
    public class CheckAccountModel
    {
        public string Url { get; set; }
        /// <summary>
        /// 是否带*
        /// </summary>
        public bool IsHasXin { get; set; }
        /// <summary>
        /// 带*前的url地址
        /// </summary>
        public string BeforeXinUrl { get; set; }
    }
}
