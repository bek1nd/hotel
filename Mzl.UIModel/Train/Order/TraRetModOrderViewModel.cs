using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Order
{
    public class TraRetModOrderViewModel
    {
        /// <summary>
        /// 订单来源
        /// </summary>
        public string OrderFrom { get; set; }
        /// <summary>
        /// 退改签信息
        /// </summary>
        public List<TraOrderDetailViewModel> TravelInfoList { get; set; }
        /// <summary>
        /// 座位等级
        /// </summary>
        public List<SortedListViewModel> PlaceGradeList { get; set; }
    }
}
