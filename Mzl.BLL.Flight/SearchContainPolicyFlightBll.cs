using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.DomainModel.Customer.CorpPolicy;

namespace Mzl.BLL.Flight
{
    /// <summary>
    /// 将差旅政策包装到IBE航班信息中
    /// </summary>
    public class SearchContainPolicyFlightBll : ISearchFlightServiceBll
    {
        private readonly ISearchFlightServiceBll _checkWhitelFlightSearch;

        /// <summary>
        /// 是否限制仓等，根据差标判断限制仓等
        /// </summary>
        private int LimitClassType = 0;

        public SearchContainPolicyFlightBll(ISearchFlightServiceBll checkWhitelFlightSearch)
        {
            _checkWhitelFlightSearch = checkWhitelFlightSearch;
        }

        public List<SearchFlightModel> SearchFlight(SearchFlightQueryModel query)
        {
            List<SearchFlightModel> ibeFlightModels = _checkWhitelFlightSearch.SearchFlight(query);
            if (string.IsNullOrEmpty(query.CorpId)) //没有公司Id的直接返回ibe航班信息
                return ibeFlightModels;
            CorpPolicyDetailConfigModel policyModel = query.CorpPolicy;
            

            #region 将差旅政策包装到IBE航班信息

            List<SearchFlightModel> flightTempList = new List<SearchFlightModel>();
            #region 没有差旅政策
            if (policyModel == null)
            {
                foreach (var model in ibeFlightModels)
                {
                    foreach (var detail in model.DetailList)
                    {
                        detail.IsViolate = "F";
                        detail.ViolateNPolicyValL = "F";
                        detail.ViolateNPolicyValLDesc = "";
                        detail.ViolateNPolicyValT = "F";
                        detail.ViolateNPolicyValTDesc = "";
                        detail.ViolateNPolicyValR = "F";
                        detail.ViolateNPolicyValRDesc = "";
                        detail.ViolateNPolicyValY = "F";
                        detail.ViolateNPolicyValYDesc = "F";
                    }
                    flightTempList.Add(model);
                }
                return flightTempList;
            }
            #endregion
            #region 存在差旅政策
            #region 判断
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


            int? nPolicyValLValue = null; //国内机票低价航班为出发时间前后XX分钟内最低航班 //判断明细
            int? nPolicyValTValue = null; //国内机票提前预定 提前XXX天以上预定航班 //判断主体
            decimal? nPolicyValRValue = null; // 国内机票XXX折扣限制  //判断明细
            string nPolicyValY = string.Empty; //国内机票仓等限制 Y经济舱/C公务舱/F头等舱  //判断明细
            if (!string.IsNullOrEmpty(policyModel.NPolicyValL) && policyModel.NPolicyValL != "-1") //存在该政策，并且非不受限制
            {
                nPolicyValLValue = Convert.ToInt32(policyModel.NPolicyValL);
            }
            if (!string.IsNullOrEmpty(policyModel.NPolicyValT) && policyModel.NPolicyValT != "-1")
            {
                nPolicyValTValue = Convert.ToInt32(policyModel.NPolicyValT);
            }
            if (!string.IsNullOrEmpty(policyModel.NPolicyValR) && policyModel.NPolicyValR != "-1")
            {
                nPolicyValRValue = Convert.ToDecimal(policyModel.NPolicyValR);
            }
            if (!string.IsNullOrEmpty(policyModel.NPolicyValY))
            {
                nPolicyValY = policyModel.NPolicyValY;
            }

            #endregion

            string isViolate = "F";
            string violateNPolicyValT = "F";
            string violateNPolicyValTDesc = string.Empty;

            #region 提前预定判断政策

            if (nPolicyValTValue.HasValue)
            {
                double day = (query.TackOffTime - Convert.ToDateTime(DateTime.Now.ToShortDateString())).TotalDays;
                if (day < nPolicyValTValue.Value)
                {
                    isViolate = "T";
                    violateNPolicyValT = "T";
                    if (query.CorpId == "JYJR")
                        violateNPolicyValTDesc = "航班预定需需提前" + nPolicyValTValue.Value + "天以上航班预定";
                    else
                        violateNPolicyValTDesc = "提前" + nPolicyValTValue.Value + "天以上预定航班";
                }
            }

            #endregion
            foreach (var model in ibeFlightModels)
            {
                foreach (var detail in model.DetailList)
                {
                    detail.ViolateNPolicyValT = violateNPolicyValT;
                    detail.ViolateNPolicyValTDesc = violateNPolicyValTDesc;

                    #region 折扣限制政策判断

                    if (nPolicyValRValue.HasValue && Convert.ToDecimal(detail.Rate) > nPolicyValRValue)
                    {
                        detail.ViolateNPolicyValR = "T";
                        detail.ViolateNPolicyValRDesc = nPolicyValRValue + "折以下的航班";
                    }
                    else
                    {
                        detail.ViolateNPolicyValR = "F";
                        detail.ViolateNPolicyValRDesc = "";
                    }

                    #endregion

                    #region 仓等限制政策判断

                    if (!string.IsNullOrEmpty(nPolicyValY))
                    {
                        if (detail.FatherClass == "J")
                            detail.FatherClass = "C";
                        if (nPolicyValY != detail.FatherClass)
                        {
                            detail.ViolateNPolicyValY = "T";
                            detail.ViolateNPolicyValYDesc = "未预定" +
                                                            (nPolicyValY == "Y"
                                                                ? "经济舱"
                                                                : nPolicyValY == "C" ? "公务舱" : "头等舱");
                        }
                        else
                        {
                            detail.ViolateNPolicyValY = "F";
                            detail.ViolateNPolicyValYDesc = "";
                        }
                        #region 隐藏仓位
                        var classIndex = nPolicyValY == "Y"
                                    ? 1
                                    : nPolicyValY == "C" ? 2 : 3;

                        if (LimitClassType == 1)
                        {
                            model.DetailList = model.DetailList.Where(a => (a.ClassDesc.Contains("经济舱") ? 1 : ((a.ClassDesc.Contains("公务舱") || a.ClassDesc.Contains("商务舱")) ? 2 : 3)) <= classIndex).ToList();
                        }
                        else if (LimitClassType == 2)
                        {
                            //如果最高仓位买完显示全部仓位
                            int count=model.DetailList.FindAll(n => n.ClassIndex <= classIndex).Count;//所有仓位到限制最高仓位的数量
                            if (count > 0)
                            {
                                model.DetailList = model.DetailList.Where(a => (a.ClassDesc.Contains("经济舱") ? 1 : ((a.ClassDesc.Contains("公务舱") || a.ClassDesc.Contains("商务舱")) ? 2 : 3)) <= classIndex).ToList();
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        detail.ViolateNPolicyValY = "F";
                        detail.ViolateNPolicyValYDesc = "";
                    }

                    #endregion

                    #region 航班前后XX分钟内是否最低价格政策判断

                    if (nPolicyValLValue.HasValue)
                    {
                        decimal? minPrice =  GetMinSalePrice(Convert.ToDateTime(model.TackOffTime), nPolicyValLValue.Value, ibeFlightModels,Convert.ToDecimal(detail.SalePrice));
                        if (minPrice.HasValue)
                        {
                            detail.ViolateNPolicyValL = "T";
                            detail.ViolateNPolicyValLDesc = "未选择前后" + nPolicyValLValue.Value + "分钟内最低价格为" +
                                                            minPrice.Value.ToString("0");
                            detail.MinSalePrice = Convert.ToDecimal(minPrice.Value.ToString("0"));
                        }
                        else
                        {
                            detail.ViolateNPolicyValL = "F";
                            detail.ViolateNPolicyValLDesc = "";
                        }
                    }
                    else
                    {
                        detail.ViolateNPolicyValL = "F";
                        detail.ViolateNPolicyValLDesc = "";
                    }

                    #endregion

                    if (isViolate == "T")
                        detail.IsViolate = "T";
                    else
                    {
                        if (string.IsNullOrEmpty(detail.ViolateNPolicyValRDesc) &&
                            string.IsNullOrEmpty(detail.ViolateNPolicyValYDesc) &&
                            string.IsNullOrEmpty(detail.ViolateNPolicyValLDesc))
                        {
                            detail.IsViolate = "F";
                        }
                        else
                        {
                            detail.IsViolate = "T";
                        }
                    }
                }
                if (model.DetailList != null && model.DetailList.Any())
                {
                    flightTempList.Add(model);
                }
            } 
            #endregion

            #endregion

            return flightTempList;
        }

       
        private decimal? GetMinSalePrice(DateTime tackOffTime, int policyValL, List<SearchFlightModel> searchFlightModels,decimal salePrice)
        {
            DateTime beginTime = Convert.ToDateTime(tackOffTime.AddMinutes(policyValL * -1));
            DateTime endTime = Convert.ToDateTime(tackOffTime.AddMinutes(policyValL));

            List<SearchFlightModel> rangeFlightModels = (from n in searchFlightModels
                where Convert.ToDateTime(n.TackOffTime) >= beginTime && Convert.ToDateTime(n.TackOffTime) <= endTime
                select n).ToList();

            List<decimal> salePriceList = new List<decimal>();

            foreach (var searchFlightModel in rangeFlightModels)
            {
                foreach (var searchFlightDetailModel in searchFlightModel.DetailList)
                {
                    salePriceList.Add(Convert.ToDecimal(searchFlightDetailModel.SalePrice));
                }
            }
            if (salePriceList.Count == 0)
                return null;
            decimal minSalePrice = salePriceList.Min();

            if (salePrice > minSalePrice)
                return minSalePrice;

            return null;

        }
    }
}
