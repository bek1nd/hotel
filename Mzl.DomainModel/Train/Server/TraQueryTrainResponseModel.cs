using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
   public class TraQueryTrainResponseModel:BaseOutputModel
    {


        /// <summary>
        /// searchkey
        /// </summary>  
        [Description("searchkey")]
        public string searchkey { get; set; }


        /// <summary>
        /// 查询信息
        /// </summary>  
        [Description("查询信息")]
        public List<TraQueryTrainResponseDateModel> data { get; set; }


    }
}
