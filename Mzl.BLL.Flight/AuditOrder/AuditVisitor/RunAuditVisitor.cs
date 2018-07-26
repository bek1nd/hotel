using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Practices.ObjectBuilder2;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.IDAL.Flight;
using Mzl.Common.ConfigHelper;
using Mzl.Common.EnumHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Common.AuditOrder;

namespace Mzl.BLL.Flight.AuditOrder.AuditVisitor
{
    public class RunAuditVisitor : IRunAuditVisitor
    {
        #region 私有字段
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;
        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltRetModFlightApplyDal _fltRetModFlightApplyDal;
        private readonly IFltRetModApplyLogDal _fltRetModApplyLogDal;
        /// <summary>
        /// 请求机票订单审批信息
        /// </summary>
        private AuditFltOrderQueryModel _query;

        private AuditFltModApplyQueryModel _modApplyQuery;

        private AuditFltRetApplyQueryModel _retApplyQuery;

        /// <summary>
        /// 是否同意
        /// </summary>
        private bool IsAgree
        {
            get
            {
                if (_query != null)
                    return this._query.IsAgree;

                if (_modApplyQuery != null)
                    return this._modApplyQuery.IsAgree;

                if (_retApplyQuery != null)
                    return this._retApplyQuery.IsAgree;

                throw new Exception("IsAgree异常");
            }
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 机票改签申请审批构造
        /// </summary>
        public RunAuditVisitor(IFltRetModApplyDal fltRetModApplyDal,
           IFltRetModFlightApplyDal fltRetModFlightApplyDal, IFltRetModApplyLogDal fltRetModApplyLogDal, AuditFltModApplyQueryModel modApplyQuery)
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
            _modApplyQuery = modApplyQuery;
        }
        /// <summary>
        /// 机票退票申请审批构造
        /// </summary>
        public RunAuditVisitor(IFltRetModApplyDal fltRetModApplyDal,
            IFltRetModFlightApplyDal fltRetModFlightApplyDal, IFltRetModApplyLogDal fltRetModApplyLogDal,
            AuditFltRetApplyQueryModel retApplyQuery)
        {
            _fltRetModApplyDal = fltRetModApplyDal;
            _fltRetModFlightApplyDal = fltRetModFlightApplyDal;
            _fltRetModApplyLogDal = fltRetModApplyLogDal;
            _retApplyQuery = retApplyQuery;
        }

        /// <summary>
        /// 机票正单审批构造
        /// </summary>
        public RunAuditVisitor(IFltOrderDal fltOrderDal, IFltOrderLogDal fltOrderLogDal, AuditFltOrderQueryModel query)
        {
            _fltOrderDal = fltOrderDal;
            _fltOrderLogDal = fltOrderLogDal;
            this._query = query;
        } 
        #endregion

        #region 机票订单审批

