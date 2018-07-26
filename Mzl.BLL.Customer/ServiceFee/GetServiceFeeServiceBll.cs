using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.EntityModel.Customer.Corporation.ServiceFee;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.ServiceFee;
using Mzl.IDAL.Customer.ServiceFee;

namespace Mzl.BLL.Customer.ServiceFee
{
    internal class GetServiceFeeServiceBll: BaseServiceBll,IGetServiceFeeServiceBll
    {
        private readonly IServiceFeeConfigDetailsDal _serviceFeeConfigDetailsDal;

        public GetServiceFeeServiceBll(IServiceFeeConfigDetailsDal serviceFeeConfigDetailsDal)
        {
            _serviceFeeConfigDetailsDal = serviceFeeConfigDetailsDal;
        }

        public ServiceFeeInfoModel GetServiceFeeByCorpId(string corpId,int sfcId)
        {
            if (string.IsNullOrEmpty(corpId))
                return new ServiceFeeInfoModel();

            return GetServiceFeeBySfcid(sfcId);
        }

        public ServiceFeeInfoModel GetServiceFeeBySfcid(int sfcId)
        {
            ServiceFeeInfoModel serviceFeeInfoModel = new ServiceFeeInfoModel();

            if (sfcId == 0)
                return serviceFeeInfoModel;

            List<ServiceFeeConfigDetailsEntity> serviceFeeConfigDetailsModels =
                _serviceFeeConfigDetailsDal.Query<ServiceFeeConfigDetailsEntity>(n => n.SfcId == sfcId, true).ToList();

            if (serviceFeeConfigDetailsModels == null || serviceFeeConfigDetailsModels.Count == 0)
                return serviceFeeInfoModel;


            //判断当前时间中是否存在服务费
            DateTime nowTime = DateTime.Now;
            string nowDate = nowTime.ToString("yyyy-MM-dd");

            foreach (var detail in serviceFeeConfigDetailsModels)
            {
                try
                {
                    if (nowTime > Convert.ToDateTime(nowDate + " " + detail.BeginTime) &&
                    nowTime < Convert.ToDateTime(nowDate + " " + detail.EndTime))
                    {
                        if (detail.TrainServiceFee.HasValue)
                            serviceFeeInfoModel.TrainServiceFee = detail.TrainServiceFee.Value;
                        if (detail.TrainGrabTicketServiceFee.HasValue)
                            serviceFeeInfoModel.TrainGrabTicketServiceFee = detail.TrainGrabTicketServiceFee.Value;
                        if (detail.HotelServiceFee.HasValue)
                            serviceFeeInfoModel.HotelServiceFee = detail.HotelServiceFee.Value;
                        if (detail.NightServicefee.HasValue)
                            serviceFeeInfoModel.NightServicefee = detail.NightServicefee.Value;
                        if (detail.ServiceFee.HasValue)
                            serviceFeeInfoModel.ServiceFee = detail.ServiceFee.Value;
                        if (detail.NightServicefeeRate.HasValue)
                            serviceFeeInfoModel.NightServicefeeRate = detail.NightServicefeeRate.Value;

                    }
                }
                catch (Exception ex)
                {
                }

            }

            return serviceFeeInfoModel;
        }

      
    }
}
