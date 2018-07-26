using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mzl.EntityModel.Customer.BaseInfo
{
    [Table("P_CustomerUnion")]
    public class CustomerUnionInfoEntity
    {
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        [Key]
        public int Cid { get; set; }
        /// <summary>
        /// 审核方式
        /// </summary>
        [Description("审核方式")]
        public string CheckType { get; set; }
        /// <summary>
        /// 超时审核时间
        /// </summary>
        [Description("超时审核时间")]
        public int? TelTime { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        [Description("审核人")]
        public int? CPCID { get; set; }
        /// <summary>
        /// 预订员可预订的部门ID
        /// </summary>
        [Description("预订员可预订的部门ID")]
        public string CorpDepartIDList { get; set; }
        /// <summary>
        /// 授权审核人
        /// </summary>
        [Description("授权审核人")]
        public int? GrantCPCID { get; set; }
        /// <summary>
        /// 授权开始时间
        /// </summary>
        [Description("授权开始时间")]
        public DateTime? GrantStartDate { get; set; }
        /// <summary>
        /// 授权结束时间
        /// </summary>
        [Description("授权结束时间")]
        public DateTime? GrantEndDate { get; set; }
        /// <summary>
        /// 是否检测恶意下单者
        /// </summary>
        [Description("是否检测恶意下单者")]
        public string IsCheckU8 { get; set; }
        /// <summary>
        /// 是否是政策供应商
        /// </summary>
        [Description("是否是政策供应商")]
        public string IsSupplier { get; set; }
        /// <summary>
        /// 0:上海 1:常州
        /// </summary>
        [Description("0:上海 1:常州")]
        public int? CustomerFrom { get; set; }
    }
}
