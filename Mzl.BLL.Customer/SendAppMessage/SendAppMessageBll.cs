using com.igetui.api.openservice;
using com.igetui.api.openservice.igetui;
using com.igetui.api.openservice.igetui.template;
using com.igetui.api.openservice.payload;
using Mzl.Common.ConfigHelper;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.SendAppMessage;
using Newtonsoft.Json;

namespace Mzl.BLL.Customer.SendAppMessage
{
    /// <summary>
    /// App推送功能
    /// </summary>
    public class SendAppMessageBll : BaseBll, ISendAppMessageBll
    {
        private static readonly string Host = AppSettingsHelper.GetAppSettings(AppSettingsEnum.Host);
        private static readonly string Appid = AppSettingsHelper.GetAppSettings(AppSettingsEnum.AppId);
        private static readonly string Appkey = AppSettingsHelper.GetAppSettings(AppSettingsEnum.AppKey);
        private static readonly string Mastersecret = AppSettingsHelper.GetAppSettings(AppSettingsEnum.MasterSecret);

        public SendAppMessageResultModel SendAppMessage(SendAppContentModel sendAppMessageModel)
        {
            IGtPush push = new IGtPush(Host, Appkey, Mastersecret);

            Target target = new Target();
            target.appId = Appid;
            target.clientId = sendAppMessageModel.ClientId;

            ITemplate template = null;
            if (sendAppMessageModel.ClientType == "A")
            {
                //template = NotificationTemplateDemo(sendAppMessageModel.Title, sendAppMessageModel.Text,
                //    sendAppMessageModel.Content);

                template = TransmissionTemplateDemo(sendAppMessageModel.Title, sendAppMessageModel.Text,
                    sendAppMessageModel.Content);
            }
            else
            {
                template = TransmissionTemplateIOS(sendAppMessageModel.Title, sendAppMessageModel.Content,
                    sendAppMessageModel.Text);
            }


            // 单推消息模型
            SingleMessage message = new SingleMessage();
            message.IsOffline = true; // 用户当前不在线时，是否离线存储,可选
            message.OfflineExpireTime = 1000 * 3600 * 12; // 离线有效时间，单位为毫秒，可选
            message.Data = template;
            //判断是否客户端是否wifi环境下推送，2为4G/3G/2G，1为在WIFI环境下，0为不限制环境
            //message.PushNetWorkType = 1;  

            string pushResult = push.pushMessageToSingle(message, target);

            SendAppMessageResultModel result = JsonConvert.DeserializeObject<SendAppMessageResultModel>(pushResult);
            result.ResultInfo = pushResult;
            return result;
        }

        #region 消息模版

        /// <summary>
        /// 点击通知打开应用
        /// </summary>
        /// <param name="title">通知栏标题</param>
        /// <param name="text">通知栏内容</param>
        /// <param name="content">透传内容</param>
        /// <param name="logo">通知栏显示本地图片</param>
        /// <param name="logUrl">通知栏显示网络图标</param>
        /// <param name="transmissionType">应用启动类型，1：强制应用启动 2：等待应用启动</param>
        /// <param name="isRing">接收到消息是否响铃，true：响铃 false：不响铃</param>
        /// <param name="isVibrate">接收到消息是否震动，true：震动 false：不震动</param>
        /// <param name="isClearable">接收到消息是否可清除，true：可清除 false：不可清除</param>
        /// <returns></returns>
        private NotificationTemplate NotificationTemplateDemo(string title, string text, string content,
            string logo = "", string logUrl = "", string transmissionType = "1", bool isRing = true,
            bool isVibrate = true, bool isClearable = true)
        {
            NotificationTemplate template = new NotificationTemplate();
            template.AppId = Appid;
            template.AppKey = Appkey;
            //通知栏标题
            template.Title = title;
            //通知栏内容
            template.Text = text;
            //通知栏显示本地图片
            template.Logo = logo;
            //通知栏显示网络图标
            template.LogoURL = logUrl;
            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionType = transmissionType;
            //透传内容
            template.TransmissionContent = content;
            //接收到消息是否响铃，true：响铃 false：不响铃
            template.IsRing = isRing;
            //接收到消息是否震动，true：震动 false：不震动
            template.IsVibrate = isVibrate;
            //接收到消息是否可清除，true：可清除 false：不可清除
            template.IsClearable = isClearable;
            //设置客户端展示时间
            //String begin = "2015‐03‐06 14:36:10";
            //String end = "2015‐03‐06 14:46:20";
            //template.setDuration(begin, end);
            return template;
        }

