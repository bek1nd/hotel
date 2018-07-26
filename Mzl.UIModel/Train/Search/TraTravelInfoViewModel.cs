using System;
using System.Collections.Generic;
using System.ComponentModel;
using Mzl.UIModel.Search;

namespace Mzl.UIModel.Train.Search
{
    public class TraTravelInfoViewModel
    {

        /// <summary>
        /// 车票开售时间
        /// </summary>  
        [Description("火车票开售时间")]
        public string SaleDateTime { get; set; }


        /// <summary>
        /// 当前是否可以接受预定（Y：可以，N：不可以）
        /// </summary>  
        [Description("当前是否可以接受预定（Y：可以，N：不可以）")]
        public string CanBuyNow { get; set; }

        /// <summary>
        /// 列车从出发站到目的站的运行天数
        /// </summary>  
        [Description("列车从出发站到目的站的运行天数")]
        public string ArriveDays { get; set; }

        /// <summary>
        /// 列车从始发站出发的日期
        /// </summary>  
        [Description("列车从始发站出发的日期")]
        public string TrainStartDate { get; set; }

        /// <summary>
        /// 车次
        /// </summary>  
        [Description("车次")]
        public string TrainCode { get; set; }

        /// <summary>
        /// 是否可凭二代身份证直接进出站
        /// </summary>  
        [Description("是否可凭二代身份证直接进出站")]
        public string AccessByidCard { get; set; }

        /// <summary>
        /// 列车号
        /// </summary>  
        [Description("列车号")]
        public string TrainNo { get; set; }

        /// <summary>
        /// 列车类型
        /// </summary>  
        [Description("列车类型")]
        public string TrainType { get; set; }



        /// <summary>
        /// 出发车站名
        /// </summary>  
        [Description("出发车站名")]
        public string FromStationName { get; set; }


        /// <summary>
        /// 出发车站简码
        /// </summary>  
        [Description("出发车站简码")]
        public string FromStationCode { get; set; }


        /// <summary>
        /// 到达车站名
        /// </summary>  
        [Description("到达车站名")]
        public string ToStationName { get; set; }


        /// <summary>
        /// 到达车站简码
        /// </summary>  
        [Description("出发车站简码")]
        public string ToStationCode { get; set; }



        /// <summary>
        /// 列车始发站名
        /// </summary>  
        [Description("列车始发站名")]
        public string StartStationName { get; set; }




        /// <summary>
        /// 列车终到站名
        /// </summary>  
        [Description("列车终到站名")]
        public string EndStationName { get; set; }



        /// <summary>
        /// 出发时刻
        /// </summary>  
        [Description("出发时刻")]
        public string StartTime { get; set; }

        public string StartTimeHour =>!string.IsNullOrEmpty(StartTime) ? StartTime.Split(':')[0] : "0";
        /// <summary>
        /// 上车日期
        /// </summary>  
        [Description("上车日期")]
        public string OnTrainDate { get; set; }

        /// <summary>
        /// 上车星期
        /// </summary>  
        [Description("上车星期")]
        public string OnTrainWeek => "星期" + "日一二三四五六".Substring((int) Convert.ToDateTime(OnTrainDate).DayOfWeek, 1);

        /// <summary>
        /// 到达时刻
        /// </summary>  
        [Description("到达时刻")]
        public string ArriveTime { get; set; }
        public string ArriveTimeHour => !string.IsNullOrEmpty(ArriveTime) ? ArriveTime.Split(':')[0] : "0";
        /// <summary>
        /// 到达日期
        /// </summary>  
        [Description("到达日期")]
        public string ArriveDate
        {
            get { return Convert.ToDateTime(OnTrainDate).AddDays(Convert.ToInt32(ArriveDays)).ToString("yyyy-MM-dd"); }
        }

        /// <summary>
        /// 到达星期
        /// </summary>  
        [Description("到达星期")]
        public string ArriveWeek => "星期" + "日一二三四五六".Substring((int)Convert.ToDateTime(ArriveDate).DayOfWeek, 1);

        /// <summary>
        /// 历时
        /// </summary>  
        [Description("历时")]
        public string RunTime { get; set; }
        /// <summary>
        /// 历时格式化:45小时5分
        /// </summary>
        public string RunTimeDesc => RunTime.Replace(":", "小时") + "分";

        /// <summary>
        /// 历时分钟合计
        /// </summary>  
        [Description("历时分钟合计")]
        public string RunTimeMinute { get; set; }
        /// <summary>
        ///里程数
        /// </summary>  
        [Description("里程数")]
        public string Distance { get; set; }



        /// <summary>
        ///备注（起售时间）
        /// </summary>  
        [Description("备注（起售时间）")]
        public string Note { get; set; }





        /// <summary>
        /// 座位信息（数量，价格，描述）
        /// </summary>
        public List<TraTravelInfoDetailViewModel> DetailList { get; set; }



    }
}
