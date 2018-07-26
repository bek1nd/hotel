using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Flight;

namespace Mzl.BLL.Flight
{
    internal class SearchCheckWhitelFlightBll: ISearchFlightServiceBll
    {
        private readonly ISearchFlightServiceBll _ibeFlightServiceBll;

        private readonly ICheckPassengerIsInWhiteListBll _checkPassengerIsInWhiteListBll;
        private static readonly string CheckByNameAirlineNo = AppSettingsHelper.GetAppSettings(AppSettingsEnum.WhiteListByName);
        public SearchCheckWhitelFlightBll(ISearchFlightServiceBll ibeFlightServiceBll, ICheckPassengerIsInWhiteListBll checkPassengerIsInWhiteListBll)
        {
            _ibeFlightServiceBll = ibeFlightServiceBll;
            _checkPassengerIsInWhiteListBll = checkPassengerIsInWhiteListBll;
        }

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            List<SearchFlightModel> polictFlightModels = _ibeFlightServiceBll.SearchFlight(query);


            #region 判断是否在名单内

            bool flag1 = true;//人名判断
            bool flag2 = true;//证件判断

            query.PassengerNameList.ForEach(n =>
            {
                if (!_checkPassengerIsInWhiteListBll.CheckPassengerName(n))//一旦有一个人不存在名单内，就设置不在名单
                {
                    flag1 = false;
                }
            });


            query.CardNoList.ForEach(n =>
            {
                if (!_checkPassengerIsInWhiteListBll.CheckPassengerCardNo(n))//一旦有一个人不存在名单内，就设置不在名单
                {
                    flag2 = false;
                }
            });

            #endregion


            List<SearchFlightModel> tempFlightModels = new List<SearchFlightModel>();

            foreach (SearchFlightModel polictFlightModel in polictFlightModels)
            {
                SearchFlightModel tempFlightModel = polictFlightModel;
                //根据不同的航司获取对应的名单判断规则
                bool flag0 = flag2; //默认证件判断
                if (CheckByNameAirlineNo.Contains(tempFlightModel.AirlineNo.ToUpper())) //人名判断
                {
                    flag0 = flag1;
                }

                List<SearchFlightDetailModel> tempFlightDetailModels = new List<SearchFlightDetailModel>();
                foreach (SearchFlightDetailModel searchFlightDetailModel in polictFlightModel.DetailList)
                {
                    //不在名单内，去除B2G价格，并且将协议价格转成普通价格
                    if (!flag0)
                    {
                        if (searchFlightDetailModel.PriceType == "C")
                        {
                            tempFlightDetailModels.Add(searchFlightDetailModel);
                        }
                        else if (searchFlightDetailModel.PriceType == "X")
                        {
                            searchFlightDetailModel.PriceType = "C";
                            searchFlightDetailModel.SalePrice = searchFlightDetailModel.FacePrice;
                            searchFlightDetailModel.Rate = searchFlightDetailModel.FRate;
                            tempFlightDetailModels.Add(searchFlightDetailModel);
                        }

                    }
                    else //在名单内，不做任何处理
                    {
                        tempFlightDetailModels.Add(searchFlightDetailModel);
                    }
                }

                if (tempFlightDetailModels.Count > 0)
                {
                    tempFlightModel.DetailList = tempFlightDetailModels;
                    tempFlightModels.Add(tempFlightModel);
                }

            }

            return tempFlightModels;

        }
    }
}
