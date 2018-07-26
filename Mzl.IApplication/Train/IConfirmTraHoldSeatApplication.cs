using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.UIModel.Train.Order;

namespace Mzl.IApplication.Train
{
    /// <summary>
    /// 确认火车占位功能
    /// </summary>
    public interface IConfirmTraHoldSeatApplication : IBaseApplication
    {
        /// <summary>
        /// 确认火车占位功能
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ConfirmTraHoldSeatResponseViewModel ConfirmTraHoldSeat(ConfirmTraHoldSeatRequestViewModel request);
    }
}
