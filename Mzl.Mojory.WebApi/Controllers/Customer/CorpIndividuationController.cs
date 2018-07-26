using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Mzl.IApplication.Customer;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Customer.CorpPolicy;
using Mzl.UIModel.Customer.Customer;
using Mzl.UIModel.Customer.Corporation;
using Mzl.DomainModel.Customer.Corp;

namespace Mzl.Mojory.WebApi.Controllers.Customer
{
    /// <summary>
    /// 公司订制信息设置
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public class CorpIndividuationController : ApiController
    {
        public readonly ICorpIndividuationApplication _CorApplication;

        public CorpIndividuationController(ICorpIndividuationApplication CorApplication)
        {
            _CorApplication = CorApplication;
        }
        /// <summary>
        /// 公司订制信息修改
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ResponseBaseViewModel<int>> CorporationCustomMade([FromBody]GetCorpIndividuationRequestViewModel request)
        {
            request.Cid = this.GetCid();
            int val = 0;
            await new TaskFactory().StartNew(() =>
            {
                val = _CorApplication.UpdateCorpIndividuation(request);
            });
            ResponseBaseViewModel<int> v = new ResponseBaseViewModel<int>()
            {
                Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                Data = val
            };
            return v;

        }
    }
}