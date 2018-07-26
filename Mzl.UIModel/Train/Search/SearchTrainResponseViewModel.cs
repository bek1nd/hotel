using System.Collections.Generic;
using System.ComponentModel;
using Mzl.UIModel.Search;

namespace Mzl.UIModel.Train.Search
{
    public class SearchTrainResponseViewModel
    {
        /// <summary>
        /// 火车行程信息
        /// </summary>
        [Description("火车行程信息")]
        public List<TraTravelInfoViewModel> TravelInfo;
        /// <summary>
        /// 出发站
        /// </summary>
        [Description("出发站")]
        public List<string> FormStation;
        /// <summary>
        /// 到达站
        /// </summary>
        [Description("到达站")]
        public List<string> ToStation;
        /// <summary>
        /// 火车类型
        /// </summary>
        [Description("火车类型")]
        public List<string> TrainType;
        /// <summary>
        /// 违规原因
        /// </summary>
        [Description("违规原因")]
        public List<string> PolicyReason { get; set; }
    }
}
