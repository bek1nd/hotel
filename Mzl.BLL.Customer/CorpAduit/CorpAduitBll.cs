using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.Common.EnumHelper.CorpAduit;
using Mzl.DomainModel.Customer.CorpAduit;
using Mzl.EntityModel.Customer.Corporation.CorpAudit;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.CorpAduit;
using Mzl.IDAL.Customer.Corporation;
using Mzl.Common.Exceptions;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Train.Order;

namespace Mzl.BLL.Customer.CorpAduit
{
    internal class CorpAduitBll : BaseBll, ICorpAduitBll
    {
        private readonly ICorpAduitOrderDal _corpAduitOrderDal;
        private readonly ICorpAduitOrderDetailDal _corpAduitOrderDetailDal;
        private readonly ICorpAduitOrderFlowDal _corpAduitOrderFlowDal;
        private readonly ICorpAduitOrderLogDal _corpAduitOrderLogDal;

        private readonly ICorpAduitConfigDal _corpAduitConfigDal;//审批规则
        private readonly ICorpAduitConfigDetailDal _corpAduitConfigDetailDal;//审批规则明细

        public CorpAduitBll(ICorpAduitOrderDal corpAduitOrderDal,
        ICorpAduitOrderFlowDal corpAduitOrderFlowDal, ICorpAduitOrderLogDal corpAduitOrderLogDal,
         ICorpAduitConfigDal corpAduitConfigDal, ICorpAduitConfigDetailDal corpAduitConfigDetailDal,
         ICorpAduitOrderDetailDal corpAduitOrderDetailDal)
        {
            _corpAduitOrderDal = corpAduitOrderDal;
            _corpAduitOrderFlowDal = corpAduitOrderFlowDal;
            _corpAduitOrderLogDal = corpAduitOrderLogDal;
            _corpAduitConfigDal = corpAduitConfigDal;
            _corpAduitConfigDetailDal = corpAduitConfigDetailDal;
            _corpAduitOrderDetailDal = corpAduitOrderDetailDal;
        }

