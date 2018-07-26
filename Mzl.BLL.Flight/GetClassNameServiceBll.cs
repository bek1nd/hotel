using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;
using AutoMapper;
using Mzl.Common.CacheHelper;

namespace Mzl.BLL.Flight
{
    internal class GetClassNameServiceBll : BaseServiceBll, IGetClassNameBll
    {
        private readonly IFltClassNameDal _fltClassNameDal;

        public GetClassNameServiceBll(IFltClassNameDal fltClassNameDal) : base()
        {
            _fltClassNameDal = fltClassNameDal;
        }


        public List<FltClassNameModel> GetFlightClassName()
        {
            return CacheManager.Get(CacheKeyEnum.FltClassName.ToString(), Get, 60*24*7);
        }

        private List<FltClassNameModel> Get()
        {
            List<FltClassNameEntity> fltClassNameEntities =
                _fltClassNameDal.Query<FltClassNameEntity>(n => !string.IsNullOrEmpty(n.Class),true).ToList();

            return Mapper.Map<List<FltClassNameEntity>, List<FltClassNameModel>>(fltClassNameEntities);
        }
    }
}
