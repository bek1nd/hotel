using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public class TraSearchOrderInfoModel:BaseInputModel
    {

        /// <summary>
        /// 开车时间
        /// </summary>  
        [Description("开车时间")]
        public string transactionid { get; set; }




        /// <summary>
        /// 开车时间
        /// </summary>  
        [Description("开车时间")]
        public string orderid { get; set; }


    }
}
