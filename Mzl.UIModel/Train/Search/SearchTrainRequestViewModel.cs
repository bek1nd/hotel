using System.ComponentModel;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.Search
{
    public class SearchTrainRequestViewModel: RequestBaseViewModel
    {

        /// <summary>
        /// 乘车日期（yyyy-MM-dd）
        /// </summary>  
        [Description("乘车日期（yyyy-MM-dd）")]
        public string TrainDate { get; set; }
        /// <summary>
        /// 出发站简码
        /// </summary>  
        [Description("出发站简码")]
        public string FromStation { get; set; }
        /// <summary>
        /// 到达站简码
        /// </summary>  
        [Description("到达站简码")]
        public string ToStation { get; set; }
        /// <summary>
        /// 订票类别
        /// </summary>  
        [Description("订票类别，固定值“ADULT”表示普通票")]
        public string PurposeCodes { get; set; } = "ADULT";
        /// <summary>
        /// 是否需要里程
        /// </summary>  
        [Description("是否需要里程(“1”需要；其他值不需要),默认为 0")]
        public string NeedDistance { get; set; } = "0";
        /// <summary>
        /// 差旅政策Id
        /// </summary>
        [Description("差旅政策Id")]
        public int? PolicyId { get; set; }
    }
}
