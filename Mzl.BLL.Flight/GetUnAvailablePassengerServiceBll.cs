using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Flight;
using Mzl.EntityModel.Customer.BaseInfo;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Operator;
using Mzl.Framework.Base;
using Mzl.IBLL.Flight;
using Mzl.IDAL.Flight;
using AutoMapper;

namespace Mzl.BLL.Flight
{
    internal class GetUnAvailablePassengerServiceBll : BaseServiceBll, IGetUnAvailablePassengerServiceBll
    {
        private readonly IFltPassengerDal _fltPassengerDal;
        private readonly IFltFlightDal _fltFlightDal;

        public GetUnAvailablePassengerServiceBll(IFltPassengerDal fltPassengerDal, IFltFlightDal fltFlightDal)
        {
            _fltPassengerDal = fltPassengerDal;
            _fltFlightDal = fltFlightDal;
        }

        public GetUnAvailablePassengerModel GetUnAvailablePassengerList(GetUnAvailablePassengerQueryModel query)
        {
            GetUnAvailablePassengerModel resultModel = new GetUnAvailablePassengerModel();

            List<int> orderIdList = new List<int>();
            List<string> orderstatusList = new List<string>() { "N","C","W" };
            var select = from order in Context.Set<FltOrderEntity>().AsNoTracking()
                join customer in Context.Set<CustomerInfoEntity>().AsNoTracking() on order.Cid equals customer.Cid
                join operatorInfo in Context.Set<OperatorEntity>().AsNoTracking() on order.CreateOid equals
                    operatorInfo.Oid
                where !orderstatusList.Contains(order.Orderstatus) && (order.ProcessStatus & 8) == 8
                select new GetUnAvailablePassengerDataModel()
                {
                    OrderId = order.OrderId,
                    CreateOName = operatorInfo.OName,
                    CreateOid = operatorInfo.Oid,
                    CustomerName = customer.RealName,
                    OrderDate = order.OrderDate,
                    Cid = order.Cid
                };

            #region 查询条件

            if (!string.IsNullOrEmpty(query.CreateOName))
            {
                select = select.Where(n => n.CreateOName.Contains(query.CreateOName));
            }
            else
            {
                select = select.Where(n => n.CreateOid == query.Oid);
            }

            if (query.OrderId.HasValue)
            {
                select = select.Where(n => n.OrderId == query.OrderId.Value);
            }

            if (!string.IsNullOrEmpty(query.CustomerName))
            {
                select = select.Where(n => n.CustomerName.Contains(query.CustomerName));
            }

            if (query.TackOffBeginTime.HasValue)
            {
                select = select.Where(n => Context.Set<FltFlightEntity>().Where(m => m.TackoffTime >= query.TackOffBeginTime.Value)
                      .Select(m => m.OrderId).Contains(n.OrderId));
            }

            if (query.TackOffEndTime.HasValue)
            {
                query.TackOffEndTime = query.TackOffEndTime.Value.AddDays(1);
                select = select.Where(n => Context.Set<FltFlightEntity>().Where(m => m.TackoffTime < query.TackOffEndTime.Value)
                      .Select(m => m.OrderId).Contains(n.OrderId));
            }

            if (!string.IsNullOrEmpty(query.PassengerName))
            {
                select = select.Where(
                    n =>
                        Context.Set<FltPassengerEntity>()
                            .Where(m => m.Name.Contains(query.PassengerName) && m.IsAvailable == "F")
                            .Select(m => m.OrderId).Contains(n.OrderId)
                    );
            }
            else
            {
                select = select.Where(
                    n =>
                        Context.Set<FltPassengerEntity>()
                            .Where(m => m.IsAvailable == "F")
                            .Select(m => m.OrderId).Contains(n.OrderId)
                    );

                DateTime beginTime = DateTime.Now.AddYears(-1);
                select =
                    select.Where(
                        n => Context.Set<FltFlightEntity>().Where(m => m.TackoffTime >= beginTime)
                            .Select(m => m.OrderId).Contains(n.OrderId));
            }

            if (query.OrderBeginTime.HasValue)
                select = select.Where(n => n.OrderDate >= query.OrderBeginTime.Value);
            if (query.OrderEndTime.HasValue)
            {
                query.OrderEndTime = query.OrderEndTime.Value.AddDays(1);
                select = select.Where(n => n.OrderDate < query.OrderEndTime.Value);
            }

            #endregion

            resultModel.TotalCount = select.Count();//查询所有结果的数量

            select =
            select.OrderByDescending(n => n.OrderId).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
            resultModel.DataList  = select.ToList();//分页结果 

            resultModel.DataList.ForEach(n => orderIdList.Add(n.OrderId));

            //1.根据订单号 获取航段信息
            List<FltFlightEntity> flightEntities =
                _fltFlightDal.Query<FltFlightEntity>(n => orderIdList.Contains(n.OrderId) && n.Sequence == 1, true)
                    .ToList();


            //2.根据订单号 获取乘机人信息
            List<FltPassengerEntity> passengerEntities = _fltPassengerDal.Query<FltPassengerEntity>(n => orderIdList.Contains(n.OrderId)&&n.IsAvailable=="F", true).ToList();
            List<FltPassengerModel> passengerModels =
                Mapper.Map<List<FltPassengerEntity>, List<FltPassengerModel>>(passengerEntities);

            for (int i = 0; i < resultModel.DataList.Count; i++)
            {
                resultModel.DataList[i].TackOffTime = flightEntities.Find(n => n.OrderId == resultModel.DataList[i].OrderId).TackoffTime;
                resultModel.DataList[i].PassengerNameList = passengerModels.FindAll(n => n.OrderId == resultModel.DataList[i].OrderId);
            }

            return resultModel;
        }
    }
}
