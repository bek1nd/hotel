using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Search;

namespace Mzl.IApplication.Train
{
    /// <summary>
    /// 查询火车行程信息
    /// </summary>
    public interface ISearchTrainApplication : IBaseApplication
    {
        SearchTrainResponseViewModel SearchTrain(SearchTrainRequestViewModel request);
    }
}
