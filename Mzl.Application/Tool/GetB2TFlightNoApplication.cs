using Mzl.IApplication.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Tool;
using Mzl.IBLL.Tool;

namespace Mzl.Application.Tool
{
    internal class GetB2TFlightNoApplication : IGetB2TFlightNoApplication
    {
        private readonly IGetB2TFlightNoServiceBll _getB2TFlightNoServiceBll;

        public GetB2TFlightNoApplication(IGetB2TFlightNoServiceBll getB2TFlightNoServiceBll)
        {
            _getB2TFlightNoServiceBll = getB2TFlightNoServiceBll;
        }

        public List<string> GetB2TFlightNo(string dport, string aport)
        {
            return _getB2TFlightNoServiceBll.GetB2TFlightNo(new B2TFlightNoQueryModel() {Dport = dport, Aport = aport});
        }
    }
}
