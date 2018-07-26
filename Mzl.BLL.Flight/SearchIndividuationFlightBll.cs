using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
namespace Mzl.BLL.Flight
{
    public class SearchIndividuationFlightBll : ISearchFlightServiceBll
    {
        private readonly ISearchFlightServiceBll _searchFlightServiceBll;

        public SearchIndividuationFlightBll(ISearchFlightServiceBll searchFlightServiceBll)
        {
            _searchFlightServiceBll = searchFlightServiceBll;
        }

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            List<SearchFlightModel> ibeFlightModels = _searchFlightServiceBll.SearchFlight(query);

            List<SearchFlightModel> list = new List<SearchFlightModel>();

            foreach (var searchFlightModel in ibeFlightModels)
            {
                //个性化不显示共享航班,如当前是共享航班，则不加入list
                if (query.IsShareFly==0 && searchFlightModel.IsShared)
                {
                    continue;
                }
                //接口数据为单独展示

                if ((query.IsXYPrice ?? 0) == 0)
                {
                    for (var i = 0; i < searchFlightModel.DetailList.Count; i++)
                    {
                        if (searchFlightModel.DetailList[i].PriceType != "C")//"C"不等于普通价格
                        {
                            //判断一下当前协议价格是否存在普通价格
                            var temp = searchFlightModel.DetailList.Find(
                                n => n.Class == searchFlightModel.DetailList[i].Class && n.PriceType == "C");
                            if (temp == null)
                            {
                                var searchModel = searchFlightModel.DetailList[i];//协议价格信息
                                SearchFlightDetailModel searchModelCopy =
                                    Mapper.Map<SearchFlightDetailModel, SearchFlightDetailModel>(searchModel);//复制一个价格信息
                                searchModelCopy.PriceType = "C";//更改成非协议
                                searchModelCopy.SalePrice = searchModel.FacePrice;//把销售价更改成面单价
                                searchModelCopy.Rate = ((Convert.ToDecimal(searchModelCopy.SalePrice) / Convert.ToDecimal(searchModelCopy.BaseFacePrice)) * 10).ToString("0.0");
                                searchFlightModel.DetailList.Add(searchModelCopy);
                            }
                        }
                    }
                }
                searchFlightModel.DetailList =
                    searchFlightModel.DetailList.OrderBy(n => Convert.ToDecimal(n.SalePrice)).ToList();
                list.Add(searchFlightModel);
            }

            //是否显示全部舱位：

            return list;
        }
    }
}
