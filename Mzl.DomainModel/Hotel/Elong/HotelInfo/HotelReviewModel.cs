namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class HotelReviewModel
    {
        /// <summary>
        /// 评论总数
        /// </summary>
        public string Count { get; set; }

        /// <summary>
        /// 好评数
        /// </summary>
        public string Good { get; set; }

        /// <summary>
        /// 差评数
        /// </summary>
        public string Poor { get; set; }

        /// <summary>
        /// 好评率
        /// 如果是带%就是计算好的如94%；如果不带%就是一个数额需要自行再处理如0.94
        /// </summary>
        public string Score { get; set; }
    }
}
