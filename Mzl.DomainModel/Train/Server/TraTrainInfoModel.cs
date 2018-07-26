using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
   public class TraTrainInfoModel:BaseInputModel
    {
        /// <summary>
        /// 乘车日期（yyyy-MM-dd）
        /// </summary>  
        [Description("乘车日期（yyyy-MM-dd）")]
        public string train_date { get; set; }


        /// <summary>
        /// 出发站简码
        /// </summary>  
        [Description("出发站简码")]
        public string from_station { get; set; }


        /// <summary>
        /// 到达站简码
        /// </summary>  
        [Description("到达站简码")]
        public string to_station { get; set; }




        /// <summary>
        /// 官方系统的车次内部编码
        /// </summary>  
        [Description("官方系统的车次内部编码")]
        public string train_no { get; set; }

        /// <summary>
        /// 车次号
        /// </summary>  
        [Description("车次号")]
        public string train_code { get; set; }










    }
}
