using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.SendAppMessage
{
    /// <summary>
    /// 获取审批类型app推送内容
    /// </summary>
    public interface IGetAduitSendAppMessageContentServiceBll: IBaseServiceBll
    {
        /// <summary>
        /// 获取审批类型app推送内容
        /// </summary>
        /// <param name="sendAppMessageModels"></param>
        void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels);
    }
}
