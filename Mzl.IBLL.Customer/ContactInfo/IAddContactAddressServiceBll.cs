using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Customer.ContactInfo
{
    public interface IAddContactAddressServiceBll : IBaseServiceBll
    {
        bool AddAddress(string address, int cid, string oid);
    }
}
