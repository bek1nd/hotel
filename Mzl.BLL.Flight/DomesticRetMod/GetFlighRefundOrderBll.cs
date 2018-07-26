using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class GetFlighRefundOrderBll : BaseBll, IGetFlighRefundOrderBll
    {
        private readonly IFltRefundOrderDal _fltRefundOrderDal;
        private readonly IFltRefundOrderDetailDal _fltRefundOrderDetailDal;

        public GetFlighRefundOrderBll(IFltRefundOrderDal fltRefundOrderDal,
            IFltRefundOrderDetailDal fltRefundOrderDetailDal) : base()
        {
            _fltRefundOrderDal = fltRefundOrderDal;
            _fltRefundOrderDetailDal = fltRefundOrderDetailDal;
        }

        public FltRefundOrderModel GetFlighRefundOrderById(int refundId)
        {
            FltRefundOrderEntity  refundOrderEntity= _fltRefundOrderDal.Find<FltRefundOrderEntity>(refundId);
            if (refundOrderEntity == null)
                return null;
            List<FltRefundOrderModel> refundModels = Convert(new List<FltRefundOrderEntity>() {refundOrderEntity});
            return refundModels.FirstOrDefault();
        }

        public List<FltRefundOrderModel> GetFlighRefundOrderByOrderId(int orderId)
        {
            List< FltRefundOrderEntity > refundOrderEntities =_fltRefundOrderDal.Query<FltRefundOrderEntity>(n => n.OrderId == orderId).ToList();
            if (refundOrderEntities == null || refundOrderEntities.Count == 0)
                return null;
            List<FltRefundOrderModel> refundModels = Convert(refundOrderEntities);
            return refundModels;
        }

        public FltRefundOrderModel GetFlighRefundOrderByRmid(int rmid)
        {
            FltRefundOrderEntity refundOrderEntity = _fltRefundOrderDal.Query<FltRefundOrderEntity>(n => n.Rmid == rmid).FirstOrDefault();
            if (refundOrderEntity == null)
                return null;
            List<FltRefundOrderModel> refundModels = Convert(new List<FltRefundOrderEntity>() { refundOrderEntity });
            return refundModels.FirstOrDefault();
        }


        #region 私有方法

        private List<FltRefundOrderModel> Convert(List<FltRefundOrderEntity> refundOrderEntities)
        {
            List<FltRefundOrderModel> refundModels = new List<FltRefundOrderModel>();
            List<int> rmidList = refundOrderEntities.Select(n => n.RefundId).ToList();
            List<FltRefundOrderDetailEntity> refundOrderDetailEntities =
                _fltRefundOrderDetailDal.Query<FltRefundOrderDetailEntity>(n => rmidList.Any(x => x == n.Rid)).ToList();


            foreach (FltRefundOrderEntity fltRefundOrderEntity in refundOrderEntities)
            {
                FltRefundOrderModel refundModel = Mapper.Map<FltRefundOrderEntity, FltRefundOrderModel>(fltRefundOrderEntity);
                List < FltRefundOrderDetailEntity > detailList= refundOrderDetailEntities.FindAll(n => n.Rid == fltRefundOrderEntity.RefundId);
                refundModel.DetailList= Mapper.Map<List<FltRefundOrderDetailEntity>, List<FltRefundDetailOrderModel>>(detailList);
                refundModels.Add(refundModel);
            }



            return refundModels;
        }

        #endregion
    }
}
