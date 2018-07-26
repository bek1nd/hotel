using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Token
{
    public class TokenModel
    {
        /// <summary>
        /// Token信息
        /// </summary>
        public string Token { get; set; }
        /// <summary>
        /// Value信息
        /// </summary>
        public TokenValueModel Value { get; set; }
        
    }
}
