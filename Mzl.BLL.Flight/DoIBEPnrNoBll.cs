using Mzl.IBLL.Flight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.BLL.Flight.IBEService;

namespace Mzl.BLL.Flight
{
    /// <summary>
    /// 使用IBE结果定位
    /// </summary>
    public class DoIBEPnrNoBll : BaseBll, IDoPnrNoBll
    {
        private readonly SearchFlightSoapClient _searchFlightSoap = new SearchFlightSoapClient();
        

        public string DoPnrNo(int orderid, string oid)
        {
            string pnrResult = _searchFlightSoap.DoIBEPnrSeatByCorp(orderid, oid);
            string pnrNo = string.Empty;
            if (!string.IsNullOrEmpty(pnrResult) && pnrResult!= "HavePnrNo")
            {
                pnrNo = pnrResult;
            }
            return pnrNo;
        }
    }
}
