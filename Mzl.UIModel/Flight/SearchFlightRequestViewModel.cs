using Mzl.UIModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    /// <summary>
    /// 查询航班View实体
    /// </summary>
    public class SearchFlightRequestViewModel : RequestBaseViewModel
    {
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? PolicyId { get; set; }
        /// <summary>
        /// 待预定乘客名称
        /// </summary>
        [Description("待预定乘客名称")]
        [Required]
        public List<string> PassengerNameList { get; set; }
        /// <summary>
        /// 待预定乘客证件信息
        /// </summary>
        [Description("待预定乘客证件信息")]
        [Required]
        public List<string> CardNoList { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        public string CorpId { get; set; }

        /// <summary>
        /// 出发机场三字码
        /// </summary>
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        [Description("出发机场三字码")]
        public string Dport { get; set; }

        /// <summary>
        /// 到达机场三字码
        /// </summary>
        [Required]
        [MaxLength(3)]
        [MinLength(3)]
        [Description("到达机场三字码")]
        public string Aport { get; set; }

        /// <summary>
        /// 出发日期
        /// </summary>
        [Required]
        [Description("出发日期")]
        public DateTime TackOffTime { get; set; }

        /// <summary>
        /// 航司二字码名称
        /// </summary>
        [MaxLength(2)]
        [MinLength(2)]
        [Description("航司二字码名称")]
        public string AirlineNo { get; set; }

    }
}
