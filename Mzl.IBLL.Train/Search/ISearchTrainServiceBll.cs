using System.Collections.Generic;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.Search
{
    public interface ISearchTrainServiceBll : IBaseServiceBll
    {
        List<TraTravelInfoModel> DoQueryTrain(TraQueryTrainModel model);
    }
}
