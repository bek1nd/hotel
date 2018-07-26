using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Base
{
    public class BaseOrderListQueryModel
    {
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }
        public int? Cid { get; set; }
        public string UserId { get; set; }
        public string CorpId { get; set; }
        /// <summary>
        /// 该请求是否来自App
        /// </summary>
        public bool IsFromApp { get; set; }

        public CustomerModel Customer { get; set; }
        /// <summary>
        /// 线上允许显示开始时间
        /// </summary>
        public DateTime? AllowShowDataBeginTime
        {
            get
            {
                if (Customer == null)
                    return null;
                if (Customer.Corporation == null)
                    return null;
                if (!Customer.Corporation.AllowShowDataBeginTime.HasValue)
                    return null;
                return Customer.Corporation.AllowShowDataBeginTime.Value;
            }
        }
    }
}
