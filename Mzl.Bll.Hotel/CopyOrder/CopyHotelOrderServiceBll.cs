using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.CopyOrder;
using Mzl.EntityModel.Hotel;
using Mzl.Framework.Base;
using Mzl.IBll.Hotel.CopyOrder;
using Mzl.IDAL.Hotel;

namespace Mzl.Bll.Hotel.CopyOrder
{
    internal class CopyHotelOrderServiceBll : BaseServiceBll, ICopyHotelOrderServiceBll
    {
        private readonly IHolOrderDal _holOrderDal;
        private readonly IHolOrderDetailDal _holOrderDetail;
        private readonly IHolOrderLogDal _holOrderLogDal;
        private readonly IHolRefundDal _holRefundDal;

        public CopyHotelOrderServiceBll(IHolOrderDal holOrderDal, IHolOrderDetailDal holOrderDetail, IHolOrderLogDal holOrderLogDal, IHolRefundDal holRefundDal)
        {
            _holOrderDal = holOrderDal;
            _holOrderDetail = holOrderDetail;
            _holOrderLogDal = holOrderLogDal;
            _holRefundDal = holRefundDal;
        }

        public int CopyOrder(CopyHotelOrderModel copyHotelOrderModel)
        {
            #region 获取原始数据
            //原始订单
            HolOrderEntity copyHolOrderEntity = _holOrderDal.Find<HolOrderEntity>(copyHotelOrderModel.CopyFromOrderId);
            if (copyHolOrderEntity == null)
            {
                throw new Exception("复制来源订单异常");
            }

            if (copyHotelOrderModel.CopyType == "X")
            {
                HolRefundEntity holRefundEntity =
                    _holRefundDal.Query<HolRefundEntity>(
                        n => n.OrderId == copyHolOrderEntity.OrderId && n.RefundType == 1, true).FirstOrDefault();
                if (holRefundEntity == null)
                    throw new Exception("不是虚退订单，不能虚退复制");
            }

            //原始订单间夜信息
            List<HolOrderDetailEntity> copyHolOrderDetailEntities =
                _holOrderDetail.Query<HolOrderDetailEntity>(n => n.OrderId == copyHotelOrderModel.CopyFromOrderId, true)
                    .ToList();
            #endregion

            #region 原始订单信息映射复制新实体
            HolOrderEntity holOrderEntity = Mapper.Map<HolOrderEntity, HolOrderEntity>(copyHolOrderEntity);
            List<HolOrderDetailEntity> holOrderDetailEntities =
                Mapper.Map<List<HolOrderDetailEntity>, List<HolOrderDetailEntity>>(copyHolOrderDetailEntities);
            #endregion

            #region 复制新实体 新增订单

            holOrderEntity.CreateOid = copyHotelOrderModel.CreateOid;
            holOrderEntity.CopyType = copyHotelOrderModel.CopyType;
            holOrderEntity.Collectiontime = null;
            holOrderEntity.RealPayDatetime = null;
            holOrderEntity.Printordertime = null;
            holOrderEntity.ConfirmTime = null;
            holOrderEntity.FristPrintTime = null;
            holOrderEntity.FivePrintLastTime = null;
            holOrderEntity.IsNeedPrintTime = null;
            holOrderEntity.FivePrintId = null;
            holOrderEntity.ProcessStatus = 0;
            holOrderEntity.OrderStatus = "P";

            if (holOrderEntity.CopyType != "X")//不是虚退复制
            {
                holOrderEntity.CreateDate = DateTime.Now;
                holOrderEntity.CopyFromOrderId = copyHotelOrderModel.CopyFromOrderId;
            }
            else
            {
                if (string.IsNullOrEmpty(holOrderEntity.CopyType))
                {
                    holOrderEntity.CopyFromOrderId = copyHotelOrderModel.CopyFromOrderId;
                }
                else
                {
                    //如果当前原始订单是虚退复制的，那么它的虚退复制订单的马甲订单号继承原始订单的马甲订单号
                    if (copyHolOrderEntity.CopyType == "X" && copyHolOrderEntity.CopyFromOrderId.HasValue)
                    {
                        holOrderEntity.CopyFromOrderId = copyHolOrderEntity.CopyFromOrderId;
                    }
                    else
                    {
                        holOrderEntity.CopyFromOrderId = copyHotelOrderModel.CopyFromOrderId;
                    }
                }
            }

            holOrderEntity.PayAmount = copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.DPayAmount)*
                                       copyHolOrderEntity.RoomNum +
                                       copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.AdslTotaAmount) +
                                       copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.BedTotaAmount) +
                                       copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.BreakfastTotaAmount);
            holOrderEntity.TotalAmount = holOrderEntity.PayAmount;

            holOrderEntity.LowAmount = copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.DLowAmount)*
                                       copyHolOrderEntity.RoomNum +
                                       copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.AdslTotaAmount) +
                                       copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.BedTotaAmount) +
                                       copyHotelOrderModel.HotelOrderDetailList.Sum(n => n.BreakfastTotaAmount);

            if (string.IsNullOrEmpty(holOrderEntity.CustomerName))
                holOrderEntity.CustomerName = "";
            if (string.IsNullOrEmpty(holOrderEntity.Remark))
                holOrderEntity.Remark = "";
            if (string.IsNullOrEmpty(holOrderEntity.Explain))
                holOrderEntity.Explain = "";
            if (string.IsNullOrEmpty(holOrderEntity.ContactPhone))
                holOrderEntity.ContactPhone = "";
            if (string.IsNullOrEmpty(holOrderEntity.SendRemark))
                holOrderEntity.SendRemark = "";
            if (string.IsNullOrEmpty(holOrderEntity.SendOid))
                holOrderEntity.SendOid = "";
            if (string.IsNullOrEmpty(holOrderEntity.SendFax))
                holOrderEntity.SendFax = "";
            if (string.IsNullOrEmpty(holOrderEntity.Depart))
                holOrderEntity.Depart = "";
            if (string.IsNullOrEmpty(holOrderEntity.BookingRemark))
                holOrderEntity.BookingRemark = "";
            if (string.IsNullOrEmpty(holOrderEntity.ConfirmRemark))
                holOrderEntity.ConfirmRemark = "";
            if (string.IsNullOrEmpty(holOrderEntity.InvoiceTitle))
                holOrderEntity.InvoiceTitle = "";
            if (string.IsNullOrEmpty(holOrderEntity.InvoiceContent))
                holOrderEntity.InvoiceContent = "";

            holOrderEntity.FaccountsTime = null;
            holOrderEntity.FaccountsOid = null;


            holOrderEntity = _holOrderDal.Insert(holOrderEntity);


            foreach (var holOrderDetailEntity in holOrderDetailEntities)
            {
                holOrderDetailEntity.OrderId = holOrderEntity.OrderId;
                CopyHotelOrderDetailModel copyHotelOrderDetailModel =
                    copyHotelOrderModel.HotelOrderDetailList.Find(n => n.Date == holOrderDetailEntity.Date);

                holOrderDetailEntity.DPayAmount = copyHotelOrderDetailModel.DPayAmount;
                holOrderDetailEntity.DLowAmount = copyHotelOrderDetailModel.DLowAmount;

                holOrderDetailEntity.BedAmount = copyHotelOrderDetailModel.BedAmount;
                holOrderDetailEntity.BedCount = copyHotelOrderDetailModel.BedCount;

                holOrderDetailEntity.BreakfastAmount = copyHotelOrderDetailModel.BreakfastAmount;
                holOrderDetailEntity.BreakfastCount = copyHotelOrderDetailModel.BreakfastCount;

                holOrderDetailEntity.AdslAmount = copyHotelOrderDetailModel.AdslAmount;
                holOrderDetailEntity.AdslCount = copyHotelOrderDetailModel.AdslCount;

                _holOrderDetail.Insert(holOrderDetailEntity);
            }

            _holOrderLogDal.Insert<HolOrderLogEntity>(new HolOrderLogEntity()
            {
                OrderId = holOrderEntity.OrderId,
                OpeartorId = holOrderEntity.CreateOid,
                LogTime = DateTime.Now,
                LogType = "复制订单",
                Context = "复制订单，来源订单号：" + copyHotelOrderModel.CopyFromOrderId + ",马甲订单号：" + holOrderEntity.CopyFromOrderId
            });

            #endregion


            //将原始订单设置为线上隐藏
            if (copyHotelOrderModel.CopyType == "X")
            {
                copyHolOrderEntity.IsOnlineShow = 1;
                _holOrderDal.Update(copyHolOrderEntity, new string[] { "IsOnlineShow" });
            }


            return holOrderEntity.OrderId;
        }
    }
}
