using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Flight.CopyOrder;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.CopyOrder;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.CopyOrder
{
    public class CopyCorpFltDomesticOrderServiceBll: BaseServiceBll,ICopyFltDomesticOrderServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltOrderUnionDal _fltOrderUnionDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;
        private readonly IFltTicketNoDal _fltTicketNoDal;
        private readonly IFltCorpCostCenterDal _fltCorpCostCenterDal;
        private readonly IFltRetModApplyDal _fltRetModApplyDal;

        public CopyCorpFltDomesticOrderServiceBll(IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal,
            IFltPassengerDal fltPassengerDal, IFltOrderUnionDal fltOrderUnionDal, IFltOrderLogDal fltOrderLogDal,
            IFltTicketNoDal fltTicketNoDal, IFltCorpCostCenterDal fltCorpCostCenterDal, IFltRetModApplyDal fltRetModApplyDal)
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _fltOrderUnionDal = fltOrderUnionDal;
            _fltOrderLogDal = fltOrderLogDal;
            _fltTicketNoDal = fltTicketNoDal;
            _fltCorpCostCenterDal = fltCorpCostCenterDal;
            _fltRetModApplyDal = fltRetModApplyDal;
        }

        /// <summary>
        /// 复制差旅订单
        /// </summary>
        /// <param name="copyFltOrderModel"></param>
        /// <returns></returns>
        public int CopyOrder(CopyFltOrderModel copyFltOrderModel)
        {
            FltOrderEntity copyFromOrderEntity = _fltOrderDal.Find<FltOrderEntity>(copyFltOrderModel.CopyFromOrderId);
            if (copyFromOrderEntity == null)
            {
                throw new Exception("复制来源订单异常");
            }
            List<FltFlightEntity> copyFromFlightEntities =
                _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == copyFltOrderModel.CopyFromOrderId, true).ToList();

            List<FltPassengerEntity> copyFromPassengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == copyFltOrderModel.CopyFromOrderId, true)
                    .ToList();

            List<FltTicketNoEntity> copyFromTicketNoEntities =
                _fltTicketNoDal.Query<FltTicketNoEntity>(n => n.OrderId == copyFltOrderModel.CopyFromOrderId, true)
                    .ToList();

            FltOrderUnionEntity copyFromOrderUnionEntity =
                _fltOrderUnionDal.Find<FltOrderUnionEntity>(copyFltOrderModel.CopyFromOrderId);

            FltCorpCostCenterEntity copyFromCostCenterEntity =
                _fltCorpCostCenterDal.Find<FltCorpCostCenterEntity>(copyFltOrderModel.CopyFromOrderId);

            FltOrderEntity fltOrderEntity = Mapper.Map<FltOrderEntity, FltOrderEntity>(copyFromOrderEntity);
            FltOrderUnionEntity fltOrderUnionEntity = Mapper.Map<FltOrderUnionEntity, FltOrderUnionEntity>(copyFromOrderUnionEntity);
            FltCorpCostCenterEntity fltCorpCostCenterEntity =
                Mapper.Map<FltCorpCostCenterEntity, FltCorpCostCenterEntity>(copyFromCostCenterEntity);

            List<FltFlightEntity> fltFlightEntities =
                Mapper.Map<List<FltFlightEntity>, List<FltFlightEntity>>(copyFromFlightEntities);
            List<FltPassengerEntity> fltPassengerEntities =
                Mapper.Map<List<FltPassengerEntity>, List<FltPassengerEntity>>(copyFromPassengerEntities);
            List<FltTicketNoEntity> fltTicketNoEntities =
                Mapper.Map<List<FltTicketNoEntity>, List<FltTicketNoEntity>>(copyFromTicketNoEntities);


            fltOrderEntity.Payamount = copyFltOrderModel.PayAmount;
            fltOrderEntity.CreditcardfeeAmount = copyFltOrderModel.CreditCardfeeamount;
            fltOrderEntity.Voucheramount = copyFltOrderModel.Voucheramount;
            fltOrderEntity.SendTicketAmount = copyFltOrderModel.SendTicketamount;
            fltOrderEntity.Totalamount = fltOrderEntity.Payamount + fltOrderEntity.CreditcardfeeAmount;
            fltOrderEntity.CreateOid = copyFltOrderModel.CreateOid;
            if (string.IsNullOrEmpty(fltOrderEntity.Remark))
                fltOrderEntity.Remark = "无";

            fltOrderEntity.ReturnAccountOid = "";
            fltOrderEntity.ReturnAccountTime = null;
            fltOrderEntity.OutTicketStatus = "N";
            fltOrderEntity.ProcessStatus = 1;
            fltOrderEntity.Orderstatus = "P";

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

            if (copyFltOrderModel.CopyType == "X")//虚出复制
            {
                //判断当前原始订单是否有虚退
                int xuTuiCount = _fltRetModApplyDal.Query<FltRetModApplyEntity>(
                    n => n.OrderType.ToUpper() == "R" &&
                         n.OrderId == copyFltOrderModel.CopyFromOrderId && n.OrderStatus.ToUpper() != "C" &&
                         n.RefundType == "虚退").Count();
                if (xuTuiCount == 0)
                    throw new Exception("当前订单不存在虚退，不允许虚退复制");


                fltOrderEntity.OrderDate = copyFromOrderEntity.OrderDate;
                fltOrderEntity.CopyType = "X";
                //如果当前原始订单不是虚退复制的订单
                if (string.IsNullOrEmpty(copyFromOrderEntity.CopyType))
                {
                    fltOrderEntity.CopyFromOrderId = copyFltOrderModel.CopyFromOrderId;
                }
                else
                {
                    if (copyFromOrderEntity.CopyType == "X" && copyFromOrderEntity.CopyFromOrderId.HasValue)
                    {
                        fltOrderEntity.CopyFromOrderId = copyFromOrderEntity.CopyFromOrderId;
                    }
                    else
                    {
                        fltOrderEntity.CopyFromOrderId = copyFltOrderModel.CopyFromOrderId;
                    }
                }
            }
            else
            {
                fltOrderEntity.CopyType = "C";
                fltOrderEntity.CopyFromOrderId = copyFltOrderModel.CopyFromOrderId;
                fltOrderEntity.OrderDate = DateTime.Now;
            }

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
                CopyFltFlightModel copyFltFlightModel =
                    copyFltOrderModel.FlightList.Find(n => n.Sequence == fltFlightEntity.Sequence);
                if(string.IsNullOrEmpty(fltFlightEntity.RecordNo))
                    fltFlightEntity.RecordNo = "AAAAAA";
                fltFlightEntity.OrderId= fltOrderEntity.OrderId;
                fltFlightEntity.Sequence = copyFltFlightModel.Sequence;
                fltFlightEntity.OilFee = copyFltFlightModel.OilFee;
                fltFlightEntity.Rate = copyFltFlightModel.Rate;
                fltFlightEntity.SalePrice = copyFltFlightModel.SalePrice;
                fltFlightEntity.TaxFee = copyFltFlightModel.TaxFee;
                if (string.IsNullOrEmpty(fltFlightEntity.Airportson))
                    fltFlightEntity.Airportson = "----";
                _fltFlightDal.Insert(fltFlightEntity);
            }

            foreach (var fltPassengerEntity in fltPassengerEntities)
            {
                fltPassengerEntity.OrderId = fltOrderEntity.OrderId;
                if (string.IsNullOrEmpty(fltPassengerEntity.Remark))
                    fltPassengerEntity.Remark = "无";
                _fltPassengerDal.Insert(fltPassengerEntity);
            }

            if (fltTicketNoEntities != null && fltTicketNoEntities.Count > 0)
            {
                foreach (var fltTicketNoEntity in fltTicketNoEntities)
                {
                    fltTicketNoEntity.OrderId = fltOrderEntity.OrderId;
                    _fltTicketNoDal.Insert(fltTicketNoEntity);
                }
            }

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
                Remark = "复制订单，来源订单号："+ copyFltOrderModel.CopyFromOrderId + ",马甲订单号：" + fltOrderEntity.CopyFromOrderId,
                Oid = fltOrderEntity.CreateOid
            };
            _fltOrderLogDal.Insert(log);


            //将原始订单设置为线上隐藏
            if (copyFltOrderModel.CopyType == "X")
            {
                copyFromOrderEntity.IsOnlineShow = 1;
                _fltOrderDal.Update(copyFromOrderEntity, new string[] {"IsOnlineShow"});
            }

            return fltOrderEntity.OrderId;
        }
    }
}
