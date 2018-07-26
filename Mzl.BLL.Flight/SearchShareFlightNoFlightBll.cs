using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight
{
    /// <summary>
    /// 共享航班处理
    /// </summary>
    public class SearchShareFlightNoFlightBll : ISearchFlightServiceBll
    {
        private readonly ISearchFlightServiceBll _searchContainPolicyFlightBll;

        public SearchShareFlightNoFlightBll(ISearchFlightServiceBll searchContainPolicyFlightBll)
        {
            _searchContainPolicyFlightBll = searchContainPolicyFlightBll;
        }

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            List<SearchFlightModel> ibeFlightModels = _searchContainPolicyFlightBll.SearchFlight(query);
            List<SearchFlightModel> filterSearchlist = new List<SearchFlightModel>();
            //个性化设置过滤
            foreach (var searchFlightModel in ibeFlightModels)
            {
                //TODO:2)个性化不显示共享航班,如当前是共享航班，则不加入list
                if (query.IsShareFly == 0 && searchFlightModel.IsShared)
                {
                    continue;
                }
                //TODO:3)协议价格是单独展示
                //if (query.IsXYPrice == 1)
                //{
                //    List<SearchFlightDetailModel> interDetail = new List<SearchFlightDetailModel>();
                //    for (var i = 0; i < searchFlightModel.DetailList.Count; i++)
                //    {
                //        if (searchFlightModel.DetailList[i].PriceType != "C")//"C"不等于普通价格
                //        {
                //            var SearchModel = searchFlightModel.DetailList[i];
                //            SearchFlightDetailModel SearchModelCopy = (SearchFlightDetailModel)searchFlightModel.DetailList[i].Clone();//TODO:mapper
                //            SearchModelCopy.PriceType = "C";//更改成非协议
                //            SearchModelCopy.SalePrice = SearchModel.FacePrice;//把销售价更改成面单价
                //            SearchModelCopy.Rate = ((Convert.ToDecimal(SearchModelCopy.SalePrice) / Convert.ToDecimal(SearchModelCopy.BaseFacePrice)) * 10).ToString("0.0");
                //            interDetail.Add(SearchModelCopy);
                //        }
                //    }
                //    searchFlightModel.DetailList.AddRange(interDetail);
                //}

                filterSearchlist.Add(searchFlightModel);
            }

            if (string.IsNullOrEmpty(query.CorpId)) //没有公司Id的直接返回ibe航班信息
                return filterSearchlist;

            if(filterSearchlist == null|| filterSearchlist.Count==0)
                return filterSearchlist;

            foreach (var searchFlightModel in filterSearchlist)
            {
                if (string.IsNullOrEmpty(searchFlightModel.SharedFlightNo) ||
                    string.IsNullOrEmpty(searchFlightModel.AirlineNo) ||
                    string.IsNullOrEmpty(searchFlightModel.FlightNo))
                    continue;

                //通过实际航班找到它对应的信息
                SearchFlightModel shared = filterSearchlist.Find(n => (n.AirlineNo + n.FlightNo) == searchFlightModel.SharedFlightNo);
                if (shared != null && shared.DetailList != null && shared.DetailList.Count > 0)
                {
                    SearchFlightDetailModel priceDetail = shared.DetailList.Find(n => n.PriceType == "X" || n.PriceType == "G");
                    if (priceDetail != null)
                    {
                        searchFlightModel.IsSharedFlightNoHasXieYiPrice = true;
                    }
                }

            }

            return filterSearchlist;

        }
    }
}
