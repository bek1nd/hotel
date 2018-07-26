namespace Mzl.DomainModel.Customer.Base
{
    /// <summary>
    /// 客户信息模型
    /// </summary>
    public class CustomerInfoModel
    {
        public string CorpId { get; set; }
        public string UserId { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public int Cid { get; set; }
        /// <summary>
        /// 公司部门Id
        /// </summary>
        public int? CorpDepartId { get; set; }
        /// <summary>
        /// 是否预订员
        /// </summary>
        public string IsMaster { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string RealName { get; set; }

        public string EMail { get; set; }
        public string Mobile { get; set; }
        /// <summary>
        /// 客户类型
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// 服务费规则Id
        /// </summary>
        public int? SfcId { get; set; }

        public string IsCheckPerson { get; set; }
        public string DepartmentName { get; set; }
        public string Gender { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        public string IsLock { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public string IsDel { get; set; }
        /// <summary>
        /// 是否显示临客
        /// </summary>
        public int? IsShowTemporaryPassenger { get; set; }

        /// <summary>
        /// 是否显示全部订单
        /// </summary>
        public int? IsShowAllOrder { get; set; }
    }
}
