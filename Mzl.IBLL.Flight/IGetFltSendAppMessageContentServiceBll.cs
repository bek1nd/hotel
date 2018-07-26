using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Flight
{
    /// <summary>
    /// 获取机票类型的app推送信息
    /// </summary>
    public interface IGetFltSendAppMessageContentServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 获取机票类型的app推送信息
        /// </summary>
        /// <param name="sendAppMessageModels"></param>
        void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels);
        void GetSendEmailMessage(List<SendAppMessageModel> sendAppMessageModels);
    }
}
