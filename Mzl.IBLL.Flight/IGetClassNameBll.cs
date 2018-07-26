using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;
using Mzl.DomainModel.Flight;

namespace Mzl.IBLL.Flight
{
    public interface IGetClassNameBll
    {
        /// <summary>
        /// 获取所有航司舱位信息
        /// </summary>
        /// <returns></returns>
        List<FltClassNameModel> GetFlightClassName();
    }
}