        /// <summary>
        /// 提交审批
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int SubmitAduit(SubmitAduitModel model)
        {
            CorpAduitConfigEntity corpAduitConfigEntity =
                _corpAduitConfigDal.Find<CorpAduitConfigEntity>(model.AduitConfigId);
            if (corpAduitConfigEntity.IsNeedAduit == 0)
            {
                return 0;
            }

            #region 判断待审批订单是否存在没有处理的审批流程

            List<int> orderidList = new List<int>();
            model.OrderInfoList.ForEach(n => { orderidList.Add(n.OrderId); });
            List<CorpAduitOrderDetailEntity> checkList =
                (from n in base.Context.Set<CorpAduitOrderDetailEntity>()
                    join o in base.Context.Set<CorpAduitOrderEntity>() on n.AduitOrderId equals o.AduitOrderId
                    where o.Status != 6 && o.Status != 7
                          && orderidList.Contains(n.OrderId)
                    select n).ToList();
            if (checkList != null && checkList.Count > 0)
            {
                return 0;
            }

            #endregion

            #region 生成审批单

            #region 获取审批规则环节

            List<CorpAduitConfigDetailEntity> corpAduitConfigDetailEntities =
                _corpAduitConfigDetailDal.Query<CorpAduitConfigDetailEntity>(
                    n => n.ConfigId == model.AduitConfigId && n.OrderType == (int) model.OrderType,
                    true).OrderBy(n => n.AduitLevel).ToList();
            if (corpAduitConfigDetailEntities == null || corpAduitConfigDetailEntities.Count == 0)
            {
                return 0;
            }

            List<CorpAduitConfigDetailEntity> aduitConfigDetailList = new List<CorpAduitConfigDetailEntity>();

            //判断当前是不是存在审批环节
            foreach (var corpAduitConfigDetailEntity in corpAduitConfigDetailEntities)
            {
                if (model.IsViolatePolicy) //当前订单违背差旅政策
                {
                    if ((corpAduitConfigDetailEntity.PolicyTypeAduit & (int) PolicyTypeAduitEnum.V) ==
                        (int) PolicyTypeAduitEnum.V)
                    {
                        aduitConfigDetailList.Add(corpAduitConfigDetailEntity);
                    }
                }
                else //当前订单符合差旅政策
                {
                    if ((corpAduitConfigDetailEntity.PolicyTypeAduit & (int) PolicyTypeAduitEnum.A) ==
                        (int) PolicyTypeAduitEnum.A)
                    {
                        aduitConfigDetailList.Add(corpAduitConfigDetailEntity);
                    }
                }
            }

            if (aduitConfigDetailList.Count == 0)
                return 0;


            #endregion

            #region 新增审批单

            //int finalFlow = aduitConfigDetailList[aduitConfigDetailList.Count - 1].AduitLevel;

            CorpAduitOrderEntity corpAduitOrderEntity = new CorpAduitOrderEntity()
            {
                AduitConfigId = model.AduitConfigId,
                Status = (int) CorpAduitOrderStatusEnum.N,
                CurrentFlow = -1,
                FinalFlow = 0,
                CreateTime = DateTime.Now
            };
            corpAduitOrderEntity = _corpAduitOrderDal.Insert<CorpAduitOrderEntity>(corpAduitOrderEntity);

            #endregion

            #region 新增审批单与订单的关系

            foreach (var detail in model.OrderInfoList)
            {
                _corpAduitOrderDetailDal.Insert<CorpAduitOrderDetailEntity>(new CorpAduitOrderDetailEntity()
                {
                    OrderId = detail.OrderId,
                    OrderType = (int) detail.OrderType,
                    AduitOrderId = corpAduitOrderEntity.AduitOrderId
                });
            }

            #endregion

            #region 新增审批环节

            //1.创建审批环节
            _corpAduitOrderFlowDal.Insert<CorpAduitOrderFlowEntity>(new CorpAduitOrderFlowEntity()
            {
                AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                Flow = -1,
                FlowCid = model.SubmitCid,
                DealResult = (int) AduitDealResultEnum.S
            });
            //2.送审环节
            _corpAduitOrderFlowDal.Insert<CorpAduitOrderFlowEntity>(new CorpAduitOrderFlowEntity()
            {
                AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                Flow = 0,
                FlowCid = model.SubmitCid
            });

            /***
             * 3.审批人审批环节
             * 重新对审批人环节进行了排序
             * **/
            int nLevel = 1;
            int? nowLevel = null;
            foreach (var aduitConfigDetail in aduitConfigDetailList)
            {
                if (nowLevel.HasValue)
                {
                    if (nowLevel.Value != aduitConfigDetail.AduitLevel)
                    {
                        nLevel++;
                        nowLevel = aduitConfigDetail.AduitLevel;
                    }
                }
                else
                {
                    nowLevel = aduitConfigDetail.AduitLevel;
                }

                _corpAduitOrderFlowDal.Insert<CorpAduitOrderFlowEntity>(new CorpAduitOrderFlowEntity()
                {
                    AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                    Flow = nLevel,
                    FlowCid = aduitConfigDetail.AduitCid
                });
            }

            #endregion

            corpAduitOrderEntity.FinalFlow = nLevel;
            _corpAduitOrderDal.Update<CorpAduitOrderEntity>(corpAduitOrderEntity, new string[] {"FinalFlow"});

            #region 新增送审日志

            CorpAduitOrderLogEntity log = new CorpAduitOrderLogEntity()
            {
                LogTime = DateTime.Now,
                Source = model.DealSource,
                AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                DealCid = model.SubmitCid,
                DealOid = model.SubmitOid,
                DealResult = (int) AduitDealResultEnum.S,
                AduitFlow = corpAduitOrderEntity.CurrentFlow
            };
            log.AduitType = (log.Source == "O" ? (int) AduitTypeEnum.T : (int) AduitTypeEnum.N);
            _corpAduitOrderLogDal.Insert<CorpAduitOrderLogEntity>(log);

            #endregion

            #endregion

            return corpAduitOrderEntity.AduitOrderId;
        }

