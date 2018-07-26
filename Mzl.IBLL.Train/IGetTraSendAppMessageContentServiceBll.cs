using Mzl.Framework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.SendAppMessage;

namespace Mzl.IBLL.Train
{
    /// <summary>
    /// 获取火车类型的app推送信息
    /// </summary>
    public interface IGetTraSendAppMessageContentServiceBll : IBaseServiceBll
    {
        void GetSendAppMessage(List<SendAppMessageModel> sendAppMessageModels);
    }
}
