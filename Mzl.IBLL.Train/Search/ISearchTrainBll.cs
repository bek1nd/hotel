using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;

namespace Mzl.IBLL.Train.Search
{
    public interface ISearchTrainBll
    {
        List<TraTravelInfoModel> SearchTrain(TraQueryTrainModel model);
    }
}