        /// <summary>
        /// 送审
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseDealAduitResultModel DeliveAduit(DeliveAduitModel model)
        {
            //获取审批单信息
            CorpAduitOrderEntity corpAduitOrderEntity = _corpAduitOrderDal.Find<CorpAduitOrderEntity>(model.AduitOrderId);
            if (corpAduitOrderEntity.Status != (int) CorpAduitOrderStatusEnum.N)
            {
                throw new Exception("当前审批单状态异常");
            }
            corpAduitOrderEntity.CurrentFlow = corpAduitOrderEntity.CurrentFlow + 1;//设置下一级

            CorpAduitOrderFlowEntity corpAduitOrderFlowEntity =
                _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                    n => n.Flow == corpAduitOrderEntity.CurrentFlow && n.AduitOrderId == model.AduitOrderId)
                    .FirstOrDefault();

            if(corpAduitOrderFlowEntity==null)
                throw new Exception("当前审批单流程异常");
            if(corpAduitOrderFlowEntity.FlowCid!= model.DealCid)
                throw new Exception("无权操作");

            corpAduitOrderFlowEntity.DealResult = (int) AduitDealResultEnum.W;//设置送审

            #region 记日志
            CorpAduitOrderLogEntity log = new CorpAduitOrderLogEntity()
            {
                LogTime = DateTime.Now,
                Source = model.DealSource,
                AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                DealOid = model.DealOid,
                DealCid = model.DealCid,
                DealResult = (int)corpAduitOrderFlowEntity.DealResult,
                AduitFlow = corpAduitOrderEntity.CurrentFlow
            };
            log.AduitType = (log.Source == "O" ? (int) AduitTypeEnum.T : (int) AduitTypeEnum.N);
            _corpAduitOrderLogDal.Insert<CorpAduitOrderLogEntity>(log); 
            #endregion

            List<int> nextFlowCidList = new List<int>();
            //判断当前状态是否等于最终状态，如果相同则设置终结状态
            if (corpAduitOrderEntity.FinalFlow == corpAduitOrderEntity.CurrentFlow)
            {
                corpAduitOrderEntity.Status = (int) CorpAduitOrderStatusEnum.F;//设置完成
            }
            else
            {
                #region 判断下一环节是否汇审
                corpAduitOrderEntity.CurrentFlow = corpAduitOrderEntity.CurrentFlow + 1;//设置下一级

                List<CorpAduitOrderFlowEntity> corpAduitOrderFlowEntities =
                    _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                        n => n.Flow == corpAduitOrderEntity.CurrentFlow && n.AduitOrderId == model.AduitOrderId, true)
                        .ToList();

                if (corpAduitOrderFlowEntities.Count == 1)//下一环节只有一个处理人
                {
                    corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.W;
                }
                else if (corpAduitOrderFlowEntities.Count > 1)//下一环节多个处理人，认为是汇审
                {
                    corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.W1;
                }
                else
                {
                    throw new Exception("送审阶段异常");
                }

                nextFlowCidList = corpAduitOrderFlowEntities.Select(n => n.FlowCid).ToList();
                #endregion
            }

            //保存审批单修改
            _corpAduitOrderDal.Update<CorpAduitOrderEntity>(corpAduitOrderEntity, new string[] {"Status", "CurrentFlow"});

            //设置环节结果
            _corpAduitOrderFlowDal.Update<CorpAduitOrderFlowEntity>(corpAduitOrderFlowEntity,
                new string[] { "DealResult" });

            BaseDealAduitResultModel resultModel = new BaseDealAduitResultModel()
            {
                AduitOrderId = model.AduitOrderId,
                IsSuccessed = true,
                CreateAduitOrderCid = model.DealCid,
                IsFinished = false,
                NextFlowCidList = nextFlowCidList
            };

