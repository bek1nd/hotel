using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Base;

namespace Mzl.UIModel.Train.GrabTicket
{
    public class TraGrabTicketListResponseViewModel
    {
        public int TotalCount { get; set; }
        public List<TraGrabTicketListDataViewModel> DataList { get; set; }
        public SortedList<string, string> TrainGrabStatusList { get; set; }

        public List<SortedListViewModel> TrainGrabStatusSelect
        {
            get
            {
                List<SortedListViewModel> list = new List<SortedListViewModel>();
                if (TrainGrabStatusList == null)
                    return list;

                foreach (var status in TrainGrabStatusList)
                {
                    SortedListViewModel l = new SortedListViewModel()
                    {
                        Key = status.Key,
                        Value = status.Value
                    };

                    list.Add(l);
                }

                return list;
            }
        }
    }
}
