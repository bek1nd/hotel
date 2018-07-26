using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraTrainInfoResponseDateModel
    {
        /// <summary>
        /// 官方系统的车次内部编码
        /// </summary>  
        [Description("官方系统的车次内部编码")]
        public string train_no { get; set; }

        /// <summary>
        /// 列车始发站名
        /// </summary>  
        [Description("列车始发站名")]
        public string start_station_name { get; set; }


        /// <summary>
        /// 列车终到站名
        /// </summary>  
        [Description("列车终到站名")]
        public string end_station_name { get; set; }


        /// <summary>
        /// 列车类型
        /// </summary>  
        [Description("列车类型")]
        public string train_type { get; set; }


        /// <summary>
        /// 车次号
        /// </summary>  
        [Description("车次号")]
        public string train_code { get; set; }


        /// <summary>
        /// 经停站信息
        /// </summary>  
        [Description("经停站信息")]
        public List<TraTrainInfoResponseDateDetailModel> data { get; set; }


        






    }
}
