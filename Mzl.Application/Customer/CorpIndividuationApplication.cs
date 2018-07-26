using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.IBLL.Customer.Corp;
using Mzl.IApplication.Customer;
using Mzl.DomainModel.Customer.Corp;
using Mzl.UIModel.Customer.Corporation;

namespace Mzl.Application.Customer
{
   public class CorpIndividuationApplication: ICorpIndividuationApplication
    {
        private readonly IGetCorpServiceBll _getCorpServiceBll;
        public CorpIndividuationApplication(IGetCorpServiceBll getCorpServiceBll)
        {
            _getCorpServiceBll = getCorpServiceBll;
        }
        public int UpdateCorpIndividuation(GetCorpIndividuationRequestViewModel request)
        {
            CorporationModel corModel = new CorporationModel();

            corModel.CorpId = request.CorpId;
            corModel.IsNoteVerify = request.IsNoteVerify;
            corModel.IsAllowUserInsurance = Convert.ToInt32(request.IsAllowUserInsurance);
            corModel.IsShareFly = request.IsShareFly;
            corModel.IsXYPrice = request.IsXYPrice;
            corModel.IsAllSeat = request.IsAllSeat;
            corModel.IsTravelReason = request.IsTravelReason;
            corModel.IsHeightSeat = request.IsHeightSeat;
            corModel.IsTraAllSeat = request.IsTraAllSeat;

            return _getCorpServiceBll.UpdateCorpIndividuation(corModel);
        }
    }
}
