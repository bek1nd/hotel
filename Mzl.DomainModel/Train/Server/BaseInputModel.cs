using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
   public  class BaseInputModel
    {

        /// <summary>
        /// 账号（非空）
        /// </summary>  
       [Description("账号（非空）")]
        public string partnerid { get; set; }


        /// <summary>
        /// 操作功能名
        /// </summary>  
        [Description("操作功能名（非空）")]
        public string method { get; set; }

        /// <summary>
        /// 请求时间
        /// </summary>  
        [Description("请求时间，格式：yyyyMMddHHmmss（非空）")]
        public string reqtime { get; set; }

        /// <summary>
        /// 数字签名
        /// </summary>  
        [Description("数字签名=m1d05(PartnerID+Method+Reqtime+md5(key))，)，其中 key 由我方分配。md5 算法得到的字符串全部为小写")]
        public string sign { get; set; }





    }
}
