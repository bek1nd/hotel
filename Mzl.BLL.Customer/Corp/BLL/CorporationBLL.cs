using AutoMapper;
using Mzl.Common.AutoMapperHelper;
using Mzl.DomainModel.Customer.Corp;
using Mzl.EntityModel.Customer.Corporation.Corp;
using Mzl.IBLL.Customer.Corp;
using Mzl.IBLL.Customer.Corp.BLL;
using Mzl.IDAL.Customer.DAL;

namespace Mzl.BLL.Customer.Corp.BLL
{
    public class CorporationBLL: ICorporationBLL<CorporationModel>
    {
        private readonly ICorporationDAL _dal;

        public CorporationBLL(ICorporationDAL dal)
        {
            _dal = dal;
        }

        public CorporationModel GetCorpInfoByCorpId(string corpId)
        {
            CorporationEntity corporationEntity =
                _dal.GetContactInfoByExpression(n => n.CorpId.ToUpper() == corpId.ToUpper());
            return Mapper.Map<CorporationEntity, CorporationModel>(corporationEntity);
        }
    }
}
