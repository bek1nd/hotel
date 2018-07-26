using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Mzl.EntityModel.Train.BaseMaintenance
{
    [Table("P_Tra_WebMessages")]
    public class Tra12306AccountEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        [Description("id")]
        public int PassId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        public string PassWord { get; set; }
        /// <summary>
        /// 使用人
        /// </summary>
        [Description("使用人")]
        public string UserOid { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Description("是否删除")]
        public string IsDel { get; set; }
    }
}
