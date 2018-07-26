using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Register
{
    public class RegisterCustomerModel
    {

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CorpName { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Connector { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string ConnectTel { get; set; }

        /// <summary>
        /// 公司规模
        /// </summary>
        public string CorpScale { get; set; }

        /// <summary>
        /// 行业
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// 差旅体量
        /// </summary>
        public string TripScale { get; set; }
    }
}
