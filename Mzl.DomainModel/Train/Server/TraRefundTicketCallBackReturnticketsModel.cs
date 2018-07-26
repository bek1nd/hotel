using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mzl.DomainModel.Train.Server
{
    public class TraRefundTicketCallBackReturnticketsModel
    {
        public string ReturnSuccess { get; set; }
        public string ReturnFailid { get; set; }
        private string _passengername;
        public string Passengername
        {
            get
            {
                return string.IsNullOrEmpty(_passengername)
                    ? _passengername
                    : HttpUtility.UrlDecode(_passengername);
            }
            set { _passengername = value; }
        }
        public string Ticket_No { get; set; }
        public string ReturnMoney { get; set; }
        public string ReturnFailMsg { get; set; }
        public string Passportseno { get; set; }
        public string PassportTypeseid { get; set; }
        public string ReturnTime { get; set; }
    }
}
