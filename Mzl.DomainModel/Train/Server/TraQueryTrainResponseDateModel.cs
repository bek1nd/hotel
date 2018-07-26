using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraQueryTrainResponseDateModel
    {

        /// <summary>
        /// 车票开售时间
        /// </summary>  
        [Description("火车票开售时间")]
        public string sale_date_time { get; set; }


        /// <summary>
        /// 当前是否可以接受预定（Y：可以，N：不可以）
        /// </summary>  
        [Description("当前是否可以接受预定（Y：可以，N：不可以）")]
        public string can_buy_now { get; set; }

        /// <summary>
        /// 列车从出发站到目的站的运行天数
        /// </summary>  
        [Description("列车从出发站到目的站的运行天数")]
        public string arrive_days { get; set; }


        /// <summary>
        /// 列车从始发站出发的日期
        /// </summary>  
        [Description("列车从始发站出发的日期")]
        public string train_start_date { get; set; }

        /// <summary>
        /// 车次
        /// </summary>  
        [Description("车次")]
        public string train_code { get; set; }

        /// <summary>
        /// 是否可凭二代身份证直接进出站
        /// </summary>  
        [Description("是否可凭二代身份证直接进出站")]
        public string access_byidcard { get; set; }

        /// <summary>
        /// 列车号
        /// </summary>  
        [Description("列车号")]
        public string train_no { get; set; }

        /// <summary>
        /// 列车类型
        /// </summary>  
        [Description("列车类型")]
        public string train_type { get; set; }



        /// <summary>
        /// 出发车站名
        /// </summary>  
        [Description("出发车站名")]
        public string from_station_name { get; set; }


        /// <summary>
        /// 出发车站简码
        /// </summary>  
        [Description("出发车站简码")]
        public string from_station_code { get; set; }


        /// <summary>
        /// 到达车站名
        /// </summary>  
        [Description("出发车站名")]
        public string to_station_name { get; set; }


        /// <summary>
        /// 到达车站简码
        /// </summary>  
        [Description("出发车站简码")]
        public string to_station_code { get; set; }



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
        /// 出发时刻
        /// </summary>  
        [Description("出发时刻")]
        public string start_time { get; set; }


        /// <summary>
        /// 到达时刻
        /// </summary>  
        [Description("到达时刻")]
        public string arrive_time { get; set; }



        /// <summary>
        /// 历时
        /// </summary>  
        [Description("历时")]
        public string run_time { get; set; }



        /// <summary>
        /// 历时分钟合计
        /// </summary>  
        [Description("历时分钟合计")]
        public string run_time_minute { get; set; }
        /// <summary>
        ///里程数
        /// </summary>  
        [Description("里程数")]
        public string distance { get; set; }



        /// <summary>
        ///备注（起售时间）
        /// </summary>  
        [Description("备注（起售时间）")]
        public string note { get; set; }



        /// <summary>
        /// 高级软卧余票数量
        /// </summary>  
        [Description("高级软卧余票数量")]
        public string gjrw_num { get; set; }


        /// <summary>
        /// 高级软卧票价
        /// </summary>  
        [Description("高级软卧票价")]
        public string gjrw_price { get; set; }



        /// <summary>
        /// 其他席别余票数量
        /// </summary>  
        [Description("其他席别余票数量")]
        public string qtxb_num { get; set; }



        /// <summary>
        /// 其他席别对应的票价
        /// </summary>  
        [Description("其他席别对应的票价")]
        public string qtxb_price { get; set; }



        /// <summary>
        /// 软卧(上)余票数量
        /// </summary>  
        [Description("软卧(上)余票数量")]
        public string rw_num { get; set; }



        /// <summary>
        /// 软卧(上)票价
        /// </summary>  
        [Description("软卧(上)票价")]
        public string rw_price { get; set; }



        /// <summary>
        /// 软卧(下)余票数量
        /// </summary>  
        [Description("软卧(下)余票数量")]
        public string rwx_num { get; set; }



        /// <summary>
        /// 软卧(下)票价
        /// </summary>  
        [Description("软卧(下)票价")]
        public string rwx_price { get; set; }




        /// <summary>
        /// 软座余票数量
        /// </summary>  
        [Description("软座余票数量")]
        public string rz_num { get; set; }



        /// <summary>
        /// 软座票价
        /// </summary>  
        [Description("软座票价")]
        public string rz_price { get; set; }


        /// <summary>
        /// 商务座的余票数据
        /// </summary>  
        [Description("商务座的余票数据")]
        public string swz_num { get; set; }



        /// <summary>
        /// 商务座票价
        /// </summary>  
        [Description("商务座票价")]
        public string swz_price { get; set; }



        /// <summary>
        /// 特等座的余票数据
        /// </summary>  
        [Description("特等座的余票数据")]
        public string tdz_num { get; set; }



        /// <summary>
        /// 特等座票价
        /// </summary>  
        [Description("特等座票价")]
        public string tdz_price { get; set; }



        /// <summary>
        /// 无座余票数据
        /// </summary>  
        [Description("无座余票数据")]
        public string wz_num { get; set; }



        /// <summary>
        /// 无座票价
        /// </summary>  
        [Description("无座票价")]
        public string wz_price { get; set; }

        /// <summary>
        /// 动卧余票数据
        /// </summary>  
        [Description("动卧（上）余票数据")]
        public string dw_num { get; set; }



        /// <summary>
        /// 动卧票价
        /// </summary>  
        [Description("动卧（上）票价")]
        public string dw_price { get; set; }


        /// <summary>
        /// 动卧票价
        /// </summary>  
        [Description("动卧（下）票价")]
        public string dwx_price { get; set; }


        /// <summary>
        /// 硬卧(上)余票数量
        /// </summary>  
        [Description("硬卧(上)余票数量")]
        public string yw_num { get; set; }



        /// <summary>
        /// 硬卧(上)票价
        /// </summary>  
        [Description("硬卧(上)票价")]
        public string yw_price { get; set; }


        /// <summary>
        /// 硬卧(中)余票数量
        /// </summary>  
        [Description("硬卧(中)余票数量")]
        public string ywz_num { get; set; }



        /// <summary>
        /// 硬卧(中)票价
        /// </summary>  
        [Description("硬卧(中)票价")]
        public string ywz_price { get; set; }




        /// <summary>
        /// 硬卧(下)余票数量
        /// </summary>  
        [Description("硬卧(下)余票数量")]
        public string ywx_num { get; set; }



        /// <summary>
        /// 硬卧(下)票价
        /// </summary>  
        [Description("硬卧(下)票价")]
        public string ywx_price { get; set; }




        /// <summary>
        /// 硬座余票数量
        /// </summary>  
        [Description("硬座余票数量")]
        public string yz_num { get; set; }



        /// <summary>
        /// 硬卧票价
        /// </summary>  
        [Description("硬座票价")]
        public string yz_price { get; set; }



        /// <summary>
        /// 二等座余票数量
        /// </summary>  
        [Description("二等座余票数量")]
        public string edz_num { get; set; }



        /// <summary>
        /// 二等座票价
        /// </summary>  
        [Description("二等座票价")]
        public string edz_price { get; set; }


        /// <summary>
        ///一等座余票数量
        /// </summary>  
        [Description("一等座余票数量")]
        public string ydz_num { get; set; }



        /// <summary>
        ///一等座票价
        /// </summary>  
        [Description("一等座票价")]
        public string ydz_price { get; set; }


       





    }
}
