using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.GrabTicket.KongTieInterface
{
    public class GrabTicketCancelResponseModel
    {
        public bool isSuccess { get; set; }
        public string code { get; set; }
        public string msg { get; set; }
    }
}
