using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.CorpDepartment;
using Mzl.DomainModel.Customer.Identification;

namespace Mzl.DomainModel.Customer.Base
{
    public class CustomerModel
    {
        /// <summary>
        /// 差旅客户对应的部门信息
        /// </summary>
        public CorpDepartmentModel CorpDepartment { get; set; }
        /// <summary>
        /// 公司信息
        /// </summary>
        public CorporationModel Corporation { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        [Description("客户Id")]
        public int Cid { get; set; }
        /// <summary>
        /// 公司id
        /// </summary>
        [Description("公司id")]
        public string CorpID { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Description("用户名")]
        public string UserID { get; set; }
        /// <summary>
        /// 用户级别
        /// </summary>
        [Description("用户级别")]
        public int? UserLevel { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        public string Password { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [Description("手机")]
        public string Mobile { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        [Description("电话")]
        public string Phone { get; set; }
        /// <summary>
        /// 卡号
        /// </summary>
        [Description("卡号")]
        public string CardNo { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Description("Email")]
        public string Email { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        [Description("用户名称")]
        public string UserName { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Description("创建时间")]
        public DateTime Createtime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        [Description("最后登录时间")]
        public DateTime? Lastlogintime { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        [Description("积分")]
        public int Integral { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        [Description("公司ID")]
        public string Oid { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Description("性别")]
        public string Gender { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [Description("备注")]
        public string Remark { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        [Description("地址")]
        public string Address { get; set; }
        /// <summary>
        /// 客户来源
        /// </summary>
        [Description("客户来源")]
        public int? UserSource { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        [Description("邮编")]
        public string PostalCode { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        [Description("出生日期")]
        public string BirthDate { get; set; }
        /// <summary>
        /// 传真
        /// </summary>
        [Description("传真")]
        public string Fax { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string GuideID { get; set; }
        /// <summary>
        /// 客户名称
        /// </summary>
        [Description("客户名称")]
        public string RealName { get; set; }
        /// <summary>
        /// 手机1
        /// </summary>
        [Description("手机1")]
        public string Mobile1 { get; set; }
        /// <summary>
        /// 电话1
        /// </summary>
        [Description("电话1")]
        public string Phone1 { get; set; }
        /// <summary>
        /// 电话2
        /// </summary>
        [Description("电话2")]
        public string Phone2 { get; set; }
        /// <summary>
        /// 电话3
        /// </summary>
        [Description("电话3")]
        public string Phone3 { get; set; }
        /// <summary>
        /// 电话4
        /// </summary>
        [Description("电话4")]
        public string Phone4 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string TMGuideID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string TCGuideID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DateTime? TCGuideTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public DateTime? TMGuideTime { get; set; }
        /// <summary>
        /// 账户余额
        /// </summary>
        [Description("账户余额")]
        public decimal Balance { get; set; }
        /// <summary>
        /// 客户状态,WD稳定,DD动荡,DZ潜在大客户,LS流失
        /// </summary>
        [Description("客户状态,WD稳定,DD动荡,DZ潜在大客户,LS流失")]
        public string CustomerStatus { get; set; }
        /// <summary>
        /// 是否为线上注册
        /// </summary>
        [Description("是否为线上注册")]
        public string IsOnline { get; set; }
        /// <summary>
        /// 是否冻结
        /// </summary>
        [Description("是否冻结")]
        public string IsLock { get; set; }
        /// <summary>
        /// 是否订单审核
        /// </summary>
        [Description("是否订单审核")]
        public string IsCheck { get; set; }
        /// <summary>
        /// 是否为审核员
        /// </summary>
        [Description("是否为审核员")]
        public string IsCheckPerson { get; set; }
        /// <summary>
        /// 客户个性化要求
        /// </summary>
        [Description("客户个性化要求")]
        public string Requirement { get; set; }
        /// <summary>
        /// 优惠幅度
        /// </summary>
        [Description("优惠幅度")]
        public decimal? LeaveRate { get; set; }
        /// <summary>
        /// 调整金额
        /// </summary>
        [Description("调整金额")]
        public decimal? ChangeAmount { get; set; }
        /// <summary>
        /// 是否优惠
        /// </summary>
        [Description("是否优惠")]
        public string Isfavorable { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Description("创建人")]
        public string CreateOid { get; set; }
        /// <summary>
        /// 是否为删除客户
        /// </summary>
        [Description("是否为删除客户")]
        public string IsDel { get; set; }
        /// <summary>
        /// 客户类别,S,散客,D,公司客户,T,同行
        /// </summary>
        [Description("客户类别,S,散客,D,公司客户,T,同行")]
        public string Category { get; set; }
        /// <summary>
        /// 公司部门名称
        /// </summary>
        [Description("公司部门名称")]
        public string DepartmentName { get; set; }
        /// <summary>
        /// OSI
        /// </summary>
        [Description("OSI")]
        public string OSIphone { get; set; }
        /// <summary>
        /// 客户代理商上级CID，为0时表示一级代理
        /// </summary>
        [Description("客户代理商上级CID，为0时表示一级代理")]
        public int? ParentCID { get; set; }
        /// <summary>
        /// 酒店留扣优惠
        /// </summary>
        [Description("酒店留扣优惠")]
        public decimal? HolLeaveRate { get; set; }
        /// <summary>
        /// 分销等级,H为公司分销管理，I为一级分销商，J为二级分
        /// </summary>
        [Description("分销等级,H为公司分销管理，I为一级分销商，J为二级分")]
        public string Proxy { get; set; }
        /// <summary>
        /// 预留政策ID
        /// </summary>
        [Description("预留政策ID")]
        public string ProfitID { get; set; }
        /// <summary>
        /// 支付宝收款账号
        /// </summary>
        [Description("支付宝收款账号")]
        public string AlipayAccount { get; set; }
        /// <summary>
        /// 代理商留润到每个人
        /// </summary>
        [Description("代理商留润到每个人")]
        public decimal? HolLeaveRateABC { get; set; }
        /// <summary>
        /// 代理商留润到每个人
        /// </summary>
        [Description("代理商留润到每个人")]
        public string ProfitIDABC { get; set; }
        /// <summary>
        /// 支付密码
        /// </summary>
        [Description("支付密码")]
        public string PayPwd { get; set; }
        /// <summary>
        /// 是否开启余额支付，T锁定，F启用，线上用
        /// </summary>
        [Description("是否开启余额支付，T锁定，F启用，线上用")]
        public string BalanceLock { get; set; }
        /// <summary>
        /// 行程单类型N空白行程单，T票号行程单，线上用
        /// </summary>
        [Description("行程单类型N空白行程单，T票号行程单，线上用")]
        public string AirTransport { get; set; }
        /// <summary>
        /// 省外键
        /// </summary>
        [Description("省外键")]
        public int? ProvinceID { get; set; }
        /// <summary>
        /// 市外键
        /// </summary>
        [Description("市外键")]
        public int? CityID { get; set; }
        /// <summary>
        /// 州县外键
        /// </summary>
        [Description("州县外键")]
        public int? DistrictID { get; set; }
        /// <summary>
        /// 打印所属单位
        /// </summary>
        [Description("打印所属单位")]
        public string AirTransportUnit { get; set; }
        /// <summary>
        /// 分销快钱分账账号
        /// </summary>
        [Description("分销快钱分账账号")]
        public string BillAccount { get; set; }
        /// <summary>
        /// 是否支持快钱支付
        /// </summary>
        [Description("是否支持快钱支付")]
        public string BillPay { get; set; }
        /// <summary>
        /// 机票销售单位
        /// </summary>
        [Description("机票销售单位")]
        public string OfficeCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string AgentCode { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [Description("公司名称")]
        public string Company { get; set; }
        /// <summary>
        /// 线上权限位，1为有同行导编码模式，4为同行订单模式
        /// </summary>
        [Description("线上权限位，1为有同行导编码模式，4为同行订单模式")]
        public int? OnLinePower { get; set; }
        /// <summary>
        /// 使用政策
        /// </summary>
        [Description("使用政策")]
        public int? Policy { get; set; }
        /// <summary>
        /// 特殊高
        /// </summary>
        [Description("特殊高")]
        public string SpecialVip { get; set; }
        /// <summary>
        /// 保险低价
        /// </summary>
        [Description("保险低价")]
        public decimal? Bxprice { get; set; }
        /// <summary>
        /// 受限用户生成的客户
        /// </summary>
        [Description("受限用户生成的客户")]
        public string Ttsteam { get; set; }
        /// <summary>
        /// 现付酒店规则
        /// </summary>
        [Description("现付酒店规则")]
        public string HolProfitID { get; set; }
        /// <summary>
        /// 预付酒店规则
        /// </summary>
        [Description("预付酒店规则")]
        public string HobProfitID { get; set; }
        /// <summary>
        /// 现付酒店规则
        /// </summary>
        [Description("现付酒店规则")]
        public string HolProfitIDABC { get; set; }
        /// <summary>
        /// 预付酒店规则
        /// </summary>
        [Description("预付酒店规则")]
        public string HobProfitIDABC { get; set; }
        /// <summary>
        /// 国际机票政策ID
        /// </summary>
        [Description("国际机票政策ID")]
        public string InaProfitID { get; set; }
        /// <summary>
        /// 国际机票政策ID(为0时则不使用任何政策)
        /// </summary>
        [Description("国际机票政策ID(为0时则不使用任何政策)")]
        public string InaProfitIDABC { get; set; }
        /// <summary>
        /// 火车票的保险底价
        /// </summary>
        [Description("火车票的保险底价")]
        public decimal? TraInsLowPrice { get; set; }
        /// <summary>
        /// 是否支持手工打印
        /// </summary>
        [Description("是否支持手工打印")]
        public string IsHandPrint { get; set; }
        /// <summary>
        /// 是否支持国际打印
        /// </summary>
        [Description("是否支持国际打印")]
        public string IsPrintInter { get; set; }
        /// <summary>
        /// 短信猫配置
        /// </summary>
        [Description("短信猫配置")]
        public int? GsmConfig { get; set; }
        /// <summary>
        /// 是否只显示最高政策
        /// </summary>
        [Description("是否只显示最高政策")]
        public string IsHighPolicy { get; set; }
        /// <summary>
        /// 是否自管理经销商行程单
        /// </summary>
        [Description("是否自管理经销商行程单")]
        public string IsManageApplyTicket { get; set; }
        /// <summary>
        /// 是否为超级预订权限
        /// </summary>
        [Description("是否为超级预订权限")]
        public string IsMaster { get; set; }
        /// <summary>
        /// 是否关闭特殊高政策
        /// </summary>
        [Description("是否关闭特殊高政策")]
        public string IsUnHighPolicy { get; set; }
        /// <summary>
        /// 是否是淘宝组
        /// </summary>
        [Description("是否是淘宝组")]
        public string TBTeam { get; set; }
        /// <summary>
        /// 公司集团ID
        /// </summary>
        [Description("公司集团ID")]
        public string CorpMasterID { get; set; }
        /// <summary>
        /// 公司部门ID
        /// </summary>
        [Description("公司部门ID")]
        public int? CorpDepartID { get; set; }
        /// <summary>
        /// 三方协议合同号
        /// </summary>
        [Description("三方协议合同号")]
        public string AgreementNo { get; set; }
        /// <summary>
        /// U8虚拟冻结金额
        /// </summary>
        [Description("U8虚拟冻结金额")]
        public decimal? FreezeMoney { get; set; }
        /// <summary>
        /// 添加加盟商是否收费
        /// </summary>
        [Description("添加加盟商是否收费")]
        public string CollectFee { get; set; }
        /// <summary>
        /// 保险预留金额
        /// </summary>
        [Description("保险预留金额")]
        public decimal? BxP { get; set; }
        /// <summary>
        /// 客户推荐人ID:cid
        /// </summary>
        [Description("客户推荐人ID:cid")]
        public string CustomerGuideID { get; set; }
        /// <summary>
        /// 欠款天数
        /// </summary>
        [Description("欠款天数")]
        public int? DebtDay { get; set; }
        /// <summary>
        /// 票台
        /// </summary>
        [Description("票台")]
        public string FlightAgency { get; set; }
        /// <summary>
        /// 0散出 1团队 2冲量 3自排
        /// </summary>
        [Description("0散出 1团队 2冲量 3自排")]
        public int? IsTeamOrder { get; set; }
        /// <summary>
        /// 微信公众平台客户ID
        /// </summary>
        [Description("微信公众平台客户ID")]
        public string OpenID { get; set; }
        /// <summary>
        /// U8帐号是否被激活
        /// </summary>
        [Description("U8帐号是否被激活")]
        public string IsU8Activated { get; set; }
        /// <summary>
        /// U8密保问题1
        /// </summary>
        [Description("U8密保问题1")]
        public int? U8PwdSafeId1 { get; set; }
        /// <summary>
        /// U8密保问题2
        /// </summary>
        [Description("U8密保问题2")]
        public int? U8PwdSafeId2 { get; set; }
        /// <summary>
        /// U8密保问题3
        /// </summary>
        [Description("U8密保问题3")]
        public int? U8PwdSafeId3 { get; set; }
        /// <summary>
        /// U8密保问题1答案
        /// </summary>
        [Description("U8密保问题1答案")]
        public string U8PwdSafeAnswer1 { get; set; }
        /// <summary>
        /// U8密保问题2答案
        /// </summary>
        [Description("U8密保问题2答案")]
        public string U8PwdSafeAnswer2 { get; set; }
        /// <summary>
        /// U8密保问题3答案
        /// </summary>
        [Description("U8密保问题3答案")]
        public string U8PwdSafeAnswer3 { get; set; }
        /// <summary>
        /// 二级审核人
        /// </summary>
        [Description("二级审核人")]
        public int? CPIDSecond { get; set; }
        /// <summary>
        /// 介绍人
        /// </summary>
        [Description("介绍人")]
        public string UserSourcePerson { get; set; }
        /// <summary>
        /// 第三方系统员工工号
        /// </summary>
        [Description("第三方系统员工工号")]
        public string OtherSystemEmployeeID { get; set; }
        /// <summary>
        /// 邮件重置密码的验证码
        /// </summary>
        [Description("邮件重置密码的验证码")]
        public string EmailCode { get; set; }
        /// <summary>
        /// 出票短信抄送号码，多条用/隔开
        /// </summary>
        [Description("出票短信抄送号码，多条用/隔开")]
        public string CcMessagePhone { get; set; }
        /// <summary>
        /// 背景颜色
        /// </summary>
        [Description("背景颜色")]
        public string BackgroundColor { get; set; }
        /// <summary>
        /// 复制此客户的员工
        /// </summary>
        [Description("复制此客户的员工")]
        public string ResponsibleOid { get; set; }
        /// <summary>
        /// 限制下单金额，同行T+1规则
        /// </summary>
        [Description("限制下单金额，同行T+1规则")]
        public decimal? LimitAmount { get; set; }
        /// <summary>
        /// 客户级别
        /// </summary>
        [Description("客户级别")]
        public int? CustomerLevel { get; set; }
        /// <summary>
        /// 当前客户趋势
        /// </summary>
        [Description("当前客户趋势")]
        public int? LevelTrend { get; set; }
        /// <summary>
        ///  最近客户趋势(目前获取最近三个月的趋势，/分割)
        /// </summary>
        [Description(" 最近客户趋势(目前获取最近三个月的趋势，/分割)")]
        public string RecentLevelTrend { get; set; }
        /// <summary>
        /// 评级执行时间
        /// </summary>
        [Description("评级执行时间")]
        public DateTime? RunLevelTime { get; set; }
        /// <summary>
        /// 总产生积分
        /// </summary>
        [Description("总产生积分")]
        public decimal? EngenderIntegral { get; set; }
        /// <summary>
        /// 总消费积分
        /// </summary>
        [Description("总消费积分")]
        public decimal? ConsumeIntegral { get; set; }
        /// <summary>
        /// 总过期积分
        /// </summary>
        [Description("总过期积分")]
        public decimal? OverdueIntegral { get; set; }
        /// <summary>
        /// 剩余总积分
        /// </summary>
        [Description("剩余总积分")]
        public decimal? OverplusIntegral { get; set; }
        /// <summary>
        /// 是否展示票号使用状态
        /// </summary>
        [Description("是否展示票号使用状态")]
        public string IsShowTicketNoStatus { get; set; }
        /// <summary>
        /// 是否空号
        /// </summary>
        [Description("是否空号")]
        public bool? IsEmptyNumber { get; set; }
        /// <summary>
        /// 第一笔交易时间
        /// </summary>
        [Description("第一笔交易时间")]
        public DateTime? FirstTransactionTime { get; set; }
        /// <summary>
        /// QQ号码
        /// </summary>
        [Description("QQ号码")]
        public string QQNumber { get; set; }
        /// <summary>
        /// 微信号
        /// </summary>
        [Description("微信号")]
        public string WXNumber { get; set; }
        /// <summary>
        /// 个人银行卡号
        /// </summary>
        [Description("个人银行卡号")]
        public string BankCardNo { get; set; }
        /// <summary>
        /// 服务费规则Id
        /// </summary>
        public int? SfcId { get; set; }
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
        /// <summary>
        /// 是否显示临客
        /// </summary>
        public int? IsShowTemporaryPassenger { get; set; }


        /// <summary>
        /// 是否显示报表
        /// </summary>
        [Description("是否显示报表")]
        public int? IsShowReport { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        [Description("头像路径")]
        public string HeadPictureUri { get; set; }
        /// <summary>
        /// 是否允许使用保险  0否 1是
        /// </summary>
        [Description("是否允许使用保险  0否 1是")]
        public int IsAllowUserInsurance { get; set; }
        /// <summary>
        /// 共享航班显示  0否 1是
        /// </summary>
        public int IsShareFly { get; set; }
        /// <summary>
        /// 协议价格是否单独展示  0否 1是
        /// </summary>
        public int IsXYPrice { get; set; }
        /// <summary>
        /// 是否显示全部舱位  0否 1是
        /// </summary>
        public int IsAllSeat { get; set; }
        /// <summary>
        /// 出行原因必填  0否 1是
        /// </summary>
        public int IsTravelReason { get; set; }
        /// <summary>
        /// 短信验证控制  0否 1是
        /// </summary>
        public int IsNoteVerify { get; set; }
        /// <summary>
        /// 是否显示最高舱位  0否 1是
        /// </summary>
        public int? IsHeightSeat { get; set; }
        /// <summary>
        /// 是否显示全部订单
        /// </summary>
        [Description("是否显示全部订单")]
        public int? IsShowAllOrder { get; set; }
        /// <summary>
        /// 是否可以查看公司账单
        /// </summary>
        public int? IsShowCorpBill { get; set; }
    }
}
