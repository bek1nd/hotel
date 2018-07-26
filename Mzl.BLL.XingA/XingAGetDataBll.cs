using AutoMapper;
using Mzl.DomainModel.XingA;
using Mzl.EntityModel.XingA;
using Mzl.Framework.Base;
using Mzl.IBLL.XingA;
using System.Data.Entity;
using Mzl.IDAL.XingA;

namespace Mzl.BLL.XingA
{
    public class XingAGetDataBll: BaseServiceBll, IXingAGetDataBll
    {
        private readonly IXingAGetDataDal _xingAGetDataDal;
        public XingAGetDataBll(IXingAGetDataDal addData):base()
        {
            _xingAGetDataDal = addData;
        }

        public int AddData(XingAModel AddXingAModel)
        {
            //1.AutoMapper 将Model自动映射到Entity
            XingAEntity  entity= Mapper.Map<XingAModel, XingAEntity>(AddXingAModel);
            entity = _xingAGetDataDal.Insert<XingAEntity>(entity);
            return entity.ID;
        }
    }
}
