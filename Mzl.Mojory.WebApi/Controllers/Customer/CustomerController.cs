using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Mzl.UIModel.Customer.Login;
using Mzl.Mojory.WebApi.Config;
using Mzl.IApplication.Token.Factory;
using Mzl.Application.Token.Factory;
using Mzl.IApplication.Customer.Factory;
using Mzl.Application.Customer.Factory;
using Mzl.Common.AutoMapperHelper;
using Mzl.Common.PostHelper;
using Mzl.DomainModel.Customer.Base;
using Mzl.DomainModel.Customer.Login;
using Mzl.UIModel.Base;
using Mzl.Common.Exceptions;
using Mzl.Common.EnumHelper;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Customer.Passenger;
using Mzl.UIModel.Train.Order;
using Mzl.UIModel.Customer.Customer;
using Mzl.DomainModel.Customer.Corp;
using Mzl.DomainModel.Customer.Identification;
using Mzl.UIModel.Customer.Identification;
using Mzl.UIModel.Passenger;
using Microsoft.Practices.Unity;
using Mzl.Common.Ioc;
using Mzl.IApplication.Common;
using Mzl.IApplication.Customer;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 客户业务控制器
    /// </summary>
    public class CustomerController : ApiController
    {
        /// <summary>
        /// 差旅网站登录
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<LoginResponseViewModel> MojoryLogin([FromBody]LoginRequestViewModel request)
        {
            string token = this.GetToken();
            ICustomerDomainFactory factory = new CustomerDomainFactory();
            var domain=factory.CreateVerifyCustomerDomainObj();

            CustomerLoginModel loginModel = new CustomerLoginModel
            {
                Password = request.Password,
                UserId = request.UserId,
                CorpId = request.CorpId,
                Token = token,
                ClientId = request.ClientId,
                ClientType = this.GetOrderSource(),
                IsCheckClientId = request.IsCheckClientId
            };
            //为了appstore审核通过
            /*
            if (request.CorpId.ToLower().Trim() == "mzl")
            {
                loginModel.IsCheckClientId = false;
            }
            */
            string clientId = request.ClientId;
            ITokenDomainFactory tokenFactory = new TokenDomainFactory();
            var tokenDomain = tokenFactory.CreateDomainObj();

            domain.TokenEvent += tokenDomain.UpdateUserToken;
            CustomerInfoModel customer= domain.DoLogin(loginModel);
            domain.TokenEvent -= tokenDomain.UpdateUserToken;

            ResponseBaseViewModel< LoginResponseViewModel > v =new ResponseBaseViewModel<LoginResponseViewModel> ();
            if (customer == null)
                v.Flag = new ResponseCodeViewModel() { Code = -1, Message = "用户名或密码失败" };
            else if (clientId != loginModel.ClientId && !string.IsNullOrWhiteSpace(clientId))
            {
                v.Flag = new ResponseCodeViewModel() { Code = -2, Message = "设备ID与原ID不同" };
            }
            else
            {
                v.Flag = new ResponseCodeViewModel() { Code = 0, Message = "success", MojoryToken = token };
                v.Data = new LoginResponseViewModel();
            }

            return v;
        }

        /// <summary>
        /// 自动登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<string> AutoLogin(ClientInfoRequestViewModel request)
        {
            var cid = this.GetCid();
            if (cid == 0) {
                return new ResponseBaseViewModel<string>
                {
                    Flag = new ResponseCodeViewModel() { Code = -1, Message = "success", MojoryToken = "" }
                };
            }
            var clientId = request.ClientId;
            ICustomerDomainFactory factory = new CustomerDomainFactory();
            var domain = factory.CreateVerifyCustomerDomainObj();
            if (domain.AutoLogin(cid, request.ClientId))
            {
                return new ResponseBaseViewModel<string>
                {
                    Flag = new ResponseCodeViewModel() { Code = 0, Message = "success", MojoryToken = "" }
                };
            }
            else {
                return new ResponseBaseViewModel<string>
                {
                    Flag = new ResponseCodeViewModel() { Code = -1, Message = "设备ID错误", MojoryToken = "" }
                };
            }
        }

        /// <summary>
        /// 差旅网站登录注销
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<string> MojoryLoginOut()
        {
            string token = this.GetToken();
            IUnityContainer unityContainer = new IocHelper("MojoryLoginOutApi").GetUnityContainer();
            ICustomerLoginOutApplication customerLoginOutApplication = unityContainer.Resolve<ICustomerLoginOutApplication>();
            customerLoginOutApplication.MojoryLoginOut(token);
            ResponseBaseViewModel<string> v = new ResponseBaseViewModel<string>
            {
                Flag = new ResponseCodeViewModel() {Code = 0, Message = "success", MojoryToken = ""}
            };
            return v;
        }
        /// <summary>
        /// 获取客户信息
        /// </summary>
        /// <returns></returns>
        [Obsolete("该api已过时，请用GetCustomerInfo/GetCustomerInfo的api代替")]
        [HttpPost]
        public ResponseBaseViewModel<CustomerInfoViewModel> GetCustomerInfo()
        {
            int cid = this.GetCid();
            ICustomerDomainFactory customerFactory = new CustomerDomainFactory();
            var customerDomain = customerFactory.CreateDomainObj();
            CustomerInfoModel customerInfoModel = customerDomain.GetCustomerInfo(cid);
            if(customerInfoModel.IsLock=="T")
                throw new Exception("当前客户已经被冻结");
            if (customerInfoModel.IsDel == "T")
                throw new Exception("当前客户已经被删除");

            CustomerInfoViewModel viewModel =
                Mapper.Map<CustomerInfoModel, CustomerInfoViewModel>(customerInfoModel);

            if (!string.IsNullOrEmpty(customerInfoModel.CorpId))
            {
                ICorporationDomainFactory corporationDomainFactory = new CorporationDomainFactory();
                var corpDomain = corporationDomainFactory.CreateDomainObj();
                CorporationModel corporationModel = corpDomain.GetCorporationByCorId(customerInfoModel.CorpId);
                if (corporationModel.IsAmplitudeCorp == "T")
                {
                    viewModel.IsCorpSystemCustomer = "T";
                }
                else
                {
                    viewModel.IsCorpSystemCustomer = "F";
                }
                viewModel.CorpName = corporationModel.CorpName;
            }
            else
            {
                viewModel.IsCorpSystemCustomer = "F";
            }

            ResponseBaseViewModel<CustomerInfoViewModel> v = new ResponseBaseViewModel<CustomerInfoViewModel>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = viewModel
            };
            return v;
        }
        /// <summary>
        /// 搜索联系人信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<List<PassengerViewModel>> SearchContactInfo([FromBody]TraOrderRequestViewModel request)
        {
            int cid = this.GetCid();
            ICustomerDomainFactory factory = new CustomerDomainFactory();
            var domain = factory.CreatePassengerInfoDomainObj();
            List<PassengerViewModel> passengerViewModels = new List<PassengerViewModel>();
            List<PassengerInfoModel> passengerList = domain.GetPassengerInfoList(cid, request.DepartId,
                request.SearchArgs);
            foreach (var p in passengerList)
            {
                PassengerViewModel passengerViewModel = new PassengerViewModel();
                passengerViewModel.ContactId = p.ContactId;
                passengerViewModel.PassengerName = p.PassengerName;
                passengerViewModel.Mobile = p.Mobile;
                passengerViewModel.Phone = p.Phone;
                passengerViewModel.Email = p.Email;
                passengerViewModel.Fax = p.Fax;
                passengerViewModel.IdentificationList = (List<IdentificationViewModel>)
                    AutoMapperHelper.DoMapList<IdentificationModel, IdentificationViewModel>(p.IdentificationList);
                passengerViewModels.Add(passengerViewModel);
            }

            ResponseBaseViewModel<List<PassengerViewModel>> v = new ResponseBaseViewModel<List<PassengerViewModel>>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = passengerViewModels
            };
            return v;
        }
    }
}
