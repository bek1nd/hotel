using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mzl.EntityModel.Customer.Corporation.Corp
{
    [Table("P_Corporation")]
    public class CorporationEntity
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        [Key]
        [Description("公司Id")]
        public string CorpId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public int? iid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string CorpName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string CorpshortName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string CorpAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string CorpTel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string CorpContact { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Remark { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ContactPersonName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ContractDescription { get; set; }
        /// <summary>
        /// 预付押金
        /// </summary>
        [Description("预付押金")]
        public decimal? AdvanceDeposit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public decimal? Amountofmoney { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public decimal? Matendowmentcap { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Clearingtheway { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string ClearingDescription { get; set; }
        /// <summary>
        /// 结算日期
        /// </summary>
        [Description("结算日期")]
        public string ClearingDate { get; set; }
        /// <summary>
        /// 收款日期
        /// </summary>
        [Description("收款日期")]
        public string ProceedsDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string Oid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 合同开始日期
        /// </summary>
        [Description("合同开始日期")]
        public DateTime? Contractstart { get; set; }
        /// <summary>
        /// 合同签署日期
        /// </summary>
        [Description("合同签署日期")]
        public DateTime? Contractsigning { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [Description("城市")]
        public string City { get; set; }
        /// <summary>
        /// 公司主页
        /// </summary>
        [Description("公司主页")]
        public string CorpHome { get; set; }
        /// <summary>
        /// 目前合作方式
        /// </summary>
        [Description("目前合作方式")]
        public string JoinType { get; set; }
        /// <summary>
        /// 合同到期日期
        /// </summary>
        [Description("合同到期日期")]
        public DateTime? Contractend { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        [Description("客户来源")]
        public string Source { get; set; }
        /// <summary>
        /// 客户代表
        /// </summary>
        [Description("客户代表")]
        public string Representative { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        [Description("生日")]
        public string BirDate { get; set; }
        /// <summary>
        /// 身份证号码
        /// </summary>
        [Description("身份证号码")]
        public string IdCard { get; set; }
        /// <summary>
        /// Skype
        /// </summary>
        [Description("Skype")]
        public string Skype { get; set; }
        /// <summary>
        /// 其它电话
        /// </summary>
        [Description("其它电话")]
        public string OtherPhone { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        [Description("职位")]
        public string Job { get; set; }
        /// <summary>
        /// 家庭地址
        /// </summary>
        [Description("家庭地址")]
        public string HomeAddress { get; set; }
        /// <summary>
        /// 个人习惯
        /// </summary>
        [Description("个人习惯")]
        public string Habit { get; set; }
        /// <summary>
        /// 平均差旅费
        /// </summary>
        [Description("平均差旅费")]
        public int? AvgMthDrive { get; set; }
        /// <summary>
        /// 差旅需求
        /// </summary>
        [Description("差旅需求")]
        public string DriveWant { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [Description("邮编")]
        public string PostCode { get; set; }
        /// <summary>
        /// 行业
        /// </summary>
        [Description("行业")]
        public string Trade { get; set; }
        /// <summary>
        /// 公司类型 Agr：协议客户       Pee：同行
        /// </summary>
        [Description("公司类型 Agr：协议客户       Pee：同行")]
        public string CorpType { get; set; }
        /// <summary>
        /// 送保险
        /// </summary>
        [Description("送保险")]
        public string IsInsurance { get; set; }
        /// <summary>
        /// 送险下限
        /// </summary>
        [Description("送险下限")]
        public decimal InsuranceRule { get; set; }
        /// <summary>
        /// 首字母缩写
        /// </summary>
        [Description("首字母缩写")]
        public string AcronymName { get; set; }
        /// <summary>
        /// 个性化要求
        /// </summary>
        [Description("个性化要求")]
        public string Requirement { get; set; }
        /// <summary>
        /// 1:是否已关闭使用
        /// </summary>
        [Description("1:是否已关闭使用")]
        public int ExpandStatus { get; set; }
        /// <summary>
        /// 推荐人ID
        /// </summary>
        [Description("推荐人ID")]
        public string GuideId { get; set; }
        /// <summary>
        /// 来源于....网络推荐等
        /// </summary>
        [Description("来源于....网络推荐等")]
        public int? UserSource { get; set; }
        /// <summary>
        /// 三方协议合同号
        /// </summary>
        [Description("三方协议合同号")]
        public string AgreementNo { get; set; }
        /// <summary>
        ///  
        /// </summary>
        [Description(" ")]
        public string LogoUrl { get; set; }
      
        /// <summary>
        /// 集团公司ID
        /// </summary>
        [Description("集团公司ID")]
        public string ParentCorpId { get; set; }
        /// <summary>
        /// 是否是差旅公司
        /// </summary>
        [Description("是否是差旅公司")]
        public string IsAmplitudeCorp { get; set; }
        /// <summary>
        /// 是否给予差旅员工服务
        /// </summary>
        [Description("是否给予差旅员工服务")]
        public string IsServices { get; set; }
        /// <summary>
        /// 服务费政策ID
        /// </summary>
        [Description("服务费政策ID")]
        public int? SfcId { get; set; }
        /// <summary>
        /// 账期预警日期(催款日期)
        /// </summary>
        [Description("账期预警日期(催款日期)")]
        public DateTime? AccountWarningDate { get; set; }
        /// <summary>
        /// 账期终止日期
        /// </summary>
        [Description("账期终止日期")]
        public DateTime? AccountStopDate { get; set; }
        /// <summary>
        /// 欠款预警值
        /// </summary>
        [Description("欠款预警值")]
        public decimal? DebtWarning { get; set; }
        /// <summary>
        /// 欠款终止值
        /// </summary>
        [Description("欠款终止值")]
        public decimal? DebtStop { get; set; }
        /// <summary>
        /// 不受控制开始时间
        /// </summary>
        [Description("不受控制开始时间")]
        public DateTime? FreeControlBeginDate { get; set; }
        /// <summary>
        /// 不受控制结束时间
        /// </summary>
        [Description("不受控制结束时间")]
        public DateTime? FreeControlEndDate { get; set; }
        /// <summary>
        /// 未收款金额
        /// </summary>
        [Description("未收款金额")]
        public decimal? NotCollection { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        [Description("收款账号")]
        public string CollectionAccount { get; set; }
        /// <summary>
        /// 收款公司
        /// </summary>
        [Description("收款公司")]
        public string CollectionCompany { get; set; }
        /// <summary>
        /// 收款银行
        /// </summary>
        [Description("收款银行")]
        public string CollectionBank { get; set; }
        /// <summary>
        /// 行程单服务费配置 1.服务费打印到行程单中 2.服务费单
        /// </summary>
        [Description("行程单服务费配置 1.服务费打印到行程单中 2.服务费单")]
        public int? TravelServiceConfig { get; set; }
        /// <summary>
        /// 公司信息归属  0:上海 1:常州
        /// </summary>
        [Description("公司信息归属  0:上海 1:常州")]
        public int? CorpFrom { get; set; }
        /// <summary>
        /// 公司级别
        /// </summary>
        [Description("公司级别")]
        public int? CorpLevel { get; set; }
        /// <summary>
        /// 当前趋势
        /// </summary>
        [Description("当前趋势")]
        public int? LevelTrend { get; set; }
        /// <summary>
        ///  最近趋势(目前获取最近三个月的趋势，/分割)
        /// </summary>
        [Description(" 最近趋势(目前获取最近三个月的趋势，/分割)")]
        public string RecentLevelTrend { get; set; }
        /// <summary>
        /// 评级执行时间
        /// </summary>
        [Description("评级执行时间")]
        public DateTime? RunLevelTime { get; set; }
        /// <summary>
        /// 是否流失
        /// </summary>
        [Description("是否流失")]
        public bool IsLoss { get; set; }
        /// <summary>
        /// 黑名单时间
        /// </summary>
        [Description("黑名单时间")]
        public DateTime? BlackTime { get; set; }
        /// <summary>
        /// 流失时间
        /// </summary>
        [Description("流失时间")]
        public DateTime? LossTime { get; set; }
        /// <summary>
        /// 黑名单原因
        /// </summary>
        [Description("黑名单原因")]
        public string BlackReason { get; set; }
        /// <summary>
        /// 流失原因
        /// </summary>
        [Description("流失原因")]
        public string LossReason { get; set; }
        /// <summary>
        /// 企业性质
        /// </summary>
        [Description("企业性质")]
        public string Nature { get; set; }
        /// <summary>
        /// 企业属性
        /// </summary>
        [Description("企业属性")]
        public string Attribute { get; set; }
        /// <summary>
        /// 区域公司。枚举：0、上海，1、常州。
        /// </summary>
        [Description("区域公司。枚举：0、上海，1、常州。")]
        public int? Region { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        [Description("负责人")]
        public string Principal { get; set; }
        /// <summary>
        /// 负责人手机号码
        /// </summary>
        [Description("负责人手机号码")]
        public string PrincipalTel { get; set; }
        /// <summary>
        /// 负责人性别。枚举：0、男，1、女。
        /// </summary>
        [Description("负责人性别。枚举：0、男，1、女。")]
        public int? PrincipalGender { get; set; }
        /// <summary>
        /// 负责人生日。
        /// </summary>
        [Description("负责人生日。")]
        public DateTime? PrincipalBirthday { get; set; }
        /// <summary>
        /// 企业地域。
        /// </summary>
        [Description("企业地域。")]
        public int? ProvinceId { get; set; }
        /// <summary>
        /// 是否黑名单
        /// </summary>
        [Description("是否黑名单")]
        public bool IsBlack { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        [Description("主键")]
        public int Id { get; set; }
        /// <summary>
        /// 客户来源介绍人
        /// </summary>
        [Description("客户来源介绍人")]
        public string UserSourcePerson { get; set; }
        /// <summary>
        /// 负责此客户的员工
        /// </summary>
        [Description("负责此客户的员工")]
        public string ResponsibleOid { get; set; }
        /// <summary>
        /// 是否提醒保险功能
        /// </summary>
        [Description("是否提醒保险功能")]
        public string IsPromptInsurance { get; set; }
        /// <summary>
        /// 平均票数
        /// </summary>
        [Description("平均票数")]
        public int? AverageTicketCount { get; set; }
        /// <summary>
        /// 允许在Corp网站上从该时间点开始显示数据
        /// </summary>
        [Description("允许在Corp网站上从该时间点开始显示数据")]
        public DateTime? AllowShowDataBeginTime { get; set; }
        /// <summary>
        /// 是否需要打印 0否 1是
        /// </summary>
        public int? IsPrint { get; set; }
        /// <summary>
        /// 差旅报告类型 0不启用 1账单类型 2订单类型
        /// </summary>
        public int? TravelReportType { get; set; }
        /// <summary>
        /// 是否允许使用保险  0否 1是
        /// </summary>
        public int? IsAllowUserInsurance { get; set; }
        /// <summary>
        /// 共享航班显示  0否 1是
        /// </summary>
        public int? IsShareFly { get; set; }
        /// <summary>
        /// 协议价格是否单独展示  0否 1是
        /// </summary>
        public int? IsXYPrice { get; set; }
        /// <summary>
        /// 是否显示全部舱位  0否 1是
        /// </summary>
        public int? IsAllSeat { get; set; }
        /// <summary>
        /// 是否显示最高舱位  0否 1是
        /// </summary>
        public int? IsHeightSeat { get; set; }
        /// <summary>
        /// 出行原因必填  0否 1是
        /// </summary>
        public int? IsTravelReason { get; set; }
        /// <summary>
        /// 短信验证控制  0否 1是
        /// </summary>
        public int? IsNoteVerify { get; set; }

        /// <summary>
        /// 火车票是否显示全部舱位 0否 1是
        /// </summary>
        [Description("火车票是否显示全部舱位 0否 1是")]
        public int? IsTraAllSeat { get; set; }

    }
}
