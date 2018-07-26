using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.UIModel.Flight
{
    public class GetModApplyPassengerViewModel
    {
        /// <summary>
        /// 乘机人Id
        /// </summary>
        public int Pid { get; set; }
        /// <summary>
        /// 联系人Id
        /// </summary>
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
        /// 是否改签
        /// </summary>
        public bool IsMod { get; set; }
        /// <summary>
        /// 改签票号
        /// </summary>
        public List<string> ModTicketNoList { get; set; }
    }
}
