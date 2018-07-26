using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.RequestInterface
{
    /// <summary>
    /// 进行占位
    /// </summary>
    public interface IRequestHoldSeatServiceBll: IBaseServiceBll
    {
        /// <summary>
        /// 进行占位
        /// </summary>
        /// <param name="addModel"></param>
        /// <returns></returns>
        TraOrderSubmitResponseModel RequestHoldSeat(TraAddOrderModel addModel);
    }
}
