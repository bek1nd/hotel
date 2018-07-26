using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.EnumHelper;

namespace Mzl.DomainModel.Customer.CorpAduit
{
    public class CorpAduitConfigModel
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int ConfigId { get; set; }
        /// <summary>
        /// 审批规则类型名称
        /// </summary>
        [Description("审批规则类型名称")]
        public string AduitName { get; set; }
        /// <summary>
        /// 适用范围 0不限 1国内机票 2国际机票 3火车
        /// </summary>
        [Description("适用范围 0不限 1国内机票 2国际机票 3火车")]
        public int SuitRange { get; set; }
        /// <summary>
        /// 是否需要审批 0否 1是
        /// </summary>
        [Description("是否需要审批 0否 1是")]
        public int IsNeedAduit { get; set; }

        public string IsNeedAduitDes => IsNeedAduit == 0 ? "否" : "是";
        /// <summary>
        /// 公司Id 
        /// </summary>
        [Description("公司Id ")]
        public string CorpId { get; set; }
        /// <summary>
        /// 创建客户Id
        /// </summary>
        [Description("创建客户Id")]
        public int CreateCid { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 审批级别信息集合
        /// </summary>
        [Description("审批级别信息集合")]
        public List<CorpAduitConfigDetailModel> DetailList { get; set; }
        /// <summary>
        /// 汇审类别：0 必须都审批 1只需审批一个
        /// </summary>
        [Description("汇审类别：0 必须都审批 1只需审批一个")]
        public int TogetherAduitType { get; set; }
        /// <summary>
        /// 审批人信息
        /// </summary>
        public string AduitOName
        {
            get
            {
                if (DetailList == null || DetailList.Count == 0)
                    return null;

                string aduitOName = string.Empty;

                List<int> orderTypeList = new List<int>
                {
                    (int) OrderSourceTypeEnum.Flt,
                    (int) OrderSourceTypeEnum.FltModApply,
                    (int) OrderSourceTypeEnum.FltRetApply,
                    (int) OrderSourceTypeEnum.Tra
                };

                foreach (var i in orderTypeList)
                {
                   
                    var list=DetailList.FindAll(n => n.OrderType == i);
                    if (list != null && list.Count > 0)
                    {
                        string temp = string.Empty;
                        foreach (var corpAduitConfigDetailModel in list)
                        {
                            temp += "," + corpAduitConfigDetailModel.AduitLevel + corpAduitConfigDetailModel.AduitName;
                        }
                        if (!string.IsNullOrEmpty(temp))
                            temp = temp.Substring(1);
                        aduitOName += ";" + i.ValueToDescription<OrderSourceTypeEnum>() + ":" + temp;
                    }
                }


                if (!string.IsNullOrEmpty(aduitOName))
                    aduitOName = aduitOName.Substring(1);
                return aduitOName;
            }
        }
    }
}
