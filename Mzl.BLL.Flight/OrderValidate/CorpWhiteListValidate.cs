using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Flight;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.ConfigHelper;
using Mzl.Common.Exceptions;
using Mzl.EntityModel.Flight;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// 白名单匹配验证
    /// </summary>
    public class CorpWhiteListValidate: DomesticOrderAbstractValidate
    {
        private readonly ICheckPassengerIsInWhiteListBll _checkPassengerIsInWhiteListBll;
        private static readonly string CheckByNameAirlineNo = AppSettingsHelper.GetAppSettings(AppSettingsEnum.WhiteListByName);
        public CorpWhiteListValidate(ICheckPassengerIsInWhiteListBll checkPassengerIsInWhiteListBll)
        {
            _checkPassengerIsInWhiteListBll = checkPassengerIsInWhiteListBll;
        }

        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            /****
                *  一旦有PolicyType有数据并且=X||G，则代表有协议，进行名单匹配
                *  线上订单，一旦不在名单内，则提示不能下单；
                *  线下订单，一旦不在名单内，则提示请前去B2T或者官网进行比价；
                * ***/
            bool isNeedCheck = false;
            foreach (FltFlightModel f in context.AddOrderModel.FlightList)
            {
                if (string.IsNullOrEmpty(f.CorpPolicyType))
                {
                    if (!string.IsNullOrEmpty(f.PolicyType))
                    {
                        if (f.PolicyType == FltPolicyTypeEnum.G.ToString() ||
                            f.PolicyType == FltPolicyTypeEnum.X.ToString())
                        {
                            isNeedCheck = true;
                        }

                        if (f.PolicyType == "C")
                        {
                            f.PolicyType = "差旅普通政策";
                        }
                        else if (f.PolicyType == "X")
                        {
                            f.PolicyType = "差旅三协政策";
                        }
                        else if (f.PolicyType == "G")
                        {
                            f.PolicyType = "差旅二协政策";
                        }

                    }
                }
                else
                {
                    if (f.CorpPolicyType == FltPolicyTypeEnum.G.ToString() ||
                        f.CorpPolicyType == FltPolicyTypeEnum.X.ToString())
                    {
                        isNeedCheck = true;
                    }
                }
               
            }

            if (isNeedCheck)
            {
                bool flag = false;//是否在名单内
                string result = string.Empty;
                foreach (var flight in context.AddOrderModel.FlightList)
                {
                    string airlineNo = flight.FlightNo.Length < 2 ? flight.FlightNo : flight.FlightNo.Substring(0, 2);
                    if (CheckByNameAirlineNo.Contains(airlineNo.ToUpper()))
                    {
                        if (_checkPassengerIsInWhiteListBll.CheckPassenger(context.AddOrderModel.PassengerList, true))
                        {
                            flag = true;
                        }

                        result += "," + _checkPassengerIsInWhiteListBll.Result;
                    }
                    else
                    {
                        if (_checkPassengerIsInWhiteListBll.CheckPassenger(context.AddOrderModel.PassengerList, false))
                        {
                            flag = true;
                        }

                        result += "," + _checkPassengerIsInWhiteListBll.Result;
                    }
                }

                if (!flag)
                {
                    string message = "不在白名单内，不享受协议价，请删除后继续提交！";
                    if (context.AddOrderModel.PassengerList.Count==1)
                    {
                        message = "不在白名单内，不享受协议价，请重新选择航班！";
                    }
                    throw new MojoryException(MojoryApiResponseCode.NotInWhiteList,
                        result.Substring(1) + message);
                }
                else
                {
                    context.AddOrderModel.BuyRemark += result;
                }

            }

            this.NextNode?.ActionValidate(context);
            return true;
        }

        
    }
}
