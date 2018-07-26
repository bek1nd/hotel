using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.DomainModel.Train.Server;
using Mzl.IBLL.Train.Search;

namespace Mzl.BLL.Train.Search
{
    public class SearchContainPolicyTrainBll: ISearchTrainBll
    {
        private readonly ISearchTrainBll _searchTrainBll;
        private readonly SortedList<int, string> _seatSortedList = null; 
        public SearchContainPolicyTrainBll(ISearchTrainBll searchTrainBll)
        {
            _searchTrainBll = searchTrainBll;
            _seatSortedList = EnumConvert.QueryEnum<TrainPlaceGradeEnum>();
        }
        public List<TraTravelInfoModel> SearchTrain(TraQueryTrainModel query)
        {
            List<TraTravelInfoModel> traTravelInfoModels = _searchTrainBll.SearchTrain(query);
            if (string.IsNullOrEmpty(query.CorpId)) //没有公司Id的直接返回ibe航班信息
                return traTravelInfoModels;
            CorpPolicyDetailConfigModel policyModel = query.CorpPolicy;

            #region 将差旅政策包装到火车车次信息

            List<TraTravelInfoModel> traTravelInfoTempList = new List<TraTravelInfoModel>();
            #region 没有差旅政策
            if (policyModel == null)
            {
                return traTravelInfoModels;
            }
            #endregion

            #region 存在差旅政策

            List<string> qTrainTypeList = new List<string>()
            {
                "C", "D", "G"
            };//快车类型
            List<string> cTrainTypeList = new List<string>()
            {
                "K", "T", "Z","L","A","Y", "0","1","2","3","4","5","6","7","8","9"
            };//普车类型

            List<string> seatTypeList = new List<string>()
            {
                "硬卧","动卧","软卧","高级软卧"
            };


            foreach (var traTravelInfoModel in traTravelInfoModels)
            {
                if(traTravelInfoModel.DetailList==null|| traTravelInfoModel.DetailList.Count==0)
                    continue;
                List<TraTravelInfoDetailModel> detailList = new List<TraTravelInfoDetailModel>();
                //如果个性化设置中设置选择全部坐席 不进行政策中坐席筛选
                if ((query.IsTraAllSeat ?? 0) == 1)
                {
                    detailList.AddRange(traTravelInfoModel.DetailList);
                }
                else
                {
                    foreach (var traTravelInfoDetailModel in traTravelInfoModel.DetailList)
                    {

                        int p2 = (from n in _seatSortedList
                                  where n.Value == traTravelInfoDetailModel.SeatName
                                  select n.Key).FirstOrDefault();

                        if (!string.IsNullOrEmpty(policyModel.TPolicyValQ) &&
                            !string.IsNullOrEmpty(traTravelInfoModel.train_type) &&
                            qTrainTypeList.Contains(traTravelInfoModel.train_type) && !traTravelInfoDetailModel.SeatName.Contains("卧")) //快车限制
                        {
                            int p1 = (from n in _seatSortedList
                                      where n.Value == policyModel.TPolicyValQ
                                      select n.Key).FirstOrDefault();//标准

                            if (p1 < p2)
                            {
                                traTravelInfoDetailModel.ViolateTPolicyValQ = "T";
                                traTravelInfoDetailModel.ViolateTPolicyValQDesc = "快车席别最高限制为" + policyModel.TPolicyValQ;
                            }

                        }
                        if (!string.IsNullOrEmpty(policyModel.TPolicyValM) &&
                            !string.IsNullOrEmpty(traTravelInfoModel.train_type) &&
                            cTrainTypeList.Contains(traTravelInfoModel.train_type) && !traTravelInfoDetailModel.SeatName.Contains("卧"))//普车限制
                        {
                            int p1 = (from n in _seatSortedList
                                      where n.Value == policyModel.TPolicyValM
                                      select n.Key).FirstOrDefault();//标准
                            if (p1 < p2)
                            {
                                traTravelInfoDetailModel.ViolateTPolicyValM = "T";
                                traTravelInfoDetailModel.ViolateTPolicyValMDesc = "普车/其他最高限制为" + policyModel.TPolicyValM;
                            }
                        }
                        if (!string.IsNullOrEmpty(policyModel.TPolicyValS) && seatTypeList.Contains(traTravelInfoDetailModel.SeatName) && traTravelInfoDetailModel.SeatName.Contains("卧"))//卧铺限制
                        {
                            if (policyModel.TPolicyValS == "99")
                            {
                                traTravelInfoDetailModel.ViolateTPolicyValS = "T";
                                traTravelInfoDetailModel.ViolateTPolicyValSDesc = "最高卧铺限制为不可乘坐卧铺";
                            }
                            else
                            {
                                int p1 = (from n in _seatSortedList
                                          where n.Value == policyModel.TPolicyValS
                                          select n.Key).FirstOrDefault();//标准
                                if (p1 < p2)
                                {
                                    traTravelInfoDetailModel.ViolateTPolicyValS = "T";
                                    traTravelInfoDetailModel.ViolateTPolicyValSDesc = "最高卧铺限制为" + policyModel.TPolicyValS;
                                }
                            }
                        }

                        if (traTravelInfoDetailModel.ViolateTPolicyValQ == "T" ||
                            traTravelInfoDetailModel.ViolateTPolicyValM == "T" ||
                            traTravelInfoDetailModel.ViolateTPolicyValS == "T")
                        {
                            traTravelInfoDetailModel.IsViolate = "T";
                        }
                        else
                        {
                            detailList.Add(traTravelInfoDetailModel);
                        }

                    }
                }

                if (detailList.Count > 0)
                {
                    traTravelInfoModel.DetailList = detailList;
                    traTravelInfoTempList.Add(traTravelInfoModel);
                }
            }
            #endregion

            #endregion

            return traTravelInfoTempList;
        }

         
    }
}
