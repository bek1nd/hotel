using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Server
{
 public   class RefundTicketDetailModel
    {
        /// <summary>
        /// 车票号
        /// <summary>
        [Description("车票号")]
        public string ticket_no { get; set; }



        /// <summary>
        /// 乘车人姓名
        /// <summary>
        [Description("乘车人姓名")]
        public string passengername { get; set; }


        /// <summary>
        /// 乘车人证件类型ID
        /// <summary>
        [Description("乘车人证件类型ID")]
        public string passporttypeseid { get; set; }



        /// <summary>
        /// 乘车人证件号码
        /// <summary>
        [Description("乘车人证件号码")]
        public string passportseno { get; set; }



    }
}
