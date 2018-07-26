using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Flight;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class SearchContainModPolicyFlightBll : ISearchFlightServiceBll
    {

        /// <summary>
        /// 是否限制仓等，根据差标判断限制仓等
        /// </summary>
        private bool IsLimitClass = true;

        private readonly ISearchFlightServiceBll _ibeFlightServiceBll;
        public SearchContainModPolicyFlightBll(ISearchFlightServiceBll ibeFlightServiceBll)
        {
            _ibeFlightServiceBll = ibeFlightServiceBll;
        }

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
             int LimitClassType = 0;
            if (string.IsNullOrEmpty(query.AirlineNo))
                throw new Exception("请传入改签航班号");

            string airlineNo = query.AirlineNo;
            List<string> airlineNoList = new List<string> {airlineNo};

            if (airlineNo == "MU")
                airlineNoList.Add("FM");
            else if (airlineNo == "FM")
                airlineNoList.Add("MU");

            query.AirlineNo = ""; //无论是否传入航司三字码，都置为空
            List<SearchFlightModel> ibeFlightModels = _ibeFlightServiceBll.SearchFlight(query);

            ibeFlightModels.ForEach(n =>
            {
                if (airlineNoList.Contains(n.AirlineNo))
                {
                    n.IsOriginalAirlineNo = true;
                }
                else
                {
                    n.IsOriginalAirlineNo = false;
                }
            });
            //改签只显示同航司航班
            ibeFlightModels = ibeFlightModels.FindAll(n => n.IsOriginalAirlineNo);

            #region 判断差标
            //个性化设置 是否显示全部舱位 如果选否，按照下一个“最高舱位限制”政策的舱位
            if ((query.IsAllSeat ?? 0) == 0)
            {
                if (query.IsHeightSeat == 1)
                {
                    LimitClassType = 1;//(最高仓位限制)
                }
                else if (query.IsHeightSeat == 0)
                {
                    LimitClassType = 2;//一旦限制的仓位买完了，显示上一级仓位
                }
            }
            var nPolicyValY = query.CorpPolicy?.NPolicyValY;
            //不根据差标限制仓等
            if (!IsLimitClass || string.IsNullOrWhiteSpace(nPolicyValY)) {
                return ibeFlightModels;
            }
            var classIndex = nPolicyValY == "Y"
            ? 1
            : nPolicyValY == "C" ? 2 : 3;

            foreach (var item in ibeFlightModels) {
                //item.DetailList = item.DetailList.Where(a => (a.ClassDesc.Contains("经济舱") ? 1 : ((a.ClassDesc.Contains("公务舱") || a.ClassDesc.Contains("商务舱")) ? 2 : 3)) <= classIndex).ToList();
                if (LimitClassType == 1)
                {
                    item.DetailList = item.DetailList.Where(a => (a.ClassDesc.Contains("经济舱") ? 1 : ((a.ClassDesc.Contains("公务舱") || a.ClassDesc.Contains("商务舱")) ? 2 : 3)) <= classIndex).ToList();
                }
                else if (LimitClassType == 2)
                {
                    //如果最高仓位买完显示全部仓位
                    int count = item.DetailList.FindAll(n => n.ClassIndex <= classIndex).Count;//所有仓位到限制最高仓位的数量
                    if (count > 0)
                    {
                        item.DetailList = item.DetailList.Where(a => (a.ClassDesc.Contains("经济舱") ? 1 : ((a.ClassDesc.Contains("公务舱") || a.ClassDesc.Contains("商务舱")) ? 2 : 3)) <= classIndex).ToList();
                    }
                }
            }
            ibeFlightModels = ibeFlightModels.Where(a => a.DetailList != null && a.DetailList.Any()).ToList();
            return ibeFlightModels;
            #endregion
        }
    }
}
