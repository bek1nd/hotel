using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Mzl.Common.XMLHelper;
using Mzl.DomainModel.Common.CheckAccount;
using Mzl.DomainModel.Customer.Base;
using Mzl.Framework.Base;
using Mzl.IBLL.Common.CheckAccount;

namespace Mzl.BLL.Common.CheckAccount
{
    internal class CheckCorpAccountPowerServiceBll : BaseServiceBll, ICheckCorpAccountPowerServiceBll
    {
        private static List<CheckAccountModel> _administratorWhiteList = GetAdministratorPowerPage("White", "Administrator"); //Administrator的白名单页面权限
        private static List<CheckAccountModel> _administratorBlackList = GetAdministratorPowerPage("Black", "Administrator"); //Administrator的黑名单页面权限

        private static List<CheckAccountModel> _commonUserWhiteList = GetAdministratorPowerPage("White", "CommonUser"); //CommonUser的白名单页面权限
        private static List<CheckAccountModel> _commonUserBlackList = GetAdministratorPowerPage("Black", "CommonUser"); //CommonUser的黑名单页面权限

        public bool CheckAccountPower(CustomerModel customer, string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;
            if (customer == null)
                return false;
            //判断当前客户信息是否是企业客户
            if (customer.Category != "D" && customer.Category != "d")
                return false;

            //判断当前客户对应的公司是否已经关闭
            if (customer.Corporation.IsAmplitudeCorp!="T")
            {
                return false;
            }

            //1.如果当前客户id为Administrator
            if (string.IsNullOrEmpty(customer.UserID))
            {
                return false;
            }

            url = url.ToLower();

            if (customer.UserID.ToLower()== "administrator")
            {
                //0.既不存在黑名单 也不存在白名单，默认不设置任何权限
                if (_administratorBlackList.Count == 0 && _administratorWhiteList.Count == 0)
                {
                    return true;
                }
                //1.检查黑名单，存在黑名单则没有权限
                if (_administratorBlackList.Count > 0 && Check(_administratorBlackList, url))
                {
                    return false;
                }
                //存在白名单
                if (_administratorWhiteList.Count > 0)
                {
                    //并且在白名单内
                    if(Check(_administratorWhiteList, url))
                        return true;

                    return false;
                }

                return true;
            }
            else
            {
                if (_commonUserWhiteList.Count == 0 && _commonUserBlackList.Count == 0)
                {
                    return true;
                }

                if (_commonUserBlackList.Count > 0 && Check(_commonUserBlackList, url))
                {
                    return false;
                }

                if (_commonUserWhiteList.Count > 0)
                {
                    if(Check(_commonUserWhiteList, url))
                        return true;

                    return false;
                }

                return true;
            }

        }

        /// <summary>
        /// 获取Administrator帐号拥有的权限地址
        /// </summary>
        private static List<CheckAccountModel> GetAdministratorPowerPage(string type= "White",string userType= "Administrator")
        {
            string str = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\App_Data\CorpAccountPower.xml";
            XmlNodeList xmlNodeList =
                XMLHelper.ReadXmlNode(str, "Power").SelectSingleNode(userType).SelectSingleNode(type).SelectNodes("PowerUrl");//获取Administrator的白名单权限

            List<CheckAccountModel> urlList = new List<CheckAccountModel>();
            if (xmlNodeList == null)
                return urlList;

            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                if(string.IsNullOrEmpty(xmlNodeList[i].InnerText))
                    continue;

                CheckAccountModel model = new CheckAccountModel();
                model.Url = xmlNodeList[i].InnerText.ToLower();
                model.IsHasXin = model.Url.Contains("*");
                if (model.IsHasXin)
                {
                    model.BeforeXinUrl = model.Url.Split('*')[0];
                }
                urlList.Add(model);
            }

            return urlList;
        }
        /// <summary>
        /// 检查
        /// </summary>
        /// <param name="list"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        private bool Check(List<CheckAccountModel> list,string url)
        {
            if (list == null || list.Count == 0)
                return false;

            foreach (var checkAccountModel in list)
            {
                if (checkAccountModel.IsHasXin)
                {
                    //如果具有通配符，检查包含就行
                    if (url.Contains(checkAccountModel.BeforeXinUrl))
                    {
                        return true;
                    }
                }
                else
                {
                    //没有通配符则必须匹配所有地址
                    if (url == checkAccountModel.Url)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
