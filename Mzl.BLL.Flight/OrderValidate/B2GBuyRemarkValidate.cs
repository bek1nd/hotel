using Mzl.Common.EnumHelper;
using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Flight.OrderValidate
{
    /// <summary>
    /// B2G采购备注验证
    /// </summary>
    public class B2GBuyRemarkValidate : DomesticOrderAbstractValidate
    {
        public override bool ActionValidate(AddOrderAbstractContext context)
        {
            /****
             *  这里进行B2G采购备注验证
             *  如果是选择了B2G价格，则备注  
             *  如果选择了协议价格，但是其中存在B2G价格，则订单备注
             * ***/
            Dictionary<int,string> b2GDictionary=new Dictionary<int, string>();
            Dictionary<int, bool> hasB2GPriceDictionary = new Dictionary<int, bool>();
            foreach (var f in context.AddOrderModel.FlightList)
            {
                //选择B2G政策的
                if (!string.IsNullOrEmpty(f.CorpPolicyType) && f.CorpPolicyType == FltPolicyTypeEnum.G.ToString())
                {
                    if (string.IsNullOrEmpty(f.PlcId))
                        throw new Exception("请传入" + FltPolicyTypeEnum.G.ToDescription() + " 政策Id");
                    b2GDictionary.Add(f.Sequence, FltPolicyTypeEnum.G.ToString());
                    f.PolicyMemo = f.ModDes;
                }
                //选择协议政策，但是有B2G价格的
                if (!string.IsNullOrEmpty(f.CorpPolicyType) && f.CorpPolicyType == FltPolicyTypeEnum.X.ToString() &&
                    f.HasB2GPrice)
                {
                    hasB2GPriceDictionary.Add(f.Sequence, true);
                }
            }

            B2GBuyRemark(context, b2GDictionary);

            B2GOrderRemark(context, hasB2GPriceDictionary);

            this.NextNode?.ActionValidate(context);
            return true;
        }


        private void B2GBuyRemark(AddOrderAbstractContext context, Dictionary<int, string> b2GDictionary)
        {
            if (b2GDictionary.Count > 0)
            {
                if (context.AddOrderModel.FlightList.Count == 1)
                {
                    context.AddOrderModel.BuyRemark += ",请B2G采购";
                }
                else
                {
                    foreach (var d in b2GDictionary)
                    {
                        context.AddOrderModel.BuyRemark += string.Format(",第{0}段，请B2G采购", d.Key);
                    }
                }
            }
        }

        private void B2GOrderRemark(AddOrderAbstractContext context, Dictionary<int, bool> hasB2GPriceDictionary)
        {
            if (hasB2GPriceDictionary.Count > 0)
            {
                if (context.AddOrderModel.FlightList.Count == 1)
                {
                    context.AddOrderModel.BuyRemark += ",该航段存在B2G价格,请B2G采购";
                    context.AddOrderModel.Remark += ",该航段存在B2G价格,请B2G采购";
                }
                else
                {
                    foreach (var d in hasB2GPriceDictionary)
                    {
                        context.AddOrderModel.BuyRemark += string.Format(",第{0}段存在B2G价格,请B2G采购", d.Key);
                        context.AddOrderModel.Remark += string.Format(",第{0}段存在B2G价格,请B2G采购", d.Key);
                    }
                }
            }
        }
    }
}
