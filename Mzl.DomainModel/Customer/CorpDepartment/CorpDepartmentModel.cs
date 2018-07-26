using System;
using System.ComponentModel;

namespace Mzl.DomainModel.Customer.CorpDepartment
{
    public class CorpDepartmentModel
    {
        /// <summary>
        /// Id
        /// </summary>
        [Description("Id")]
        public int Id { get; set; }
        /// <summary>
        /// 公司Id
        /// </summary>
        [Description("公司Id")]
        public string CorpId { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [Description("部门名称")]
        public string DepartName { get; set; }
        /// <summary>
        /// 线上创建人Id
        /// </summary>
        [Description("线上创建人Id")]
        public int Cid { get; set; }
       
        /// <summary>
        /// 政策编号
        /// </summary>
        [Description("政策编号")]
        public int? PolicyId { get; set; }
     
        /// <summary>
        /// 部门英文名称
        /// </summary>
        [Description("部门英文名称")]
        public string DepartEnName { get; set; }
      
        /// <summary>
        /// 审核方式:T电话,M短信,E邮件
        /// </summary>
        [Description("审核方式:T电话,M短信,E邮件")]
        public string CheckType { get; set; }
        /// <summary>
        /// 超时时间,单位分钟
        /// </summary>
        [Description("超时时间,单位分钟")]
        public int? TelTime { get; set; }
        /// <summary>
        /// 审核人ID
        /// </summary>
        [Description("审核人ID")]
        public int? CPCID { get; set; }
        /// <summary>
        /// 二级审核人
        /// </summary>
        [Description("二级审核人")]
        public int? CPIDSecond { get; set; }

        /// <summary>
        /// 是否有对应政策Id
        /// </summary>
        [Description("是否有对应政策Id")]
        public bool IsHasPolicy { get; set; }
        /// <summary>
        /// 是否包含对应的审批规则
        /// </summary>
        [Description("是否包含对应的审批规则")]
        public bool IsHasAduit { get; set; }

    }
}
