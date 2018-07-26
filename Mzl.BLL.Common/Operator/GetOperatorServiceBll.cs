using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Common.Operator;
using Mzl.EntityModel.Operator;
using Mzl.Framework.Base;
using Mzl.IBLL.Common.Operator;
using Mzl.IDAL.Common;

namespace Mzl.BLL.Common.Operator
{
    internal class GetOperatorServiceBll : BaseServiceBll, IGetOperatorServiceBll
    {
        private readonly IOperatorDal _operatorDal;

        public GetOperatorServiceBll(IOperatorDal operatorDal)
        {
            _operatorDal = operatorDal;
        }

        public OperatorModel GetOperatorByOid(string oid)
        {
            if (string.IsNullOrEmpty(oid))
                return null;
            OperatorEntity operatorEntity =
                _operatorDal.Query<OperatorEntity>(n => n.Oid.ToUpper() == oid.ToUpper()).FirstOrDefault();

            if (operatorEntity == null)
                return null;

            return Mapper.Map<OperatorEntity, OperatorModel>(operatorEntity);
        }
    }
}
