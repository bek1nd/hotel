using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.DomainModel.Train.Server
{
  public  class TraQueryTrainModel:BaseInputModel
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
        /// 订票类别
        /// </summary>  
        [Description("订票类别，固定值“ADULT”表示普通票")]
        public string purpose_codes { get; set; }
        /// <summary>
        /// 是否需要里程
        /// </summary>  
        [Description("是否需要里程(“1”需要；其他值不需要),默认为 0")]
        public string needdistance { get; set; }

        /// <summary>
        /// 公司Id
        /// </summary>
        public string CorpId { get; set; }
        /// <summary>
        /// 符合该客户查询航班的差旅政策信息
        /// </summary>
        public CorpPolicyDetailConfigModel CorpPolicy { get; set; }
        /// <summary>
        /// 火车票是否显示全部舱位 0否 1是
        /// </summary>
        public int? IsTraAllSeat { get; set; }
    }
}
