using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.DomainModel.Customer.ProjectName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Train.Order
{
    /// <summary>
    /// 新增火车订单模型
    /// </summary>
    public class TraAddOrderModel
    {
        /// <summary>
        /// 创建订单的方式 
        /// </summary>
        public int AddOrderType { get; set; }
        public TraOrderModel Order { get; set; }
        public TraOrderStatusModel OrderStatus { get; set; }
        public List<TraOrderDetailModel> OrderDetailList { get; set; }
        /// <summary>
        /// 订单日志
        /// </summary>
        public TraOrderLogModel Log { get; set; }
        /// <summary>
        /// 成本中心
        /// </summary>
        public CostCenterModel CostCenter { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public ProjectNameModel ProjectName { get; set; }
        /// <summary>
        /// 是否线上请求
        /// </summary>
        public bool IsFromOnline { get; set; }
        public string OrderSource { get; set; }


        /// <summary>
        /// 选座信息1A,1B,1C,2A,2B
        /// </summary>
        public List<ChooseSeatModel> ChooseSeatList { get; set; }

        /// <summary>
        /// 提供接口的选座信息
        /// </summary>
        public string ChooseSeats
        {
            get
            {
                if (ChooseSeatList == null || ChooseSeatList.Count == 0)
                    return string.Empty;
                //List<int> randomList = new List<int>()
                //{
                //    2,
                //    3,
                //    4,
                //    5,
                //    6,
                //    7,
                //    8,
                //    9,
                //    10,
                //    11,
                //    12,
                //    13,
                //    14,
                //    15
                //};
                //Random rnd = new Random();
               // int maxSeatNo = randomList[rnd.Next(randomList.Count)];//随机一个小于15的随机正数

                string tempStr = "";

                //判断传入的选座信息是否和乘车人符合
                //不符合，则随机分配一个
                int tempInt = 0;
                bool isSame = false;
                foreach (var chooseSeatModel in ChooseSeatList)
                {
                    if (chooseSeatModel.SeatNo!=null && chooseSeatModel.SeatNo.Count>0)
                        tempInt = tempInt + chooseSeatModel.SeatNo.Count;
                }

                if (tempInt == OrderDetailList.Sum(n => n.PassengerList.Count))
                {
                    isSame = true;
                }

                if (isSame) //符合乘车人数量
                {
                    for (int i = 0; i < ChooseSeatList.Count; i++)
                    {
                        if(ChooseSeatList[i].SeatNo==null|| ChooseSeatList[i].SeatNo.Count==0)
                            continue;

                        for (int k = 0; k < ChooseSeatList[i].SeatNo.Count; k++)
                        {
                            tempStr =
                                string.Format("{0}{1}", (i+1),
                                    ChooseSeatList[i].SeatNo[k]) + tempStr;
                        }
                    }
                    tempStr = tempStr.ToUpper();
                }
               
                return tempStr;
            }
        }
        /// <summary>
        /// 是否选座
        /// </summary>
        public bool IsChooseSeats => !string.IsNullOrEmpty(ChooseSeats);
        public CustomerModel Customer { get; set; }
        /// <summary>
        /// 是否接受无座
        /// </summary>
        public bool IsAcceptStanding { get; set; }
    }
}
