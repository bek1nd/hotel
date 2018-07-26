using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.DomesticRetMod;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight.DomesticRetMod
{
    internal class CancelRetModOrderServiceBll : BaseServiceBll, ICancelRetModOrderServiceBll
    {
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltRetModApplyLogDal _fltRetModApplyLogDal;

        public CancelRetModOrderServiceBll(IFltRetModApplyDal fltRetModApplyDal,
            IFltRetModFlightApplyDal fltRetModFlightApplyDal, IFltRetModApplyLogDal fltRetModApplyLogDal)
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
        }

        /// <summary>
        /// 核价确认阶段取消申请
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public int CancelFltModApplyByWaitAuditStep(CancelFltRetModApplyModel query)
        {
            FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(query.Rmid);
            string orderType = fltRetModApplyEntity.OrderType == "M" ? "改签" : "退票";
            if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() != "administrator" &&
               query.Customer.Cid != fltRetModApplyEntity.Cid)
                throw new Exception($"查无此{orderType}申请");

            if (!string.IsNullOrEmpty(query.Customer?.UserID) && query.Customer.UserID.ToLower() == "administrator")
            {
                    throw new Exception($"管理员帐号不能取消{orderType}申请");
            }
            string orderStatus = FltModApplyStatusEnum.C.ToString();
            string wOrderStatus = FltModApplyStatusEnum.A.ToString();
            if (fltRetModApplyEntity.OrderType == "R")
            {
                orderStatus = FltRetApplyStatusEnum.C.ToString();
                wOrderStatus = FltRetApplyStatusEnum.A.ToString();
            }

            if (fltRetModApplyEntity.OrderStatus == orderStatus)
            {
                throw new Exception($"当前{orderType}申请已经取消！");
            }

            if (fltRetModApplyEntity.OrderStatus != wOrderStatus)
            {
                throw new Exception($"当前{orderType}申请无法取消！");
            }

           

            fltRetModApplyEntity.OrderStatus = orderStatus;
            _fltRetModApplyDal.Update(fltRetModApplyEntity, new string[] {"OrderStatus"});

            List<FltRetModFlightApplyEntity> fltRetModFlightApplyEntities =
                _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(n => n.Rmid == query.Rmid, true).ToList();
            foreach (var fltRetModFlightApplyEntity in fltRetModFlightApplyEntities)
            {
                fltRetModFlightApplyEntity.OrderStatus = orderStatus;
                _fltRetModFlightApplyDal.Update(fltRetModFlightApplyEntity, new string[] { "OrderStatus" });
            }


            FltRetModApplyLogEntity log = new FltRetModApplyLogEntity();
            log.LogTime = DateTime.Now;
            log.LogType = "取消申请";
            log.Oid = "Sys";
            log.Remark = "核价确认时取消了申请";
            log.Rmid = query.Rmid;
            _fltRetModApplyLogDal.Insert(log);


            return 0;
        }

        public bool CancelFltRetModApply(int rmid)
        {
            FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(rmid);
            if (fltRetModApplyEntity.OrderStatus == FltModApplyStatusEnum.C.ToString())
            {
                throw new Exception("当前申请已经取消！");
            }
            fltRetModApplyEntity.OrderStatus = FltModApplyStatusEnum.C.ToString();
            _fltRetModApplyDal.Update(fltRetModApplyEntity, new string[] { "OrderStatus" });
            List<FltRetModFlightApplyEntity> fltRetModFlightApplyEntities =
              _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(n => n.Rmid == rmid, true).ToList();
            foreach (var fltRetModFlightApplyEntity in fltRetModFlightApplyEntities)
            {
                fltRetModFlightApplyEntity.OrderStatus = fltRetModApplyEntity.OrderStatus;
                _fltRetModFlightApplyDal.Update(fltRetModFlightApplyEntity, new string[] { "OrderStatus" });
            }

            FltRetModApplyLogEntity log = new FltRetModApplyLogEntity();
            log.LogTime = DateTime.Now;
            log.LogType = "取消申请";
            log.Oid = "Sys";
            log.Remark = "取消申请";
            log.Rmid = rmid;
            _fltRetModApplyLogDal.Insert(log);

            return true;
        }
    }
}
