using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.CopyOrder;
using Mzl.Framework.Base;
using Mzl.IApplication.Hotel;
using Mzl.IBll.Hotel.CopyOrder;
using Mzl.UIModel.Hotel.CopyOrder;

namespace Mzl.Application.Hotel
{
    internal class CopyHotelOrderApplication : BaseApplicationService, ICopyHotelOrderApplication
    {
        private readonly ICopyHotelOrderServiceBll _copyHotelOrderServiceBll;

        public CopyHotelOrderApplication(ICopyHotelOrderServiceBll copyHotelOrderServiceBll)
        {
            _copyHotelOrderServiceBll = copyHotelOrderServiceBll;
        }


        public CopyHotelOrderResponseViewModel CopHotelOrder(CopyHotelOrderRequestViewModel request)
        {
            int orderid = 0;
            CopyHotelOrderModel copyHotelOrderModel = Mapper.Map<CopyHotelOrderRequestViewModel, CopyHotelOrderModel>(request);

            using (var transaction = this.Context.Database.BeginTransaction())
            {
                try
                {
                    //新增复制订单
                    orderid = _copyHotelOrderServiceBll.CopyOrder(copyHotelOrderModel);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }

            return new CopyHotelOrderResponseViewModel() { OrderId = orderid };
        }
    }
}
