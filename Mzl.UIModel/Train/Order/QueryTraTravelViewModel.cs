using Mzl.UIModel.Customer.Corporation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Order
{
    public class QueryTraTravelViewModel
    {
        /// <summary>
        /// T是预订员 F非预订员
        /// </summary>
        public string IsMaster { get; set; }
        /// <summary>
        ///  差旅系统客户：T 是，F不是
        /// </summary>
        public string IsCorpSystemCustomer { get; set; }
        /// <summary>
        /// 部门信息 IsCorpSystemCustomer=T的时候
        /// </summary>
        public List<CorpDepartmentViewModel> DepartmentList { get; set; }
        /// <summary>
        /// 座位等级
        /// </summary>
        public List<SortedListViewModel> PlaceGradeList { get; set; }
    }
}
