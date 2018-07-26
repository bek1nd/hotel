using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;

namespace Mzl.DomainModel.Train.GrabTicket
{
    public class AddTraGrabTicketModel : TraGrabTicketModel
    {
        public string Depart { get; set; }
        public int? ProjectId { get; set; }
        public int? SendType { get; set; }
        public string OrderSource { get; set; }
        public string CName { get; set; }
        public string CMobile { get; set; }
        public string CEmail { get; set; }
        public string CPhone { get; set; }
        public string CFax { get; set; }
        public string SendAddress { get; set; }
        public decimal ServiceFee { get; set; }
        public DateTime? SendTime { get; set; }
        public DateTime? LastSendTime { get; set; }

        public List<TraGrabTicketPassengerModel> PassengerList { get; set; }
        public CustomerModel Customer { get; set; }
    }
}
