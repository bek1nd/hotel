using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraOrderSubmitResponseModel:BaseOutputModel
    {

        /// <summary>
        /// 车票开售时间
        /// </summary>  
        [Description("火车票开售时间")]
        public string orderid { get; set; }

        

    }
}
