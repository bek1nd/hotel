using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.Common.ConfigHelper
{
    public class AppSettingsHelper
    {
        public static string GetAppSettings(AppSettingsEnum appSettingsEnum)
        {
            return ConfigurationManager.AppSettings[appSettingsEnum.ToString()];
        }
        /// <summary>
        /// 获取自定义config
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="xmlNode"></param>
        /// <param name="singleNodeName"></param>
        /// <returns></returns>
        public static string GetConfig(string configName,string xmlNode,string singleNodeName)
        {
            string str = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + @"\App_Data\"+ configName;
            var selectSingleNode = XMLHelper.XMLHelper.ReadXmlNode(str, xmlNode).SelectSingleNode(singleNodeName);
            if (selectSingleNode != null)
                return selectSingleNode.InnerText.Trim();
            return string.Empty;
        }
    }

    public enum AppSettingsEnum
    {
        /// <summary>
        /// 春运时间段
        /// </summary>
        ChunYun,
        /// <summary>
        /// OA系统Token
        /// </summary>
        OAToken,
        /// <summary>
        /// 是否是生产环境
        /// </summary>
        IsServer,
        /// <summary>
        /// 服务器IP
        /// </summary>
        ServerIP,
        /// <summary>
        /// 不使用IOC注入的控制器名称
        /// </summary>
        IOCBlackList,
        /// <summary>
        /// 无需action验证的route
        /// </summary>
        ValidBlackList,
        /// <summary>
        /// 改签审核邮件IP
        /// </summary>
        ModAuditEmail,
        /// <summary>
        /// 上传文件上限大小
        /// </summary>
        MaxFileSize,
        /// <summary>
        /// 机票二级审核IP
        /// </summary>
        FltOrderSecondAuditEmail,
        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        DbContext,
        /// <summary>
        /// 上传文件路径
        /// </summary>
        UploadFile,
        /// <summary>
        /// 允许app版本号
        /// </summary>
        AllowAppVision,
        /// <summary>
        /// 按照人名判断是否在白名单内的航司
        /// </summary>
        WhiteListByName,
        /// <summary>
        /// App推送Host
        /// </summary>
        Host,
        AppId,
        AppKey,
        AppSecret,
        MasterSecret,
        /// <summary>
        /// 安卓设备Id
        /// </summary>
        ClientId,
        /// <summary>
        /// IOS系统的DeviceToken
        /// </summary>
        DeviceToken,
        VisionAndroidUrl,
        VisionIosUrl,
        VisionMessage,
        /// <summary>
        /// 线上测试帐号Id
        /// </summary>
        TestCid,
        /// <summary>
        /// 是否允许火车抢票
        /// </summary>
        IsAllowTrainGrabTicket,
        /// <summary>
        /// 注册后发送Email的邮箱
        /// </summary>
        ReginsterSendEmail,
        /// <summary>
        /// RabbitMq地址
        /// </summary>
        RabbitMqUri,
        /// <summary>
        /// 不允许使用火车的公司
        /// </summary>
        NotAllowUserTrain,
        /// <summary>
        /// App意见反馈邮件接收者
        /// </summary>
        AppOptionEmailTo
    }
}
