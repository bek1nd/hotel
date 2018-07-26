using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
 public  class TraRequestChangeTicketInfoModel
    {
        //passengersename:乘客姓名； passporttypeseid:证件类别编号； passportseno:证件号码 piaotype:票种类别 old_ticket_no:原车票票号

        /// <summary>
        /// 乘客姓名
        /// </summary>  
        [Description("乘客姓名")]
        public string passengersename { get; set; }


        /// <summary>
        /// 证件类别编号
        /// </summary>  
        [Description("证件类别编号")]
        public string passporttypeseid { get; set; }



        /// <summary>
        /// 证件号码
        /// </summary>  
        [Description("证件号码")]
        public string passportseno { get; set; }

        /// <summary>
        /// 票种类别
        /// </summary>  
        [Description("票种类别")]
        public string piaotype { get; set; }


        /// <summary>
        /// 原车票票号
        /// </summary>  
        [Description("原车票票号")]
        public string old_ticket_no { get; set; }








    }
}
