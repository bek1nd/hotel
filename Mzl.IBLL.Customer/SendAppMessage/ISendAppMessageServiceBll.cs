using System.Collections.Generic;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.SendAppMessage
{
    public interface ISendAppMessageServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 获取待发送信息
        /// </summary>
        List<SendAppMessageModel> Get();

        /// <summary>
        /// 发送信息
        /// </summary>
        void Send(List<SendAppMessageModel> sendAppMessageModels);

    }
}
