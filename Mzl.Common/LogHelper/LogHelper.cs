using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Mzl.Common.ConfigHelper;
using RabbitMQ.Client;

namespace Mzl.Common.LogHelper
{
    public sealed class LogHelper
    {
        public static void SetConfig()
        {
            log4net.Config.XmlConfigurator.Configure();
        }


        /// <summary>
        /// 写日志(使用log4net组件)
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLog(string content)
        {
            LogManager.GetLogger(typeof(LogHelper)).Info(content);
        }

        public static void WriteLog(string content, string type)
        {
            SetConfig();
            ILog loginfo = LogManager.GetLogger(type);
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(content);
            }
        }

        public static void WriteLogByMq(string content, string type)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                UserName = "Admin",
                Password = "Mzl123456",
                HostName = "192.168.1.117",
                VirtualHost = "/"
            };

            using (IConnection conn = factory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    string exchangeName = "ApiLog_Exchange";
                    channel.ExchangeDeclare(exchangeName, "direct", true);
                    string routingKey = "ApiLog";
                    byte[] messageBodyBytes = Encoding.UTF8.GetBytes(content);
                    channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);
                }
            }

        }
    }
}