        /// <summary>
        /// 一级审核
        /// </summary>
        /// <param name="firstAudit"></param>
        /// <returns></returns>
        public AuditResultModel DoFirstAudit(AuditOrderFirst firstAudit)
        {
            FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(_query.Id);
            FltOrderLogEntity log = new FltOrderLogEntity()
            {
                OrderId = fltOrderEntity.OrderId,
                LogTime = DateTime.Now,
                LogType = "审批订单",
                Oid="sys"
            };

          

            #region 审批操作

            bool isSendEmail = false;
            List<string> properties = new List<string>();
            if (IsAgree)
            {
                bool isHasSecond = _query.FltOrder.CPIdSecond.HasValue; //是否存在二级审批

                if (!isHasSecond)
                {
                    //1.2 如果不存在二级审批，则直接通过
                    fltOrderEntity.CheckStatus = FltOrderCheckStatusEnum.W.ToString();
                    log.Remark = string.Format("已通过{0}审批", _query.AuditCustomer?.RealName);
                }
                else
                {
                    isSendEmail = true;
                    //1.2 如果存在二级审批，则发送二级审批邮件
                    fltOrderEntity.CheckStatus = FltOrderCheckStatusEnum.S.ToString();
                    log.Remark = string.Format("已通过{0}审批，待二级审核", _query.AuditCustomer?.RealName);
                }
                properties.Add("CheckStatus");
            }
            else
            {
                //2.否决审批
                //2.1 取消订单
                if ((fltOrderEntity.ProcessStatus & 8) == 8)
                    throw new Exception("该订单已经出票，不能否决，请联系客服");
                fltOrderEntity.CheckStatus = FltOrderCheckStatusEnum.J.ToString();
                fltOrderEntity.Orderstatus = "C";
                fltOrderEntity.CancelType = "C";
                //log.Remark = "订单审核状态：一级审核不通过。一级审核人:" + _query.AuditCustomer?.RealName;
                log.Remark = string.Format("已被{0}拒绝", _query.AuditCustomer?.RealName);
                properties.Add("CheckStatus");
                properties.Add("CancelType");
                properties.Add("Orderstatus");
            }

            #endregion

           

            _fltOrderDal.Update(fltOrderEntity, properties.ToArray());
            _fltOrderLogDal.Insert(log);

            //发送邮件
            if (isSendEmail)
            {
                SendEmail(fltOrderEntity);
            }

            return new AuditResultModel()
            {
                Code=0,
                AuditResult = log.Remark,
                NextAuditCid = fltOrderEntity.CPIdSecond,
                OwnCid= fltOrderEntity.Cid,
                Id= fltOrderEntity.OrderId,
                OrderType= OrderSourceTypeEnum.Flt
            };
        }

        /// <summary>
        /// 二级审核
        /// </summary>
        /// <param name="secondAudit"></param>
        /// <returns></returns>
        public AuditResultModel DoSecondAudit(AuditOrderSecond secondAudit)
        {
            FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(_query.Id);
            FltOrderLogEntity log = new FltOrderLogEntity()
            {
                OrderId = fltOrderEntity.OrderId,
                LogTime = DateTime.Now,
                LogType = "审批订单"
            };

            #region 审批操作
            List<string> properties = new List<string>();
            if (IsAgree)
            {
                //1.通过审批
                fltOrderEntity.CheckStatus = FltOrderCheckStatusEnum.W.ToString();
                log.Remark = "订单审核状态：二级审核通过。二级审核人:" + _query.AuditCustomer?.RealName;
                properties.Add("CheckStatus");
            }
            else
            {
                if ((fltOrderEntity.ProcessStatus & 8) == 8)
                    throw new Exception("该订单已经出票，不能否决，请联系客服");
                //2.否决审批
                fltOrderEntity.CheckStatus = FltOrderCheckStatusEnum.J.ToString();
                fltOrderEntity.Orderstatus = "C";
                fltOrderEntity.CancelType = "C";
                log.Remark = "订单审核状态：一级审核不通过。一级审核人:" + _query.AuditCustomer?.RealName;
                properties.Add("CheckStatus");
                properties.Add("CancelType");
                properties.Add("Orderstatus");
            }

            #endregion

            _fltOrderDal.Update(fltOrderEntity);
            _fltOrderLogDal.Insert(log);

            return new AuditResultModel()
            {
                Code = 0,
                AuditResult = log.Remark,
                OwnCid = fltOrderEntity.Cid,
                Id = fltOrderEntity.OrderId,
                OrderType = OrderSourceTypeEnum.Flt
            };
        }
        #endregion

        #region 改签申请审批
        public AuditResultModel DoFirstAudit(AuditModApplyFirst firstAudit)
        {
            return null;
        }

