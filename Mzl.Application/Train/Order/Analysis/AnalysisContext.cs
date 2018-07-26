using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Order;

namespace Mzl.Application.Train.Order.Analysis
{
    public class AnalysisContext
    {
        private string _analysisStr;
        private TraOrderDetailModel _detailModel =new TraOrderDetailModel();
        public AnalysisContext(string analysisStr)
        {
            _analysisStr = analysisStr;
        }

        public TraOrderDetailModel GetDetail()
        {
            return _detailModel;
        }

        public void SetDetail(TraOrderDetailModel detailModels)
        {
            _detailModel = detailModels;
        }

        public string GetAnalysisStr()
        {
            return _analysisStr;
        }
    }
}
