using Mzl.DomainModel.Customer.CorpPolicy;
using Mzl.EntityModel.Customer.Corporation.CorpPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.BLL.Customer.Customer
{
    public class CorpPolicyConvertFactory
    {
        /// <summary>
        /// 转换政策
        /// </summary>
        /// <param name="corpPolicyDetailConfigEntities"></param>
        /// <returns></returns>
        public static CorpPolicyDetailConfigModel Convert(List<CorpPolicyDetailConfigEntity> corpPolicyDetailConfigEntities)
        {
            CorpPolicyDetailConfigModel configModel = new CorpPolicyDetailConfigModel();

            foreach (var config in corpPolicyDetailConfigEntities)
            {
                configModel.Cid = config.Cid;
                configModel.PolicyId = config.PolicyId;
                if (config.DetailType == "L" && config.PolicyType == "N")
                {
                    configModel.NPolicyValL = config.PolicyVal;
                }
                else if (config.DetailType == "T" && config.PolicyType == "N")
                {
                    configModel.NPolicyValT = config.PolicyVal;
                }
                else if (config.DetailType == "R" && config.PolicyType == "N")
                {
                    configModel.NPolicyValR = config.PolicyVal;
                }
                else if (config.DetailType == "I" && config.PolicyType == "N")
                {
                    configModel.NPolicyValI = config.PolicyVal;
                }
                else if (config.DetailType == "L" && config.PolicyType == "I")
                {
                    configModel.IPolicyValL = config.PolicyVal;
                }
                else if (config.DetailType == "T" && config.PolicyType == "I")
                {
                    configModel.IPolicyValT = config.PolicyVal;
                }
                else if (config.DetailType == "R" && config.PolicyType == "I")
                {
                    configModel.IPolicyValR = config.PolicyVal;
                }
                else if (config.DetailType == "I" && config.PolicyType == "I")
                {
                    configModel.IPolicyValI = config.PolicyVal;
                }
                else if (config.DetailType == "Y" && config.PolicyType == "N")
                {
                    configModel.NPolicyValY = config.PolicyVal;
                }
                else if (config.DetailType == "Q" && config.PolicyType == "T")
                {
                    configModel.TPolicyValQ = config.PolicyVal;
                }
                else if (config.DetailType == "S" && config.PolicyType == "T")
                {
                    configModel.TPolicyValS = config.PolicyVal;
                }
                else if (config.DetailType == "M" && config.PolicyType == "T")
                {
                    configModel.TPolicyValM = config.PolicyVal;
                }
            }

            return configModel;
        }
    }
}