        public AuditResultModel DoSecondAudit(AuditModApplySecond secondAudit)
        {
            FltRetModApplyEntity modApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(_modApplyQuery.Id);
            List<FltRetModFlightApplyEntity> modFlightApplyEntities =
                _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(n => n.Rmid == modApplyEntity.Rmid).ToList();

            FltRetModApplyLogEntity log = new FltRetModApplyLogEntity()
            {
                Rmid = modApplyEntity.Rmid,
                Oid = "sys",
                LogType = "审批申请",
                LogTime = DateTime.Now
            };

            #region 进行审批
            List<string> properties = new List<string>();
            if (IsAgree)
            {
                modApplyEntity.OrderStatus = FltModApplyStatusEnum.P.ToString();
                log.Remark = "改签申请审核状态：二级审核通过。二级审核人:" + _modApplyQuery.AuditCustomer?.RealName;
            }
            else
            {
                modApplyEntity.OrderStatus = FltModApplyStatusEnum.C.ToString();
                log.Remark = "改签申请审核状态：二级审核不通过。二级审核人:" + _modApplyQuery.AuditCustomer?.RealName;
            } 
            #endregion

            modFlightApplyEntities.ForEach(n => n.OrderStatus = modApplyEntity.OrderStatus);
            properties.Add("OrderStatus");

            _fltRetModApplyDal.Update(modApplyEntity, properties.ToArray());
            modFlightApplyEntities.ForEach(n =>
            {
                _fltRetModFlightApplyDal.Update(n, properties.ToArray());
            });
            _fltRetModApplyLogDal.Insert(log);

            return new AuditResultModel()
            {
                Code = 0,
                AuditResult = log.Remark,
                OwnCid = modApplyEntity.Cid,
                Id = modApplyEntity.Rmid,
                OrderType = OrderSourceTypeEnum.FltModApply
            };
        }

        #endregion

        #region 退票申请审批
        public AuditResultModel DoFirstAudit(AuditRetApplyFirst firstAudit)
        {
            return null;
        }

        public AuditResultModel DoSecondAudit(AuditRetApplySecond secondAudit)
        {
            FltRetModApplyEntity retApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(_retApplyQuery.Id);
            List<FltRetModFlightApplyEntity> retFlightApplyEntities =
                _fltRetModFlightApplyDal.Query<FltRetModFlightApplyEntity>(n => n.Rmid == retApplyEntity.Rmid).ToList();

            FltRetModApplyLogEntity log = new FltRetModApplyLogEntity()
            {
                Rmid = retApplyEntity.Rmid,
                Oid = "sys",
                LogType = "审批申请",
                LogTime = DateTime.Now
            };

            #region 进行审批
            List<string> properties = new List<string>();
            if (IsAgree)
            {
                retApplyEntity.OrderStatus = FltRetApplyStatusEnum.D.ToString();
                log.Remark = "退票申请审核状态：二级审核通过。二级审核人:" + _retApplyQuery?.AuditCustomer?.RealName;
            }
            else
            {
                retApplyEntity.OrderStatus = FltRetApplyStatusEnum.C.ToString();
                log.Remark = "退票申请审核状态：二级审核不通过。二级审核人:" + _retApplyQuery?.AuditCustomer?.RealName;
            }
            #endregion

            retFlightApplyEntities.ForEach(n => n.OrderStatus = retApplyEntity.OrderStatus);
            properties.Add("OrderStatus");

            _fltRetModApplyDal.Update(retApplyEntity, properties.ToArray());
            retFlightApplyEntities.ForEach(n =>
            {
                _fltRetModFlightApplyDal.Update(n, properties.ToArray());
            });
            _fltRetModApplyLogDal.Insert(log);

            return new AuditResultModel()
            {
                Code = 0,
                AuditResult = log.Remark,
                OwnCid = retApplyEntity.Cid,
                Id = retApplyEntity.Rmid,
                OrderType = OrderSourceTypeEnum.FltRetApply
            };
        }
        #endregion


        #region 私有方法
        private string SendEmail(FltOrderEntity fltOrderEntity)
        {
            return null;
            //string url = AppSettingsHelper.GetAppSettings(AppSettingsEnum.FltOrderSecondAuditEmail);
            //url = string.Format("{0}&odid={1}&Oid={2}", url, fltOrderEntity.OrderId, fltOrderEntity.CreateOid);
            //return GetHelper.GetUrl(url);
        } 
        #endregion
    }
}
