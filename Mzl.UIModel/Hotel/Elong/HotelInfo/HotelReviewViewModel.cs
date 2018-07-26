using System.ComponentModel;

namespace Mzl.UIModel.Hotel.Elong.HotelInfo
{
    public class HotelReviewViewModel
    {
        /// <summary>
        /// 评论总数
        /// </summary>
        [Description("评论总数")]
        public string Count { get; set; }

        /// <summary>
        /// 好评数
        /// </summary>
        [Description("好评数")]
        public string Good { get; set; }

        /// <summary>
        /// 差评数
        /// </summary>
        [Description("差评数")]
        public string Poor { get; set; }

        /// <summary>
        /// 好评率
        /// 如果是带%就是计算好的如94%；如果不带%就是一个数额需要自行再处理如0.94
        /// </summary>
        [Description("好评率")]
        public string Score { get; set; }
    }
}
