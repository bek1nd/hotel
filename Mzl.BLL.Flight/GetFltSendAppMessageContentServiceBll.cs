using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.EntityModel.Common;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;

namespace Mzl.BLL.Flight
{
    public class GetFltSendAppMessageContentServiceBll : BaseServiceBll, IGetFltSendAppMessageContentServiceBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IAirPortDal _airPortDal;

        private readonly IFltRetModApplyDal _fltRetModApplyDal;
        private readonly IFltModOrderDal _fltModOrderDal;
        private readonly IFltRefundOrderDal _fltRefundOrderDal;

        public GetFltSendAppMessageContentServiceBll(IFltOrderDal fltOrderDal, IFltRetModApplyDal fltRetModApplyDal,
            IFltModOrderDal fltModOrderDal, IFltRefundOrderDal fltRefundOrderDal,
            IFltPassengerDal fltPassengerDal, IFltFlightDal fltFlightDal, IAirPortDal airPortDal)
        {
            _fltOrderDal = fltOrderDal;
            _fltPassengerDal = fltPassengerDal;
            _fltFlightDal = fltFlightDal;
            _airPortDal = airPortDal;

            _fltRetModApplyDal = fltRetModApplyDal;
            _fltModOrderDal = fltModOrderDal;
            _fltRefundOrderDal = fltRefundOrderDal;
        }

