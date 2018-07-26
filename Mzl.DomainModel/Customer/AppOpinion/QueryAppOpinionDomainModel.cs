using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.AppOpinion
{
    public class QueryAppOpinionDomainModel
    {
        /// <summary>
        /// 每页显示的行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 当前页数
        /// </summary>
        public int PageIndex { get; set; }
    }
}
