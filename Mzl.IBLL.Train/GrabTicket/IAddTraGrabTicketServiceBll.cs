using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Events;
using Mzl.DomainModel.Train.GrabTicket;
using Mzl.Framework.Base;

namespace Mzl.IBLL.Train.GrabTicket
{
    public interface IAddTraGrabTicketServiceBll : IBaseServiceBll
    {
        /// <summary>
        /// 添加抢票信息
        /// </summary>
        /// <param name="addTraGrabTicketModel"></param>
        /// <returns></returns>
        int AddTraGrabTicket(AddTraGrabTicketModel addTraGrabTicketModel);



        event EventHandler<CommonEventArgs<List<ContactInfoModel>>> AddContactEvent;
    }
}
