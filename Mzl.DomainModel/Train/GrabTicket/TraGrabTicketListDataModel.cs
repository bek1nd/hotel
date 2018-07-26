using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.Train;

namespace Mzl.DomainModel.Train.GrabTicket
{
    public class TraGrabTicketListDataModel : TraGrabTicketModel
    {
        public List<TraGrabTicketPassengerModel> PassengerList { get; set; }

        public string GrabStatusNow { get; set; }
        public string GrabStatusNowDesc => GrabStatusNow.NameToDescription<TrainGrabStatusEnum>();

        public string PassengerNameList { get; set; }
       
    }
}
