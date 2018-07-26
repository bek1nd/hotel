using Mzl.DomainModel.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.IBLL.Tool
{
    public interface IGetB2TFlightNoServiceBll
    {
        List<string> GetB2TFlightNo(B2TFlightNoQueryModel query);
    }
}
