using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.IDAL.Flight;
using Mzl.Framework.Base;
using System.Data.Entity;
using Mzl.EntityModel.Flight;
using AutoMapper;
using Mzl.Common.EnumHelper;
using Mzl.Common.LogHelper;
using Newtonsoft.Json;

namespace Mzl.BLL.Flight
{
    /// <summary>
    /// 添加国内机票
    /// </summary>
    public class AddDomesticOrderBll : BaseBll, IAddOrderBll
    {
        private readonly IFltOrderDal _fltOrderDal;
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltOrderUnionDal _fltOrderUnionDal;
        private readonly IFltOrderLogDal _fltOrderLogDal;

        public AddDomesticOrderBll(IFltOrderDal fltOrderDal, IFltFlightDal fltFlightDal,
              IFltPassengerDal fltPassengerDal, IFltOrderUnionDal fltOrderUnionDal, IFltOrderLogDal fltOrderLogDal) : base()
        {
            _fltOrderDal = fltOrderDal;
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
            _fltOrderUnionDal = fltOrderUnionDal;
            _fltOrderLogDal = fltOrderLogDal;
        }

        public int AddOrder(AddOrderModel fltAddOrderModel)
        {

            string json = JsonConvert.SerializeObject(fltAddOrderModel);
            LogHelper.WriteLog(json, "MojoryApiAddDomesticOrder");

            FltOrderEntity fltOrderEntity = Mapper.Map<AddOrderModel, FltOrderEntity>(fltAddOrderModel);
            fltOrderEntity.OrderDate=DateTime.Now;
            fltOrderEntity.IsInter = "N";
            fltOrderEntity.Oid = fltOrderEntity.CreateOid;
            fltOrderEntity.Orderstatus = "W";

            if (!string.IsNullOrEmpty(fltOrderEntity.CreateOid) && fltOrderEntity.CreateOid.ToLower() != "sys")
                fltOrderEntity.Orderstatus = "P";

              
            fltOrderEntity.OrderType = "T";
            fltOrderEntity.IsModandChange = "F";
            fltOrderEntity.IsTA = "F";

            fltOrderEntity.CorpAduitId = fltAddOrderModel.CorpAduitId;
            fltOrderEntity.CorpPolicyId = fltAddOrderModel.CorpPolicyId;

            if (string.IsNullOrEmpty(fltOrderEntity.Description))
                fltOrderEntity.Description = ",";
            if (string.IsNullOrEmpty(fltOrderEntity.Remark))
                fltOrderEntity.Remark = "无";
            if (string.IsNullOrEmpty(fltOrderEntity.IsOnLinePay))
                fltOrderEntity.IsOnLinePay = "F";
            if(string.IsNullOrEmpty(fltOrderEntity.SendTicketType))
                fltOrderEntity.SendTicketType = SendTicketTypeEnum.Not.ToString();

            string choiceReason = string.Concat(
                fltAddOrderModel.FlightList.Select(n => string.IsNullOrEmpty(n.ChoiceReason) ? "" : "/" + n.ChoiceReason)
                );
            if (!string.IsNullOrEmpty(choiceReason))
                choiceReason = choiceReason.Substring(1);
            if (!string.IsNullOrEmpty(choiceReason) && !choiceReason.Contains("/"))
                choiceReason = "/" + choiceReason;

            fltOrderEntity.ChoiceReason = choiceReason;
            fltOrderEntity.Totalamount = fltOrderEntity.Payamount + fltOrderEntity.Voucheramount;//订单总价加上优惠的金额
            fltAddOrderModel.FlightList.ForEach(n =>
            {
                fltOrderEntity.Allport += "-"+n.Dport+n.Aport;//SHAPEK-PEKSHA
            });
            if (!string.IsNullOrEmpty(fltOrderEntity.Allport))
                fltOrderEntity.Allport = fltOrderEntity.Allport.Substring(1);
            fltOrderEntity.OutTicketStatus = "N";

            if (!string.IsNullOrEmpty(fltAddOrderModel.Customer?.CorpID) &&
                fltAddOrderModel.Customer?.CorpID.ToLower() == "mzl")
            {
                fltOrderEntity.BuyRemark = fltOrderEntity.BuyRemark + "测试订单，请勿出票";
                fltOrderEntity.IsAutoOutTicket = 1;//测试公司下的订单统一转为人工出票，防止自动出票直接出票了
            }

            fltOrderEntity = _fltOrderDal.Insert(fltOrderEntity);

          

            FltOrderUnionEntity fltOrderUnionEntity=new FltOrderUnionEntity();
            fltOrderUnionEntity.OrderId = fltOrderEntity.OrderId;
            if (string.IsNullOrEmpty(fltOrderUnionEntity.IsMobile))
                fltOrderUnionEntity.IsMobile = "F";
            fltOrderUnionEntity.IsAutoInsurance = "F";
            fltOrderUnionEntity.CorpId = fltAddOrderModel.Customer != null
                ? fltAddOrderModel.Customer.CorpID
                : string.Empty;

            fltOrderUnionEntity.CorpDepartId = fltAddOrderModel.CorpDepartId;

            string corpPolicy = string.Concat(
              fltAddOrderModel.FlightList.Select(n => string.IsNullOrEmpty(n.CorpPolicy) ? "" : "|" + n.CorpPolicy)
              );
            if (!string.IsNullOrEmpty(corpPolicy))
                corpPolicy = corpPolicy.Substring(1);
            if (!string.IsNullOrEmpty(corpPolicy) && !corpPolicy.Contains("|"))
                corpPolicy = "|" + corpPolicy;

            fltOrderUnionEntity.CorpPolicy = corpPolicy;
            if (!string.IsNullOrEmpty(fltOrderUnionEntity.CorpPolicy))
            {
                if (fltOrderUnionEntity.CorpPolicy.Contains("提前"))
                {
                    fltOrderUnionEntity.IsPolicyT = "T";
                }
                if (fltOrderUnionEntity.CorpPolicy.Contains("折以下的航班"))
                {
                    fltOrderUnionEntity.IsPolicyR = "T";
                }
                if (fltOrderUnionEntity.CorpPolicy.Contains("分钟内最低航班"))
                {
                    fltOrderUnionEntity.IsPolicyL = "T";
                }
            }
            fltOrderUnionEntity.LostAmount = fltAddOrderModel.FlightList.Sum(n => n.LostAmount);
            fltOrderUnionEntity.ProjectId = fltAddOrderModel.ProjectId;
            fltOrderUnionEntity.BalanceType = fltAddOrderModel.BalanceType;
            fltOrderUnionEntity.TravelType = fltAddOrderModel.TravelType;
            _fltOrderUnionDal.Insert(fltOrderUnionEntity);

            List<FltFlightEntity> fltFlightEntities =
                Mapper.Map<List<FltFlightModel>, List<FltFlightEntity>>(fltAddOrderModel.FlightList);
          
            foreach (var f in fltFlightEntities)
            {
                f.OrderId = fltOrderEntity.OrderId;
                f.RecordNo = "AAAAAA";//默认编码
                if (string.IsNullOrEmpty(f.Airportson))
                    f.Airportson = "----";
                f.IsInter = fltOrderEntity.IsInter;
                if (f.Class.Length > 1)
                    f.Class = f.Class.Substring(0,1);
                if (!string.IsNullOrEmpty(f.ChoiceReason) && f.ChoiceReason.Trim().ToLower() == "undefined")
                {
                    f.ChoiceReason = string.Empty;
                }

                if (f.Rate.HasValue && f.Rate.Value > 1)
                {
                    f.Rate = f.Rate/10;
                }
                if (f.FRate > 1)
                {
                    f.FRate = f.FRate / 10;
                }

                _fltFlightDal.Insert(f);
            }
            List<FltPassengerEntity> fltPassengerEntities =
                Mapper.Map<List<FltPassengerModel>, List<FltPassengerEntity>>(fltAddOrderModel.PassengerList);
          
            foreach (var p in fltPassengerEntities)
            {
                p.IsAvailable = "T";
                if (string.IsNullOrEmpty(p.Remark))
                    p.Remark = "无";
                p.OrderId = fltOrderEntity.OrderId;              
                _fltPassengerDal.Insert(p);
            }

            FltOrderLogEntity log = new FltOrderLogEntity()
            {
                OrderId = fltOrderEntity.OrderId,
                LogTime = DateTime.Now,
                LogType = "新建订单",
                Remark =
                    "新建订单" + (string.IsNullOrEmpty(fltOrderEntity.BuyRemark) ? "" : "采购备注:" + fltOrderEntity.BuyRemark),
                Oid = "sys"
            };

            _fltOrderLogDal.Insert(log);

            return fltOrderEntity.OrderId;
        }
    }
}
