using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Customer.Corporation
{
    public  class GetCorpIndividuationRequestViewModel: RequestBaseViewModel
    {
        [Description("公司Id")]
        [Required]
        public string CorpId { get; set; }

        /// <summary>
        /// 是否允许使用保险  0否 1是
        /// </summary>
        public int? IsAllowUserInsurance { get; set; }
        /// <summary>
        /// 共享航班显示  0否 1是
        /// </summary>
        public int? IsShareFly { get; set; }
        /// <summary>
        /// 协议价格是否单独展示  0否 1是
        /// </summary>
        public int? IsXYPrice { get; set; }
        /// <summary>
        /// 是否显示全部舱位  0否 1是
        /// </summary>
        public int? IsAllSeat { get; set; }
        /// <summary>
        /// 出行原因必填  0否 1是
        /// </summary>
        public int? IsTravelReason { get; set; }
        /// <summary>
        /// 短信验证控制  0否 1是
        /// </summary>
        public int? IsNoteVerify { get; set; }
        /// <summary>
        /// 最高舱位限制  0否 1是
        /// </summary>
        public int? IsHeightSeat { get; set; }
        /// <summary>
        /// 火车票是否显示全部坐席 0否 1是
        /// </summary>
        public int? IsTraAllSeat { get; set; }
    }
}
