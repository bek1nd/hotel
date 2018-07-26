using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
   public class TraTrainInfoResponseModel:BaseOutputModel
    {
        
        /// <summary>
        /// 列车信息
        /// </summary>  
        [Description("列车信息")]
        public List<TraTrainInfoResponseDateModel> data { get; set; }


    }
}
