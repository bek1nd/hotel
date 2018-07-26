using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.SplitOrder;
using Mzl.IDAL.Flight;
using Mzl.Common.EnumHelper;

namespace Mzl.BLL.Flight.SplitOrder
{
    internal class SplitFltOrderServiceBll : BaseServiceBll, ISplitFltOrderServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltOrderUnionDal _fltOrderUnionDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;
        private readonly IFltCorpCostCenterDal _fltCorpCostCenterDal;

        public SplitFltOrderServiceBll(IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal,
           IFltPassengerDal fltPassengerDal, IFltOrderUnionDal fltOrderUnionDal, IFltOrderLogDal fltOrderLogDal,
           IFltCorpCostCenterDal fltCorpCostCenterDal)
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _fltOrderUnionDal = fltOrderUnionDal;
            _fltOrderLogDal = fltOrderLogDal;
            _fltCorpCostCenterDal = fltCorpCostCenterDal;
        }

        /// <summary>
        /// 按照乘机人拆分订单
        /// </summary>
        /// <returns></returns>
        public List<int> SplitFltOrderByPassenger(int orderId,string oid)
        {
            #region 源数据
            FltOrderEntity splitFromOrderEntity = _fltOrderDal.Find<FltOrderEntity>(orderId);
            if (splitFromOrderEntity == null)
                throw new Exception("未找到源订单");
            List<FltFlightEntity> splitFromFlightEntities =
               _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == orderId, true).ToList();
            List<FltPassengerEntity> splitFromPassengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == orderId, true)
                    .ToList();
            if (splitFromPassengerEntities.Count == 1)
            {
                throw new Exception("只有一个乘机人不能拆单");
            }

            FltOrderUnionEntity splitFromOrderUnionEntity = _fltOrderUnionDal.Find<FltOrderUnionEntity>(orderId);
            FltCorpCostCenterEntity splitFromCostCenterEntity =
                _fltCorpCostCenterDal.Find<FltCorpCostCenterEntity>(orderId);
            #endregion

            List<int> orderIdList = new List<int>();

            for (int i = 0; i < splitFromPassengerEntities.Count; i++)
            {
                int id=AddOrder(splitFromOrderEntity, splitFromOrderUnionEntity, splitFromCostCenterEntity,
                    splitFromFlightEntities,
                    splitFromPassengerEntities[i], (i == 0), oid);
                orderIdList.Add(id);
            }

            return orderIdList;
        }


        private int AddOrder(FltOrderEntity splitFromOrderEntity, FltOrderUnionEntity splitFromOrderUnionEntity,
            FltCorpCostCenterEntity splitFromCostCenterEntity, List<FltFlightEntity> splitFromFlightEntities,
            FltPassengerEntity splitFromPassengerEntity, bool isFirst, string oid)
        {
            FltOrderEntity fltOrderEntity = Mapper.Map<FltOrderEntity, FltOrderEntity>(splitFromOrderEntity);
            FltOrderUnionEntity fltOrderUnionEntity =
                Mapper.Map<FltOrderUnionEntity, FltOrderUnionEntity>(splitFromOrderUnionEntity);
            List<FltFlightEntity> fltFlightEntities =
                Mapper.Map<List<FltFlightEntity>, List<FltFlightEntity>>(splitFromFlightEntities);
            FltCorpCostCenterEntity fltCorpCostCenterEntity =
                Mapper.Map<FltCorpCostCenterEntity, FltCorpCostCenterEntity>(splitFromCostCenterEntity);
            FltPassengerEntity fltPassengerEntity =
                Mapper.Map<FltPassengerEntity, FltPassengerEntity>(splitFromPassengerEntity);

            fltOrderEntity.Payamount =
                fltFlightEntities.Sum(n => (n.SalePrice ?? 0) + n.TaxFee + (n.OilFee ?? 0) + (n.ServiceFee ?? 0));

            if (fltPassengerEntity.InsuranceCount.HasValue && fltPassengerEntity.InsuranceCount.Value > 0)
            {
                fltOrderEntity.Payamount = fltOrderEntity.Payamount +
                                           (fltPassengerEntity.InsuranceCount.Value*(fltPassengerEntity.Insurance ?? 0));
            }

            if (!isFirst)
            {
                fltOrderEntity.CreditcardfeeAmount = 0;
                fltOrderEntity.Voucheramount = 0;
                fltOrderEntity.SendTicketAmount = 0;
            }

            fltOrderEntity.Totalamount = fltOrderEntity.Payamount + fltOrderEntity.CreditcardfeeAmount;

            if (string.IsNullOrEmpty(fltOrderEntity.Remark))
                fltOrderEntity.Remark = "无";

            fltOrderEntity.ReturnAccountOid = "";
            fltOrderEntity.ReturnAccountTime = null;
            fltOrderEntity.OutTicketStatus = "N";
            fltOrderEntity.ProcessStatus = 1;
            fltOrderEntity.Orderstatus = "P";
            fltOrderEntity.CreateOid = oid;

            if (string.IsNullOrEmpty(fltOrderEntity.Description))
                fltOrderEntity.Description = ",";
            if (string.IsNullOrEmpty(fltOrderEntity.IsOnLinePay))
                fltOrderEntity.IsOnLinePay = "F";
            if (string.IsNullOrEmpty(fltOrderEntity.SendTicketType))
                fltOrderEntity.SendTicketType = SendTicketTypeEnum.Not.ToString();

            fltOrderEntity.RealAcceptDatetime = null;
            fltOrderEntity.RealPayDatetime = null;
            fltOrderEntity.Collectiontime = null;
            fltOrderEntity.CollectionOid = string.Empty;
            fltOrderEntity.PrintTicketOid = null;
            fltOrderEntity.PrintTicketTime = null;
            fltOrderEntity.PrintOrderTime = null;
            fltOrderEntity.OrderDate = DateTime.Now;

            fltOrderEntity = _fltOrderDal.Insert(fltOrderEntity);
            if (fltOrderUnionEntity != null)
            {
                fltOrderUnionEntity.OrderId = fltOrderEntity.OrderId;
                fltOrderUnionEntity.FivePrintId = null;
                fltOrderUnionEntity.FivePrintLastTime = null;
                fltOrderUnionEntity.IsNeedPrintTime = null;
                if (string.IsNullOrEmpty(fltOrderUnionEntity.IsMobile))
                    fltOrderUnionEntity.IsMobile = "F";
                _fltOrderUnionDal.Insert(fltOrderUnionEntity);
            }

            foreach (var fltFlightEntity in fltFlightEntities)
            {
                fltFlightEntity.OrderId = fltOrderEntity.OrderId;
                if (string.IsNullOrEmpty(fltFlightEntity.RecordNo))
                    fltFlightEntity.RecordNo = "AAAAAA";
                if (string.IsNullOrEmpty(fltFlightEntity.Airportson))
                    fltFlightEntity.Airportson = "----";
                _fltFlightDal.Insert(fltFlightEntity);
            }

            fltPassengerEntity.OrderId = fltOrderEntity.OrderId;
            if (string.IsNullOrEmpty(fltPassengerEntity.Remark))
                fltPassengerEntity.Remark = "无";
            _fltPassengerDal.Insert(fltPassengerEntity);

            if (fltCorpCostCenterEntity != null)
            {
                fltCorpCostCenterEntity.Orderid = fltOrderEntity.OrderId;
                _fltCorpCostCenterDal.Insert<FltCorpCostCenterEntity>(fltCorpCostCenterEntity);
            }

            FltOrderLogEntity log = new FltOrderLogEntity()
            {
                OrderId = fltOrderEntity.OrderId,
                LogTime = DateTime.Now,
                LogType = "新建订单",
                Remark = "拆分订单，来源订单号：" + splitFromOrderEntity.OrderId,
                Oid = fltOrderEntity.CreateOid
            };
            _fltOrderLogDal.Insert(log);

            return fltOrderEntity.OrderId;
        }
    }
}
