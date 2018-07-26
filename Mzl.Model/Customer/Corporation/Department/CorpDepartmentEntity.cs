using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Corporation.Department
{
    [Table("P_CorpDepartment")]
    public class CorpDepartmentEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("主键")]
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
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime AddTime { get; set; }
        /// <summary>
        /// 政策编号
        /// </summary>
        [Description("政策编号")]
        public int? PolicyId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Description("是否删除")]
        public string IsDel { get; set; }
        /// <summary>
        /// 部门英文名称
        /// </summary>
        [Description("部门英文名称")]
        public string DepartEnName { get; set; }
        /// <summary>
        /// 添加Oid
        /// </summary>
        [Description("添加Oid")]
        public string Oid { get; set; }
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
    }
}
