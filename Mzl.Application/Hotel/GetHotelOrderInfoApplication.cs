using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Hotel.Order;
using Mzl.Framework.Base;
using Mzl.IApplication.Hotel;
using Mzl.IBll.Hotel.GetOrderInfo;
using Mzl.UIModel.Hotel.GetOrderInfo;

namespace Mzl.Application.Hotel
{
    internal class GetHotelOrderInfoApplication : BaseApplicationService, IGetHotelOrderInfoApplication
    {
        private readonly IGetHotelOrderInfoServiceBll _getHotelOrderInfoServiceBll;

        public GetHotelOrderInfoApplication(IGetHotelOrderInfoServiceBll getHotelOrderInfoServiceBll)
        {
            _getHotelOrderInfoServiceBll = getHotelOrderInfoServiceBll;
        }

        public GetHotelOrderInfoResponseViewModel GetHotelOrderInfoByOrderId(GetHotelOrderInfoRequestViewModel request)
        {
            HotelOrderInfoModel hotelOrderInfoModel =
                _getHotelOrderInfoServiceBll.GetHotelOrderInfoByOrderId(request.OrderId);

            GetHotelOrderInfoResponseViewModel viewModel = Mapper.Map<HotelOrderInfoModel, GetHotelOrderInfoResponseViewModel>(hotelOrderInfoModel);

            return viewModel;
        }
    }
}
