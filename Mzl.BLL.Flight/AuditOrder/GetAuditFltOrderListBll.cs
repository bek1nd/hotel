using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Mzl.DomainModel.Common.AuditOrder;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Flight;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight.AuditOrder;
using Mzl.IDAL.Flight;
using Mzl.Common.EnumHelper;

namespace Mzl.BLL.Flight.AuditOrder
{
    internal class GetAuditFltOrderListBll : BaseBll, IGetAuditFltOrderListBll
    {
        private readonly IFltFlightDal _fltFlightDal;
        private readonly IFltPassengerDal _fltPassengerDal;

        public GetAuditFltOrderListBll(IFltFlightDal fltFlightDal, IFltPassengerDal fltPassengerDal)
            : base()
        {
            _fltFlightDal = fltFlightDal;
            _fltPassengerDal = fltPassengerDal;
        }


        public List<AuditOrderListDataModel> GetAuditFltOrderList(AuditFltOrderListQueryModel query)
        {
            return null;
        }

        public List<AuditOrderListDataModel> GetAlreadyAuditFltOrderList(AuditFltOrderListQueryModel query)
        {
            return null;
        }

        #region 私有方法

        /// <summary>
        /// 转换列表信息
        /// </summary>
        /// <param name="list"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        private List<AuditOrderListDataModel> ConvertList(List<AuditOrderListDataModel> list, AuditFltOrderListQueryModel query)
        {
            return null;
        } 
        #endregion
    }
}