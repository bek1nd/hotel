using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Customer.Corp;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.Framework.Base;
using Mzl.IBLL.Customer.Corp;
using Mzl.IDAL.Customer.Corporation;

namespace Mzl.BLL.Customer.Corp
{
    public class GetCorpServiceBll : BaseServiceBll, IGetCorpServiceBll
    {
        private readonly ICorporationDal _corporationDal;

        public GetCorpServiceBll(ICorporationDal corporationDal)
        {
            _corporationDal = corporationDal;
        }

        public CorporationModel GetCorp(string corpId)
        {
            if (string.IsNullOrEmpty(corpId))
                return null;
            CorporationEntity corporationEntity =
                  _corporationDal.Query<CorporationEntity>(n => n.CorpId.ToLower() == corpId.ToLower()).FirstOrDefault();
            CorporationModel corporationModel =
                Mapper.Map<CorporationEntity, CorporationModel>(corporationEntity);
            return corporationModel;
        }
        /// <summary>
        /// 修改公司表信息
        /// </summary>
        /// <param name="par"></param>
        /// <param name="properties"></param>
        /// <returns></returns>
        public int UpdateCorpIndividuation(CorporationModel par)
        {
            if (par==null)
            return -1;

            CorporationEntity corporationEntity =
              Mapper.Map<CorporationModel, CorporationEntity>(par);

            List<string> argList = new List<string>();

            if (corporationEntity.IsNoteVerify.HasValue)
                argList.Add("IsNoteVerify");

            if (corporationEntity.IsAllowUserInsurance.HasValue)
                argList.Add("IsAllowUserInsurance");

            if (corporationEntity.IsShareFly.HasValue)
                argList.Add("IsShareFly");

            if (corporationEntity.IsXYPrice.HasValue)
                argList.Add("IsXYPrice");

            if (corporationEntity.IsAllSeat.HasValue)
                argList.Add("IsAllSeat");

            if (corporationEntity.IsTravelReason.HasValue)
                argList.Add("IsTravelReason");

            if (corporationEntity.IsHeightSeat.HasValue)
                argList.Add("IsHeightSeat");
            if(corporationEntity.IsTraAllSeat.HasValue)
            {
                argList.Add("IsTraAllSeat");
            }

            _corporationDal.Update(corporationEntity, argList.ToArray());
            return 0;

        }
    }
}
