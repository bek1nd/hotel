using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Mzl.Common.EmailHelper
{
    /// <summary>
    /// 发送邮件
    /// </summary>
    public class EmailHelper
    {
        private static string Displayname = "妙知旅";
        private static string EmailAddress = "it@mojory.cn";
        private static string EmailPwd = "Mzl123456";
        private static string EmailHost = "smtp.mojory.cn";
       
        #region 邮件发送
        /// <summary>
        /// 邮件发送，给定发送者信息
        /// </summary>   
        /// <param name="attachmentName">附件fileName，为空时刚不发送附件</param>
        /// <param name="imgList">邮件内容图片（不插入可为空）List<KeyValuePair<图片id,图片绝对路径>></param>
        /// <param name="emailSubject">邮件主题</param>
        /// <param name="emailBody">邮件内容</param>
        /// <param name="emailTo">邮件接收者</param>
        /// <param name="emailCopy">邮件抄送</param>
        /// <returns>返回发送状态的bool值</returns>    
        public static  bool SendEmail(string attachmentName, string emailSubject, string[] emailCopy, List<KeyValuePair<string, string>> imgList, string emailBody, string emailTo)
        {
            try
            {
                if (string.IsNullOrEmpty(emailTo))
                    return false;

                SmtpClient client = new SmtpClient();
                client.Host = EmailHost; //发送邮件所使用的Smtp事务的主机名称或IP地址
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(EmailAddress, EmailPwd);
                client.DeliveryMethod = SmtpDeliveryMethod.Network; //电子邮件通过网络发送到Smtp服务器

                MailAddress mailFrom = new MailAddress(EmailAddress, Displayname, Encoding.UTF8);
                MailAddress mailTo = new MailAddress(emailTo);
                MailMessage message = new MailMessage(mailFrom, mailTo); //(发件人地址,收件人地址)
                message.Subject = emailSubject; //邮件主题
                //message.Body = emailBody;　　 //邮件内容
                message.BodyEncoding = System.Text.Encoding.GetEncoding("gb2312"); //邮件正文的编码方式
                message.IsBodyHtml = true;

                AlternateView htmlBody = AlternateView.CreateAlternateViewFromString(emailBody, null, "text/html");

                if (imgList != null && imgList.Count > 0)
                {
                    foreach (KeyValuePair<string, string> kv in imgList)
                    {
                        LinkedResource lrImage = new LinkedResource(@"" + kv.Value, "image/gif");
                        lrImage.ContentId = kv.Key; //此处的ContentId 对应 htmlBodyContent 内容中的 cid: ，如果设置不正确，请不会显示图片
                        htmlBody.LinkedResources.Add(lrImage);
                    }

                }

                message.AlternateViews.Add(htmlBody);

                if (!(emailCopy == null || emailCopy.Length == 0))
                {
                    foreach (string s in emailCopy)
                    {
                        message.CC.Add(s);
                    }

                }
                //以下为附件处理过程
                string attahmentName = attachmentName;
                if (!string.Equals(attahmentName, null) && !string.Equals(attahmentName, ""))
                {
                    Attachment data = new Attachment(attahmentName, System.Net.Mime.MediaTypeNames.Application.Octet);
                    message.Attachments.Add(data);
                }
                //发送邮件
                try
                {
                    client.Send(message);

                    return true;
                }
                catch (Exception ex)
                {
                    //
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion
    }
}
