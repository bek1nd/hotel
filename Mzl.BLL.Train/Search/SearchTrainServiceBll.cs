using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.BLL.Train.RequestInterface;
using Mzl.Common.AutoMapperHelper;
using Mzl.Common.JsonHelper;
using Mzl.Common.LogHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Enum;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;
using Mzl.IBLL.Train.Search;

namespace Mzl.BLL.Train.Search
{
    internal class SearchTrainServiceBll : BaseServiceBll, ISearchTrainServiceBll
    {
        public List<TraTravelInfoModel> DoQueryTrain(TraQueryTrainModel model)
        {
            ISearchTrainBll searchTrainBll = new SearchKongTieTrainBll();//访问空铁无忧接口
            ISearchTrainBll policySearchTrainBll = new SearchContainPolicyTrainBll(searchTrainBll);//包装差旅政策
            return policySearchTrainBll.SearchTrain(model);
        }
    }
}
