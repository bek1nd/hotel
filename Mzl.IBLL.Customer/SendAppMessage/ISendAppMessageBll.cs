using Mzl.DomainModel.Customer.SendAppMessage;

namespace Mzl.IBLL.Customer.SendAppMessage
{
    /// <summary>
    /// 推送App消息
    /// </summary>
    public interface ISendAppMessageBll
    {
        SendAppMessageResultModel SendAppMessage(SendAppContentModel sendAppMessageModel);
    }
}
