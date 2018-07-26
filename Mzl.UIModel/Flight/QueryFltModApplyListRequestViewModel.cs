﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Flight
{
    public class QueryFltModApplyListRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public int? OrderId { get; set; }
        public DateTime? TackOffBeginTime { get; set; }
        public DateTime? TackOffEndTime { get; set; }
        public string OrderStatus { get; set; }
        /// <summary>
        /// 当前显示多少条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 第几页
        /// </summary>
        public int PageIndex { get; set; }

        public DateTime? OrderBeginTime { get; set; }
        public DateTime? OrderEndTime { get; set; }
        public string PassengerName { get; set; }

        /// <summary>
        /// 是否显示全部订单 用于公司订单的显示
        /// </summary>
        public int? IsShowAllOrder { get; set; }

        /// <summary>
        /// 是否是导出操作
        /// </summary>
        public int? IsExport { get; set; }
    }
}