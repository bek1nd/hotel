using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
 public   class TraTrainInfoResponseDateDetailModel
    {
        /// <summary>
        /// 列车从出发站到达目的站的运行天数 0： 当日到达， 1：次日到达，2：三日到达，3：四日到达，依此类推
        /// </summary>  
        [Description("列车从出发站到达目的站的运行天数 0： 当日到达， 1：次日到达，2：三日到达，3：四日到达，依此类推")]
        public string arrive_days { get; set; }


        /// <summary>
        /// 参考官方站点顺序从 1 开始编排
        /// </summary>  
        [Description("参考官方站点顺序从 1 开始编排")]
        public string station_no { get; set; }

        /// <summary>
        /// 车站名
        /// <summary>
        [Description("车站名")]
        public string station_name { get; set; }

        
        /// <summary>
        /// 到站时刻
        /// <summary>
        [Description("到站时刻")]
        public string arrive_time { get; set; }

        /// <summary>
        /// 经停站信息
        /// <summary>
        [Description("经停站信息")]
        public string start_time { get; set; }


        /// <summary>
        /// 经停时间
        /// <summary>
        [Description("经停时间")]
        public string stopover_time { get; set; }



    }
}
