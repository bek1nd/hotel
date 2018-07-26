using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.Framework.Base;
using Mzl.IDAL.Flight;
using AutoMapper;
using Mzl.EntityModel.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class AddFltRetModApplyBll: BaseBll,IAddFltRetModApplyBll
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltRetModApplyLogDal _fltRetModApplyLogDal;
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        public AddFltRetModApplyBll(IFltRetModApplyDal fltRetModApplyDal,
            IFltRetModFlightApplyDal fltRetModFlightApplyDal, 
            IFltRetModApplyLogDal fltRetModApplyLogDal,
            IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal)
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
        }

        public int AddRetModApply(AddRetModApplyModel addRetModApplyModel)
        {
            FltOrderEntity fltOrderEntity= _fltOrderDal.Find<FltOrderEntity>(addRetModApplyModel.OrderId);
            FltRetModApplyEntity applyEntity = Mapper.Map<AddRetModApplyModel, FltRetModApplyEntity>(addRetModApplyModel);
            applyEntity.CorpPolicyId = fltOrderEntity.CorpPolicyId;
            applyEntity.CorpAduitId = fltOrderEntity.CorpAduitId;


            if (!applyEntity.ProcessStatus.HasValue)
                applyEntity.ProcessStatus = 0;
            if (string.IsNullOrEmpty(applyEntity.RefundType))
                applyEntity.RefundType = "实退";
            applyEntity = _fltRetModApplyDal.Insert(applyEntity);

            List<FltRetModFlightApplyEntity> flightApplyEntities =
                Mapper.Map<List<FltRetModFlightApplyModel>, List<FltRetModFlightApplyEntity>>(addRetModApplyModel.DetailList);

            foreach (var fltRetModFlightApplyEntity in flightApplyEntities)
            {
                fltRetModFlightApplyEntity.Rmid = applyEntity.Rmid;
                fltRetModFlightApplyEntity.OrderStatus = applyEntity.OrderStatus;
                if (string.IsNullOrEmpty(fltRetModFlightApplyEntity.FlightNo))
                {
                    FltFlightEntity flightEntity = _fltFlightDal.Query<FltFlightEntity>(
                    n => n.OrderId == applyEntity.OrderId && n.Sequence == fltRetModFlightApplyEntity.Sequence, true)
                    .FirstOrDefault();
                    if (flightEntity != null)
                    {
                        fltRetModFlightApplyEntity.FlightNo = flightEntity.FlightNo;
                    }
                }
                _fltRetModFlightApplyDal.Insert(fltRetModFlightApplyEntity);
            }
            string orderType = (addRetModApplyModel.OrderType == "R" ? "退票" : "改签");
            FltRetModApplyLogEntity log = new FltRetModApplyLogEntity()
            {
                Rmid = applyEntity.Rmid,
                Oid = applyEntity.CreateOid,
                LogTime = DateTime.Now,
                Remark = addRetModApplyModel.Oid + "新增" + orderType + "申请",
                LogType = "新增"
            };
            _fltRetModApplyLogDal.Insert(log);

            return applyEntity.Rmid;
        }
    }
}