        /// <summary>
        /// 透传模版
        /// </summary>
        /// <returns></returns>
        private TransmissionTemplate TransmissionTemplateDemo(string title, string text, string content)
        {
            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = Appid;
            template.AppKey = Appkey;
            //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionType = "2";
            //透传内容
            template.TransmissionContent = content;

            #region APN高级推送
            ////APN高级推送
            //APNPayload apnpayload = new APNPayload();
            //DictionaryAlertMsg alertMsg = new DictionaryAlertMsg();
            //alertMsg.Body = text;
            //alertMsg.ActionLocKey = "";
            //alertMsg.LocKey = "";
            //alertMsg.addLocArg("");
            //alertMsg.LaunchImage = "";
            //alertMsg.Title = title;
            //alertMsg.TitleLocKey = "";
            //alertMsg.addTitleLocArg("");
            //apnpayload.AlertMsg = alertMsg;
            //apnpayload.Badge = 1;//应用icon上显示的数字 
            //apnpayload.ContentAvailable = 1;
            //apnpayload.Category = "";
            //apnpayload.Sound = "test1.wav";
            //apnpayload.addCustomMsg("", "");
            //template.setAPNInfo(apnpayload);
            #endregion

            return template;
        }

        public static TransmissionTemplate TransmissionTemplateIOS(string title, string content, string text)
        {
            TransmissionTemplate template = new TransmissionTemplate();
            template.AppId = Appid;
            template.AppKey = Appkey;
            template.TransmissionType = "1"; //应用启动类型，1：强制应用启动 2：等待应用启动
            template.TransmissionContent = content; //透传内容

            #region iOS简单推送
            //iOS简单推送
            //APNPayload apnpayload = new APNPayload();
            //SimpleAlertMsg alertMsg = new SimpleAlertMsg(content);
            //apnpayload.AlertMsg = alertMsg;
            //apnpayload.Badge = 11;
            //apnpayload.ContentAvailable = 1;
            //apnpayload.Category = "";
            //apnpayload.Sound = "";
            //apnpayload.addCustomMsg("", "");

            //template.setAPNInfo(apnpayload);
            #endregion

            #region APN高级推送
            //APN高级推送
            APNPayload apnpayload = new APNPayload();
            DictionaryAlertMsg alertMsg = new DictionaryAlertMsg();
            alertMsg.Body = text;
            alertMsg.ActionLocKey = "";
            alertMsg.LocKey = "";
            alertMsg.addLocArg("");
            alertMsg.LaunchImage = "";
            //iOS8.2支持字段
            alertMsg.Title = title;
            alertMsg.TitleLocKey = "";
            alertMsg.addTitleLocArg("");
            apnpayload.AlertMsg = alertMsg;
            //apnpayload.Badge = 1;//应用icon上显示的数字 
            apnpayload.ContentAvailable = 1;
            apnpayload.Category = "";
            apnpayload.Sound = "test1.wav";
            apnpayload.addCustomMsg("", "");
            template.setAPNInfo(apnpayload);
            #endregion

            //设置客户端展示时间
            //String begin = "2015‐03‐06 14:28:10";//String end = "2015‐03‐06 14:38:20";
            //template.setDuration(begin, end);
            return template;
        }
        #endregion

    }
}
