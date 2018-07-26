using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.Framework.Base;
using Mzl.IApplication.Flight;
using Mzl.IBLL.Flight;
using Mzl.UIModel.Flight;
using AutoMapper;

namespace Mzl.Application.Flight
{
    internal class GetUnAvailablePassengerApplication : BaseApplicationService, IGetUnAvailablePassengerApplication
    {
        private readonly IGetUnAvailablePassengerServiceBll _getUnAvailablePassengerServiceBll;

        public GetUnAvailablePassengerApplication(IGetUnAvailablePassengerServiceBll getUnAvailablePassengerServiceBll)
        {
            _getUnAvailablePassengerServiceBll = getUnAvailablePassengerServiceBll;
        }

        /// <summary>
        /// 获取信息不可用的乘机人信息
        /// </summary>
        /// <param name="queryModel"></param>
        /// <returns></returns>
        public GetUnAvailablePassengerListResponseViewModel GetUnAvailablePassengerList(
            GetUnAvailablePassengerRequestViewModel queryModel)
        {

            GetUnAvailablePassengerQueryModel query =
                Mapper.Map< GetUnAvailablePassengerRequestViewModel, GetUnAvailablePassengerQueryModel>(queryModel);
            GetUnAvailablePassengerModel resultModel =
                _getUnAvailablePassengerServiceBll.GetUnAvailablePassengerList(query);

            return Mapper.Map<GetUnAvailablePassengerModel, GetUnAvailablePassengerListResponseViewModel>(resultModel);

        }
    }
}