            return resultModel;
        }

        /// <summary>
        /// 审批
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BaseDealAduitResultModel DoAduit(BaseDealAduitModel model)
        {
            CorpAduitOrderEntity corpAduitOrderEntity = _corpAduitOrderDal.Find<CorpAduitOrderEntity>(model.AduitOrderId);
            List<int> statusList = new List<int>()
            {
                (int)CorpAduitOrderStatusEnum.W,
                (int)CorpAduitOrderStatusEnum.P,
                (int)CorpAduitOrderStatusEnum.W1,
                (int)CorpAduitOrderStatusEnum.P1,
                (int)CorpAduitOrderStatusEnum.P2
            };

            if (corpAduitOrderEntity.Status == (int) CorpAduitOrderStatusEnum.J)
            {
                throw new Exception("当前审批已被拒绝");
            }

            if (!statusList.Contains(corpAduitOrderEntity.Status))
            {
                throw new Exception("当前审批单状态异常");
            }

            if(corpAduitOrderEntity.CurrentFlow!= model.CurrentFlow)
                throw new Exception("当前审批环节异常");

           
            //获取当前环节信息
            List<CorpAduitOrderFlowEntity> flowList =
                _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(n => n.AduitOrderId == model.AduitOrderId)
                    .ToList();

            //判断当前审批单订单是否已经被取消
            if (!CheckOrderIsCancel(corpAduitOrderEntity))
            {
                throw new MojoryException(MojoryApiResponseCode.AduitCancelOrder, "审批单中的订单已经被取消，系统自动设置审批单过期",
                    flowList.Find(n => n.Flow == -1).FlowCid);
            }

            List<CorpAduitOrderFlowEntity> corpAduitOrderFlowEntities =
                flowList.FindAll(n => n.Flow == corpAduitOrderEntity.CurrentFlow);

            List<int> nextFlowCidList = new List<int>();
            if (corpAduitOrderFlowEntities.Count == 1)
            {
                SingleAduit(model, corpAduitOrderEntity, corpAduitOrderFlowEntities[0], ref nextFlowCidList);
            }
            else if (corpAduitOrderFlowEntities.Count > 1)
            {
                TogetherAduit(model, corpAduitOrderEntity, corpAduitOrderFlowEntities, ref nextFlowCidList);
            }

            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(n => n.AduitOrderId == model.AduitOrderId,
                    true).ToList();

            BaseDealAduitResultModel resultModel = new BaseDealAduitResultModel()
            {
                AduitOrderId = model.AduitOrderId,
                IsSuccessed = true,
                DetailList = new List<BaseDealAduitResultDetailModel>(),
                CreateAduitOrderCid = flowList.Find(n => n.Flow == -1).FlowCid,
                IsFinished =
                    (corpAduitOrderEntity.Status == (int) CorpAduitOrderStatusEnum.F ||
                     corpAduitOrderEntity.Status == (int) CorpAduitOrderStatusEnum.J),
                NextFlowCidList = nextFlowCidList,
                AduitOrderStatus = corpAduitOrderEntity.Status.ValueToEnum<CorpAduitOrderStatusEnum>()
            };

            corpAduitOrderDetailEntities.ForEach(n =>
            {
                resultModel.DetailList.Add(new BaseDealAduitResultDetailModel()
                {
                    OrderId = n.OrderId,
                    OrderSourceType = n.OrderType.ValueToEnum<OrderSourceTypeEnum>()
                });
            });

            return resultModel;
        }

        #region 私有方法
        /// <summary>
        /// 单审
        /// </summary>
        /// <returns></returns>
        private bool SingleAduit(BaseDealAduitModel model, CorpAduitOrderEntity corpAduitOrderEntity,
            CorpAduitOrderFlowEntity corpAduitOrderFlowEntity,ref List<int> nextFlowCidList)
        {
            if (corpAduitOrderFlowEntity == null)
                throw new Exception("当前审批单流程异常");
            if (corpAduitOrderFlowEntity.FlowCid != model.DealCid)
                throw new Exception("无权操作");

            corpAduitOrderFlowEntity.DealResult = (model.IsAgree
                ? (int)AduitDealResultEnum.F
                : (int)AduitDealResultEnum.C);

            #region 记日志
            CorpAduitOrderLogEntity log = new CorpAduitOrderLogEntity()
            {
                LogTime = DateTime.Now,
                Source = model.DealSource,
                AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                DealOid = model.DealOid,
                DealCid = model.DealCid,
                DealResult = (int)corpAduitOrderFlowEntity.DealResult,
                AduitFlow = corpAduitOrderEntity.CurrentFlow,
                AduitReason = model.AduitReason
            };
            log.AduitType = (log.Source == "O" ? (int)AduitTypeEnum.T : (int)AduitTypeEnum.N);
            _corpAduitOrderLogDal.Insert<CorpAduitOrderLogEntity>(log);
            #endregion

            //审批不通过
            if (corpAduitOrderFlowEntity.DealResult == (int)AduitDealResultEnum.C)
            {
                corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.J;
            }
            else
            {
                if (corpAduitOrderEntity.FinalFlow == corpAduitOrderEntity.CurrentFlow)
                {
                    corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.F;//设置完成
                }
                else
                {
                    /*******当前环节+1*****/
                    corpAduitOrderEntity.CurrentFlow = corpAduitOrderEntity.CurrentFlow + 1;
                    #region 判断下一环节是否汇审

                    List<CorpAduitOrderFlowEntity> corpAduitOrderFlowEntities =
                        _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                            n => n.Flow == corpAduitOrderEntity.CurrentFlow && n.AduitOrderId == model.AduitOrderId,
                            true).ToList();

                    if (corpAduitOrderFlowEntities.Count == 1)//下一环节只有一个处理人
                    {
                        corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P;
                    }
                    else if (corpAduitOrderFlowEntities.Count > 1)//下一环节多个处理人，认为是汇审
                    {
                        corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P1;
                    }
                    else
                    {
                        throw new Exception("送审阶段异常");
                    }
                    nextFlowCidList = corpAduitOrderFlowEntities.Select(n => n.FlowCid).ToList();
                    #endregion
                }
            }

            //保存审批单修改
            _corpAduitOrderDal.Update<CorpAduitOrderEntity>(corpAduitOrderEntity, new string[] { "Status", "CurrentFlow" });

            //设置环节结果
            _corpAduitOrderFlowDal.Update<CorpAduitOrderFlowEntity>(corpAduitOrderFlowEntity,
                new string[] { "DealResult" });

            return true;
        }

        /// <summary>
        /// 汇审
        /// </summary>
        /// <returns></returns>
        private bool TogetherAduit(BaseDealAduitModel model, CorpAduitOrderEntity corpAduitOrderEntity,
            List<CorpAduitOrderFlowEntity> corpAduitOrderFlowEntities,ref List<int> nextFlowCidList)
        {
            if (corpAduitOrderFlowEntities == null || corpAduitOrderFlowEntities.Count == 0)
                throw new Exception("当前审批单流程异常");
            List<int> flowCidList = new List<int>();
            corpAduitOrderFlowEntities.ForEach(n => { flowCidList.Add(n.FlowCid); });
            if (!flowCidList.Contains(model.DealCid))
                throw new Exception("无权操作");

            //根据审批人获取当前审批环节
            CorpAduitOrderFlowEntity corpAduitOrderFlowEntity =
                corpAduitOrderFlowEntities.Find(n => n.FlowCid == model.DealCid && n.AduitOrderId == model.AduitOrderId);

            if (corpAduitOrderFlowEntity.DealResult.HasValue)
                throw new Exception("您已经审批过了");

            var isDealFlow =
                 corpAduitOrderFlowEntities.Find(n => !n.DealResult.HasValue && n.FlowCid != model.DealCid);//获取当前环节没有处理的

            corpAduitOrderFlowEntity.DealResult = (model.IsAgree
               ? (int)AduitDealResultEnum.F
               : (int)AduitDealResultEnum.C);

            #region 记日志
            CorpAduitOrderLogEntity log = new CorpAduitOrderLogEntity()
            {
                LogTime = DateTime.Now,
                Source = model.DealSource,
                AduitOrderId = corpAduitOrderEntity.AduitOrderId,
                DealOid = model.DealOid,
                DealCid = model.DealCid,
                DealResult = (int)corpAduitOrderFlowEntity.DealResult,
                AduitFlow = corpAduitOrderEntity.CurrentFlow,
                AduitReason=model.AduitReason
            };
            log.AduitType = (log.Source == "O" ? (int)AduitTypeEnum.T : (int)AduitTypeEnum.N);
            _corpAduitOrderLogDal.Insert<CorpAduitOrderLogEntity>(log);
            #endregion

            //审批不通过，则取消审批单
            if (corpAduitOrderFlowEntity.DealResult == (int)AduitDealResultEnum.C)
            {
                corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.J;
            }
            else
            {
                if (isDealFlow != null)
                {
                    //有存在除开自己的没处理人
                    CorpAduitConfigEntity corpAduitConfigEntity =
                        _corpAduitConfigDal.Find<CorpAduitConfigEntity>(corpAduitOrderEntity.AduitConfigId);
                    if (corpAduitConfigEntity.TogetherAduitType == 0)  //判断是否需要全部审批
                    {
                        //设置汇审中
                        corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P2;
                    }
                    else
                    {
                        if (corpAduitOrderEntity.FinalFlow == corpAduitOrderEntity.CurrentFlow)
                        {
                            corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.F;//设置完成
                        }
                        else
                        {
                            /*******当前环节+1*****/
                            corpAduitOrderEntity.CurrentFlow = corpAduitOrderEntity.CurrentFlow + 1;
                            #region 判断下一环节是否汇审
                            List<CorpAduitOrderFlowEntity> nextFlowList =
                                _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                                    n => n.Flow == corpAduitOrderEntity.CurrentFlow && n.AduitOrderId == model.AduitOrderId, true).ToList();

                            if (nextFlowList.Count == 1)//下一环节只有一个处理人
                            {
                                corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P;
                            }
                            else if (nextFlowList.Count > 1)//下一环节多个处理人，认为是汇审
                            {
                                corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P1;
                            }
                            else
                            {
                                throw new Exception("送审阶段异常");
                            }
                            nextFlowCidList = corpAduitOrderFlowEntities.Select(n => n.FlowCid).ToList();
                            #endregion
                        }

                    }
                 
                }
                else
                {
                    //只有当前审批人没有处理的情况
                    if (corpAduitOrderEntity.FinalFlow == corpAduitOrderEntity.CurrentFlow)
                    {
                        corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.F;//设置完成
                    }
                    else
                    {
                        /*******当前环节+1*****/
                        corpAduitOrderEntity.CurrentFlow = corpAduitOrderEntity.CurrentFlow + 1;
                        #region 判断下一环节是否汇审
                        List<CorpAduitOrderFlowEntity> nextFlowList =
                            _corpAduitOrderFlowDal.Query<CorpAduitOrderFlowEntity>(
                                n => n.Flow == corpAduitOrderEntity.CurrentFlow && n.AduitOrderId == model.AduitOrderId, true).ToList();

                        if (nextFlowList.Count == 1)//下一环节只有一个处理人
                        {
                            corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P;
                        }
                        else if (nextFlowList.Count > 1)//下一环节多个处理人，认为是汇审
                        {
                            corpAduitOrderEntity.Status = (int)CorpAduitOrderStatusEnum.P1;
                        }
                        else
                        {
                            throw new Exception("送审阶段异常");
                        }
                        nextFlowCidList = corpAduitOrderFlowEntities.Select(n => n.FlowCid).ToList();
                        #endregion
                    }
                }
            }

            //保存审批单修改
            _corpAduitOrderDal.Update<CorpAduitOrderEntity>(corpAduitOrderEntity, new string[] { "Status", "CurrentFlow" });

            //设置环节结果
            _corpAduitOrderFlowDal.Update<CorpAduitOrderFlowEntity>(corpAduitOrderFlowEntity,
                new string[] { "DealResult" });
            return true;
        }

        /// <summary>
        /// 判断当前审批单中的单据是否被取消
        /// </summary>
        private bool CheckOrderIsCancel(CorpAduitOrderEntity corpAduitOrderEntity)
        {
            bool isCancel = false;

            List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(n => n.AduitOrderId == corpAduitOrderEntity.AduitOrderId,
                    true).ToList();
            List<BaseDealAduitResultDetailModel> list = new List<BaseDealAduitResultDetailModel>();
            corpAduitOrderDetailEntities.ForEach(n =>
            {
                list.Add(new BaseDealAduitResultDetailModel()
                {
                    OrderId = n.OrderId,
                    OrderSourceType = n.OrderType.ValueToEnum<OrderSourceTypeEnum>()
                });
            });

            foreach (BaseDealAduitResultDetailModel orderModel in list)
            {
                if (orderModel.OrderSourceType== OrderSourceTypeEnum.Flt)
                {
                    FltOrderEntity orderEntity =
                        base.Context.Set<FltOrderEntity>().Find(orderModel.OrderId);
                    if (orderEntity?.Orderstatus == "C" || orderEntity?.Orderstatus == "c")
                    {
                        isCancel = true;
                    }
                }
                else if (orderModel.OrderSourceType == OrderSourceTypeEnum.FltModApply ||
                    orderModel.OrderSourceType == OrderSourceTypeEnum.FltRetApply)
                {
                    FltRetModApplyEntity flightApplyEntity = base.Context.Set<FltRetModApplyEntity>().Find(orderModel.OrderId);
                    if (flightApplyEntity?.OrderStatus == "C" || flightApplyEntity?.OrderStatus == "c")
                    {
                        isCancel = true;
                    }
                }
                else if (orderModel.OrderSourceType == OrderSourceTypeEnum.Tra)
                {
                    TraOrderStatusEntity orderStatusEntity =
                        base.Context.Set<TraOrderStatusEntity>().FirstOrDefault(n => n.OrderId== orderModel.OrderId);
                    if (orderStatusEntity?.IsCancle == 1)
                    {
                        isCancel = true;
                    }
                }
            }

            if (isCancel)
            {
                corpAduitOrderEntity.IsDel = 1;
                _corpAduitOrderDal.Update<CorpAduitOrderEntity>(corpAduitOrderEntity, new string[] { "IsDel" });
                return false;
            }

            return true;
        }

        #endregion
        #region  查询审批详细
        public List<BaseDealAduitResultDetailModel> GetCorpAduitOrderDetail(int aduitOrderId)
        {
                List<CorpAduitOrderDetailEntity> corpAduitOrderDetailEntities =
                _corpAduitOrderDetailDal.Query<CorpAduitOrderDetailEntity>(n => n.AduitOrderId == aduitOrderId,
                    true).ToList();
            List<BaseDealAduitResultDetailModel> list = new List<BaseDealAduitResultDetailModel>();
            corpAduitOrderDetailEntities.ForEach(n =>
            {
                list.Add(new BaseDealAduitResultDetailModel()
                {
                    OrderId = n.OrderId,
                    OrderSourceType = n.OrderType.ValueToEnum<OrderSourceTypeEnum>()
                });
            });
            return list;
        }
               
        #endregion

    }
}
