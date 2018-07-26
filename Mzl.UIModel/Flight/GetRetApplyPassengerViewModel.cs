using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetRetApplyPassengerViewModel
    {
        /// <summary>
        /// 乘机人Id
        /// </summary>
        public int Pid { get; set; }

        public int ContactId { get; set; }
        /// <summary>
        /// 乘机人名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 证件号
        /// </summary>
        public string CardNo { get; set; }
        /// <summary>
        /// 证件类型
        /// </summary>
        public string CardTypeDesc { get; set; }
        /// <summary>
        /// 退票申请行程
        /// </summary>
        public string RetApplyFlightLine { get; set; }
        /// <summary>
        /// 退票申请行程三字码
        /// </summary>
        public List<string> RetApplyDAportList { get; set; }
        /// <summary>
        /// 退票申请对应的票号信息
        /// </summary>
        public string RetApplyTicketNo { get; set; }
        /// <summary>
        /// 是否退票
        /// </summary>
        public bool IsRet { get; set; }
        /// <summary>
        /// 退票申请对应的行程
        /// </summary>
        public int RetApplySequence { get; set; }
        /// <summary>
        /// 退票申请航班
        /// </summary>
        public string RetApplyFlightNo { get; set; }
    }
}
