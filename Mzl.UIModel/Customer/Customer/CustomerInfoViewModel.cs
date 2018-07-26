using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.UIModel.Customer.Identification;

namespace Mzl.UIModel.Customer.Customer
{
    public class CustomerInfoViewModel
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        public string CorpId { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 公司部门Id
        /// </summary>
        [Description("公司Id")]
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 是否预订员
        /// </summary>
        [Description("是否预订员")]
        public string IsMaster { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Description("客户名称")]
        public string RealName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Description("Email")]
        public string EMail { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        [Description("手机号码")]
        public string Mobile { get; set; }
        /// <summary>
        /// 客户类别
        /// </summary>
        [Description("客户类别")]
        public string Category { get; set; }
        /// <summary>
        /// 差旅系统客户：T 是，F不是
        /// </summary>
        [Description("差旅系统客户：T 是，F不是")]
        public string IsCorpSystemCustomer { get; set; }
        /// <summary>
        /// 是否有审批权限 ：T 是，F不是
        /// </summary>
        [Description("是否有审批权限 ：T 是，F不是")]
        public string IsCheckPerson { get; set; }
        /// <summary>
        /// 部门
        /// </summary>
        [Description("部门")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// 公司全称
        /// </summary>
        [Description("公司全称")]
        public string CorpName { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Gender { get; set; }
        /// <summary>
        /// 性别描述
        /// </summary>
        [Description("性别描述")]
        public string GenderDesc
        {
            get
            {
                if (string.IsNullOrEmpty(Gender))
                    return "男";
                return Gender.ToUpper() == "M" ? "男" : "女";
            }
        }

        /// <summary>
        /// 是否显示临客
        /// </summary>
        [Description("是否显示临客 0不显示 1显示 默认显示")]
        public int? IsShowTemporaryPassenger { get; set; } = 1;
    }
}
