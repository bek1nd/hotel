using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;
using Mzl.Common.EnumHelper;
using Mzl.Common.PostHelper;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class ConfirmModAuditPriceServiceBll : BaseBll, IConfirmModAuditPriceServiceBll
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltRetModApplyLogDal _fltRetModApplyLogDal;

        public ConfirmModAuditPriceServiceBll(IFltRetModApplyDal fltRetModApplyDal,
            IFltRetModFlightApplyDal fltRetModFlightApplyDal, IFltRetModApplyLogDal fltRetModApplyLogDal)
            : base()
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
        }

        public ConfirmRetModAuditPriceResultModel ConfirmModAuditPrice(ConfirmRetModAuditPriceModel query)
        {
            FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(query.Rmid);
            if(fltRetModApplyEntity==null)
                throw new Exception("查无此申请");

            if (fltRetModApplyEntity.OrderStatus != FltModApplyStatusEnum.A.ToString())
                throw new Exception("该审核已经提交审批");

            fltRetModApplyEntity.EditOid = query.Cid.ToString();
            fltRetModApplyEntity.EditTime = DateTime.Now;
            fltRetModApplyEntity.OrderStatus = FltModApplyStatusEnum.P.ToString();
            _fltRetModApplyDal.Update(fltRetModApplyEntity,new string[] { "EditOid", "EditTime", "OrderStatus" });

            bool isViolatePolicy = false;
            foreach (var detail in query.DetailList)
            {
                FltRetModFlightApplyEntity flightApplyEntity =
                    _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(
                        n => n.Rmid == query.Rmid && n.Sequence == detail.Sequence && n.Pid == detail.Pid)
                        .FirstOrDefault();

                if(flightApplyEntity==null)
                    continue;


                if (!string.IsNullOrEmpty(flightApplyEntity.PolicyDesc))
                    isViolatePolicy = true;

                flightApplyEntity.OrderStatus = fltRetModApplyEntity.OrderStatus;
                List<string> upStatus = new List<string>();
                upStatus.Add("OrderStatus");
                if (detail.ChoiceReasonId.HasValue)
                {
                    flightApplyEntity.ChoiceReasonId = detail.ChoiceReasonId;
                    upStatus.Add("ChoiceReasonId");
                }
                _fltRetModFlightApplyDal.Update(flightApplyEntity, upStatus.ToArray());
            }
        
            FltRetModApplyLogEntity log = new FltRetModApplyLogEntity()
            {
                Rmid = fltRetModApplyEntity.Rmid,
                LogTime = DateTime.Now,
                LogType = "修改改签申请",
                Oid = "sys",
                Remark = "确认核价"
            };
            _fltRetModApplyLogDal.Insert(log);
            return new ConfirmRetModAuditPriceResultModel()
            {
                IsSuccess = true,
                Rmid= fltRetModApplyEntity.Rmid,
                CorpAduitId = fltRetModApplyEntity.CorpAduitId,
                CorpPolicyId= fltRetModApplyEntity.CorpPolicyId,
                OwnCid = fltRetModApplyEntity.Cid,
                IsViolatePolicy= isViolatePolicy
            };
        }

      
    }
}
