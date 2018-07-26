using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Application.Train.Order.Analysis
{
    /// <summary>
    /// 火车12306订单格式解析器
    /// </summary>
    public abstract class AnalysisBasic
    {
        public abstract void DoAnalysis(AnalysisContext context);
    }
}
