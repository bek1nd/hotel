using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Train.Server;

namespace Mzl.IBLL.Train.RequestInterface
{
    /// <summary>
    /// 占位接口
    /// </summary>
    public interface IRequestHoldSeatBll
    {
        /// <summary>
        /// 请求第三方占位接口
        /// </summary>
        /// <returns></returns>
        TraOrderSubmitResponseModel RequestHoldSeatInterface(TraOrderSubmitModel model);
    }
}
