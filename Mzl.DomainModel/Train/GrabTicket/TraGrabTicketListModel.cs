using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.Train;

namespace Mzl.DomainModel.Train.GrabTicket
{
    public class TraGrabTicketListModel
    {
        public int TotalCount { get; set; }
        public List<TraGrabTicketListDataModel> DataList { get; set; }
        public SortedList<string, string> TrainGrabStatusList => EnumConvert.QueryEnumStr<TrainGrabStatusEnum>();

    }
}