        public void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels)
        {
            foreach (SendAppMessageModel sendAppMessageModel in sendAppMessageModels)
            {
                //出票通知内容
                GetFltPrintTicketMessage(sendAppMessageModel);
                GetFltModPrintTicketMessage(sendAppMessageModel);
                //核价通知内容
                GetFltModApplyConfireAuditPriceMessage(sendAppMessageModel);
                GetFltRetApplyConfireAuditPriceMessage(sendAppMessageModel);
                //退客户通知内容
                GetFltRefundedCustomerMessage(sendAppMessageModel);
            }
        }

        public void GetSendEmailMessage(List<SendAppMessageModel> sendAppMessageModels)
        {
            foreach (SendAppMessageModel sendAppMessageModel in sendAppMessageModels)
            {
                GetFltPrintTicketEmail(sendAppMessageModel);
            }
        }

        #region 出票通知
        /// <summary>
        /// 获取机票出票推送内容
        /// </summary>
        /// <returns></returns>
        private void GetFltPrintTicketMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.Flt &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.PrintTicketNotice)
            {
                FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的机票订单{0}已经出票，请确认", fltOrderEntity.OrderId);
            }
        }
        /// <summary>
        /// 机票改签出票推送信息
        /// </summary>
        /// <returns></returns>
        private void GetFltModPrintTicketMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltMod &&
               sendAppMessageModel.SendType == SendAppMessageTypeEnum.PrintTicketNotice)
            {
                FltModOrderEntity fltModOrderEntity= _fltModOrderDal.Find<FltModOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的机票订单{0}已经改签出票成功，请确认", fltModOrderEntity.OrderId);
            }
        }
        #endregion

        #region 核价待确认通知
        /// <summary>
        /// 改签申请核价待确认
        /// </summary>
        /// <returns></returns>
        private void GetFltModApplyConfireAuditPriceMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltModApply &&
               sendAppMessageModel.SendType == SendAppMessageTypeEnum.ConfireAuditPriceNotice)
            {
                FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的机票改签申请{0}已经核价成功，请确认核价", fltRetModApplyEntity.OrderId);
            }
        }

        /// <summary>
        /// 退票申请核价待确认
        /// </summary>
        /// <returns></returns>
        private void GetFltRetApplyConfireAuditPriceMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltRetApply &&
               sendAppMessageModel.SendType == SendAppMessageTypeEnum.ConfireAuditPriceNotice)
            {
                FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("您的机票退票申请{0}已经核价成功，请确认核价", fltRetModApplyEntity.OrderId);
            }
        }
        #endregion

        #region 待审批通知
        /// <summary>
        /// 机票待审批通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetFltWaitAuditMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.Flt &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.WaitAuditNotice)
            {
                FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("机票订单{0}需要您进行审批", fltOrderEntity.OrderId);
            }
        }
        /// <summary>
        /// 机票改签申请待审批通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetFltModApplyWaitAuditMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltModApply &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.WaitAuditNotice)
            {
                FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("机票改签申请{0}需要您进行审批", fltRetModApplyEntity.OrderId);
            }
        }
        /// <summary>
        /// 机票退票申请待审批通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetFltRetApplyWaitAuditMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltRetApply &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.WaitAuditNotice)
            {
                FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("机票退票申请{0}需要您进行审批", fltRetModApplyEntity.OrderId);
            }
        }

        #endregion

        #region 退客户通知
        private void GetFltRefundedCustomerMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltRet &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.RefundedCustomerNotice)
            {
                FltRefundOrderEntity fltRefundOrderEntity = _fltRefundOrderDal.Find<FltRefundOrderEntity>(sendAppMessageModel.OrderId);
                sendAppMessageModel.SendContent = string.Format("机票订单{0}已经退票成功，请确认", fltRefundOrderEntity.OrderId);
            }
        }
        #endregion

        #region 审核结果通知
        /// <summary>
        /// 机票审批通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetFltAuditResultMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.Flt &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditResultNotice)
            {
                FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(sendAppMessageModel.OrderId);
                /**
                 * 审批共分为如下情况：
                 * 1.只存在一级审核
                 * 2.存在二级审核
                 */
                if (fltOrderEntity.CPId.HasValue && !fltOrderEntity.CPIdSecond.HasValue)
                {
                    if (fltOrderEntity.CheckStatus=="W")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票订单{0}已经通过审批，准备出票", fltOrderEntity.OrderId);
                    }
                    else if (fltOrderEntity.CheckStatus == "J")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票订单{0}被审批人驳回，请您确认", fltOrderEntity.OrderId);
                    }
                }
                else if (fltOrderEntity.CPId.HasValue && fltOrderEntity.CPIdSecond.HasValue)
                {
                    if (fltOrderEntity.CheckStatus == "S")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票订单{0}已经通过一级审批，进入二级审批", fltOrderEntity.OrderId);
                    }
                    if (fltOrderEntity.CheckStatus == "W")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票订单{0}已经通过二级审批，准备出票", fltOrderEntity.OrderId);
                    }
                    else if (fltOrderEntity.CheckStatus == "J")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票订单{0}被审批人驳回，请您确认", fltOrderEntity.OrderId);
                    }
                }
            }
        }
        /// <summary>
        /// 机票改签申请审批通知
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetFltModApplyAuditResultMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltModApply &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditResultNotice)
            {
                FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(sendAppMessageModel.OrderId);
                /**
                 * 审批共分为如下情况：
                 * 1.只存在一级审核
                 * 2.存在二级审核
                 */
                if (fltRetModApplyEntity.Cpid.HasValue && !fltRetModApplyEntity.CpidSecond.HasValue)
                {
                    if (fltRetModApplyEntity.OrderStatus == "P")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票改签申请{0}已经通过审批，准备出票", fltRetModApplyEntity.OrderId);
                    }
                    else if (fltRetModApplyEntity.OrderStatus == "C")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票改签申请{0}被审批人驳回，请您确认", fltRetModApplyEntity.OrderId);
                    }
                }
                else if (fltRetModApplyEntity.Cpid.HasValue && fltRetModApplyEntity.CpidSecond.HasValue)
                {
                    if (fltRetModApplyEntity.OrderStatus == "S")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票改签申请{0}已经通过一级审批，进入二级审批", fltRetModApplyEntity.OrderId);
                    }
                    if (fltRetModApplyEntity.OrderStatus == "P")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票改签申请{0}已经通过二级审批，准备出票", fltRetModApplyEntity.OrderId);
                    }
                    else if (fltRetModApplyEntity.OrderStatus == "C")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票改签申请{0}被审批人驳回，请您确认", fltRetModApplyEntity.OrderId);
                    }
                }
            }
        }

        private void GetFltRetApplyAuditResultMessage(SendAppMessageModel sendAppMessageModel)
        {
            if (sendAppMessageModel.OrderType == OrderSourceTypeEnum.FltRetApply &&
                sendAppMessageModel.SendType == SendAppMessageTypeEnum.AuditResultNotice)
            {
                FltRetModApplyEntity fltRetModApplyEntity = _fltRetModApplyDal.Find<FltRetModApplyEntity>(sendAppMessageModel.OrderId);
                /**
                 * 审批共分为如下情况：
                 * 1.只存在一级审核
                 * 2.存在二级审核
                 */
                if (fltRetModApplyEntity.Cpid.HasValue && !fltRetModApplyEntity.CpidSecond.HasValue)
                {
                    if (fltRetModApplyEntity.OrderStatus == "D")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票退票申请{0}已经通过审批，准备退票", fltRetModApplyEntity.OrderId);
                    }
                    else if (fltRetModApplyEntity.OrderStatus == "C")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票退票申请{0}被审批人驳回，请您确认", fltRetModApplyEntity.OrderId);
                    }
                }
                else if (fltRetModApplyEntity.Cpid.HasValue && fltRetModApplyEntity.CpidSecond.HasValue)
                {
                    if (fltRetModApplyEntity.OrderStatus == "S")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票退票申请{0}已经通过一级审批，进入二级审批", fltRetModApplyEntity.OrderId);
                    }
                    if (fltRetModApplyEntity.OrderStatus == "D")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票退票申请{0}已经通过二级审批，准备退票", fltRetModApplyEntity.OrderId);
                    }
                    else if (fltRetModApplyEntity.OrderStatus == "C")
                    {
                        sendAppMessageModel.SendContent = string.Format("您的机票退票申请{0}被审批人驳回，请您确认", fltRetModApplyEntity.OrderId);
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 获取机票出票通知邮件
        /// </summary>
        /// <param name="sendAppMessageModel"></param>
        private void GetFltPrintTicketEmail(SendAppMessageModel sendAppMessageModel)
        {
            CustomerInfoEntity  customerInfoEntity= base.Context.Set<CustomerInfoEntity>().Find(sendAppMessageModel.Cid);
            if (string.IsNullOrEmpty(customerInfoEntity?.Email))
                return;

            sendAppMessageModel.Email = customerInfoEntity.Email;

            FltOrderEntity fltOrderEntity = _fltOrderDal.Find<FltOrderEntity>(sendAppMessageModel.OrderId);

            List<FltPassengerEntity> fltPassengerEntities =
                _fltPassengerDal.Query<FltPassengerEntity>(n => n.OrderId == fltOrderEntity.OrderId, true).ToList();

            List<FltFlightEntity> fltFlightEntities =
                _fltFlightDal.Query<FltFlightEntity>(n => n.OrderId == fltOrderEntity.OrderId, true).ToList();
            //判断是否是同一个编码
            bool isSamePnr = fltFlightEntities.Select(n => n.RecordNo).Distinct().Count() == 1;
            if (fltFlightEntities.Count == 1)
                isSamePnr = false;

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("<p>{0}：</p>", customerInfoEntity.RealName);
            sb.Append("<p>&nbsp;</p>");
            sb.Append("<p>您好！</p>");

            foreach (var fltPassengerEntity in fltPassengerEntities)
            {
                sb.Append("<p>&nbsp; </p>");
                sb.AppendFormat("<p>{0}:{1}已成功预订!</p>", fltPassengerEntity.Name, fltPassengerEntity.CardNo);
                if (!isSamePnr)
                {
                    //不同编码的行程
                    foreach (var fltFlightEntity in fltFlightEntities)
                    {
                        string dportName =
                            _airPortDal.Query<AirPortEntity>(n => n.AirportCode == fltFlightEntity.Dport, true)
                                .FirstOrDefault()?
                                .AirportName;
                        string aportName =
                            _airPortDal.Query<AirPortEntity>(n => n.AirportCode == fltFlightEntity.Aport, true)
                                .FirstOrDefault()?
                                .AirportName;

                        string s1 = fltFlightEntity.Airportson.Length >= 2
                            ? fltFlightEntity.Airportson.Substring(0, 2)
                            : "--";
                        string s2 = fltFlightEntity.Airportson.Length >= 4
                            ? fltFlightEntity.Airportson.Substring(2, 2)
                            : "--";

                        sb.AppendFormat("<p>行程：{0} {1}{2}-{3}{4}</p>", fltFlightEntity.FlightNo, dportName, s1,
                            aportName,
                            s2);
                        sb.AppendFormat("<p>出行时间：{0} {1} 起飞 {2} 到达</p>", fltFlightEntity.TackoffTime.ToString("MM月dd日"),
                            fltFlightEntity.TackoffTime.ToString("HH:mm"),
                            fltFlightEntity.ArrivalsTime.ToString("HH:mm"));
                        sb.AppendFormat("<p>价格：{0}元</p>",
                            fltFlightEntity.SalePrice + fltFlightEntity.TaxFee + fltFlightEntity.OilFee +
                            (fltFlightEntity.ServiceFee ?? 0));
                    }
                }
                else
                {
                    //第一段
                    string f1 = fltFlightEntities[0].FlightNo;
                    string dport1 = fltFlightEntities[0].Dport;
                    string dportName1 =
                            _airPortDal.Query<AirPortEntity>(n => n.AirportCode == dport1, true)
                                .FirstOrDefault()?
                                .AirportName;
                    string aport1 = fltFlightEntities[0].Aport;
                    string aportName1 =
                        _airPortDal.Query<AirPortEntity>(n => n.AirportCode == aport1, true)
                            .FirstOrDefault()?
                            .AirportName;

                    string d1 = fltFlightEntities[0].Airportson.Length >= 2
                       ? fltFlightEntities[0].Airportson.Substring(0, 2)
                       : "--";
                    string a1 = fltFlightEntities[0].Airportson.Length >= 4
                        ? fltFlightEntities[0].Airportson.Substring(2, 2)
                        : "--";

                    //第二段
                    string f2 = fltFlightEntities[1].FlightNo;
                    string dport2 = fltFlightEntities[1].Dport;
                    string dportName2 =
                          _airPortDal.Query<AirPortEntity>(n => n.AirportCode == dport2, true)
                              .FirstOrDefault()?
                              .AirportName;

                    string aport2 = fltFlightEntities[1].Aport;
                    string aportName2 =
                        _airPortDal.Query<AirPortEntity>(n => n.AirportCode == aport2, true)
                            .FirstOrDefault()?
                            .AirportName;
                    string d2 = fltFlightEntities[1].Airportson.Length >= 2
                      ? fltFlightEntities[1].Airportson.Substring(0, 2)
                      : "--";
                    string a2 = fltFlightEntities[1].Airportson.Length >= 4
                        ? fltFlightEntities[1].Airportson.Substring(2, 2)
                        : "--";

                    sb.AppendFormat("<p>行程：去 {0} {1}{2}-{3}{4}，回 {5} {6}{7}-{8}{9}</p>", f1, dportName1, d1,
                        aportName1, a1, f2, dportName2, d2,
                        aportName2, a2);

                    sb.AppendFormat("<p>出行时间：去 {0} {1} 起飞 {2} 到达，回 {3} {4} 起飞 {5} 到达</p>",
                        fltFlightEntities[0].TackoffTime.ToString("MM月dd日"),
                        fltFlightEntities[0].TackoffTime.ToString("HH:mm"),
                        fltFlightEntities[0].ArrivalsTime.ToString("HH:mm"),
                        fltFlightEntities[1].TackoffTime.ToString("MM月dd日"),
                        fltFlightEntities[1].TackoffTime.ToString("HH:mm"),
                        fltFlightEntities[1].ArrivalsTime.ToString("HH:mm"));

                    sb.AppendFormat("<p>价格：{0}元</p>",
                        fltFlightEntities.Sum(n => n.SalePrice) + fltFlightEntities.Sum(n => n.TaxFee) +
                        fltFlightEntities.Sum(n => n.OilFee) +
                        fltFlightEntities.Sum(n => (n.ServiceFee ?? 0)));
                }

            }


            sb.Append("<p></p>");
            sb.Append("<p>退改签规则：</p>");

            if (fltFlightEntities.Count == 1)
            {
                sb.AppendFormat("<p>退票：{0}</p>", fltFlightEntities[0].RetDes);
                sb.AppendFormat("<p>改期：{0}</p>", fltFlightEntities[0].ModDes);
            }
            else
            {
                sb.AppendFormat("<p>去程：</p>");
                sb.AppendFormat("<p>退票：{0}</p>", fltFlightEntities[0].RetDes);
                sb.AppendFormat("<p>改期：{0}</p>", fltFlightEntities[0].ModDes);
                sb.AppendFormat("<p>回程：</p>");
                sb.AppendFormat("<p>退票：{0}</p>", fltFlightEntities[1].RetDes);
                sb.AppendFormat("<p>改期：{0}</p>", fltFlightEntities[1].ModDes);
            }
            sb.Append("<p>温馨提醒：请提前90分钟到达机场,祝您一路平安,旅途愉快！</p>");
            sendAppMessageModel.SendContent = sb.ToString();
        }

    }
}
