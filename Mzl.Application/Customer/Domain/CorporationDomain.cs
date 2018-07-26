using Mzl.IApplication.Customer.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.CostCenter;
using Mzl.IBLL.Customer.CostCenter.BLL;
using Mzl.IBLL.Customer.ProjectName.BLL;
using Mzl.DomainModel.Customer.ProjectName;
using Mzl.IBLL.Customer.ServiceFee.BLL;
using Mzl.DomainModel.Customer.ServiceFee;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.DomainModel.Customer.Corp;
using Mzl.IBLL.Customer.Customer.BLL;

namespace Mzl.Application.Customer.Domain
{
    public class CorporationDomain : ICorporationDomain
    {
        private readonly ICostCenterBLL<CostCenterModel> _costCenterBll;
        private readonly IProjectNameBLL<ProjectNameModel> _projectNameBll;
        private readonly IServiceFeeConfigBLL<ServiceFeeConfigModel> _serviceFeeConfigBll;
        private readonly IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel> _serviceFeeConfigDetailsBll;
        private readonly ICorporationBLL<CorporationModel> _corporationBll;
        private readonly ICustomerBLL<CustomerInfoModel> _customerBll;

        public CorporationDomain(ICorporationBLL<CorporationModel> corporationBll)
        {
            _corporationBll = corporationBll;
        }
        public CorporationDomain(ICostCenterBLL<CostCenterModel> costCenterBll)
        {
            _costCenterBll = costCenterBll;
        }
        public CorporationDomain(IProjectNameBLL<ProjectNameModel> projectNameBll)
        {
            _projectNameBll = projectNameBll;
        }
        public CorporationDomain(IProjectNameBLL<ProjectNameModel> projectNameBll, ICostCenterBLL<CostCenterModel> costCenterBll)
        {
            _projectNameBll = projectNameBll;
            _costCenterBll = costCenterBll;
          
        }

        public CorporationDomain(IServiceFeeConfigBLL<ServiceFeeConfigModel> serviceFeeConfigBll
            , IServiceFeeConfigDetailsBLL<ServiceFeeConfigDetailsModel> serviceFeeConfigDetailsBll
            , ICorporationBLL<CorporationModel> corporationBll, IProjectNameBLL<ProjectNameModel> projectNameBll,
            ICostCenterBLL<CostCenterModel> costCenterBll, ICustomerBLL<CustomerInfoModel> customerBll)
        {
            _serviceFeeConfigBll = serviceFeeConfigBll;
            _serviceFeeConfigDetailsBll = serviceFeeConfigDetailsBll;
            _corporationBll = corporationBll;
            _projectNameBll = projectNameBll;
            _costCenterBll = costCenterBll;
            _customerBll = customerBll;
        }

        public List<CostCenterModel> GetCostCenter(string corpId)
        {
            return _costCenterBll.GetCostCenterListByCorpId(corpId);
        }

        public List<ProjectNameModel> GetProjectName(string corpId)
        {
            return _projectNameBll.GetProjectNameByCorpId(corpId);
        }

        public decimal GetServiceFeeByCorpId(int cid,string type)
        {
            decimal serviceFee = 0;
            CustomerInfoModel customerInfoModel = _customerBll.GetCustomerByCid(cid);
            int sfcid = 0;
            if (!string.IsNullOrEmpty(customerInfoModel.CorpId))//企业客户
            {
                CorporationModel corporationModel = _corporationBll.GetCorpInfoByCorpId(customerInfoModel.CorpId);
                if (!corporationModel.SfcId.HasValue || corporationModel.SfcId == 0)
                {
                    serviceFee= 0;
                }
                else
                {
                    sfcid = corporationModel.SfcId.Value;
                }
               
            }
            else
            {
                if (!customerInfoModel.SfcId.HasValue || customerInfoModel.SfcId == 0)
                {
                    serviceFee = 0;
                }
                else
                {
                    sfcid = customerInfoModel.SfcId.Value;
                }
             
            }

            if (sfcid != 0)
            {
                List<ServiceFeeConfigDetailsModel> serviceFeeConfigDetailsModels =
               _serviceFeeConfigDetailsBll.GetServiceFeeConfigDetailsBySfcId(sfcid);
                //判断当前时间中是否存在服务费
                DateTime nowTime = DateTime.Now;
                string nowDate = nowTime.ToString("yyyy-MM-dd");

                foreach (var detail in serviceFeeConfigDetailsModels)
                {
                    if (nowTime > Convert.ToDateTime(nowDate + " " + detail.BeginTime) &&
                        nowTime < Convert.ToDateTime(nowDate + " " + detail.EndTime))
                    {
                        if (type == "tra")
                        {
                            if (detail.TrainServiceFee != null)
                                serviceFee= detail.TrainServiceFee.Value;
                        }
                        else if (type == "traGrab")
                        {
                            if (detail.TrainGrabTicketServiceFee != null)
                            {
                                serviceFee = detail.TrainGrabTicketServiceFee.Value;
                            }
                        }
                    }
                }
            }

            decimal defaultPrice = 5;
            if (type == "traGrab"&& serviceFee==0)
            {
                serviceFee = defaultPrice;
            }

            return serviceFee;
        }

        public CorporationModel GetCorporationByCorId(string corpid)
        {
            return _corporationBll.GetCorpInfoByCorpId(corpid);
        }
    }
}
