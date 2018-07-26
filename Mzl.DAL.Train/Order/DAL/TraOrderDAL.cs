using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.EntityModel.Train.Order;
using System.Linq.Expressions;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.EFContext;
using System.Data.SqlClient;
using Mzl.Framework.Base;
using Mzl.EntityModel.Flight;
using Mzl.EntityModel.Train.Server;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraOrderDAL : BaseDal, ITraOrderDAL, ITraOrderListDAL
    {
        public int Delete(TraOrderEntity t)
        {
            throw new NotImplementedException();
        }
        public List<TraOrderListDataEntity> GetTraOrderByPageListNew(TraOrderListQueryEntity query, ref int totalCount)
        {
            string where = "where OrderType = @OrderType";
            List<SqlParameter> paraList = new List<SqlParameter>();
            paraList.Add(new SqlParameter("@OrderType", query.OrderType));
            if (query.AllowShowDataBeginTime.HasValue)
            {
                where += " and CreateTime > @AllowShowDataBeginTime";
                paraList.Add(new SqlParameter("@AllowShowDataBeginTime", query.AllowShowDataBeginTime.Value));
            }
            if (query.OrderType == 2)
            {
                where += " and isnull(RefundType,0) <>1";
            }
            else if (query.OrderType == 0)
            {
                where += " and isnull(IsOnlineShow,0) <> 1";
            }

            var nowDate = Convert.ToDateTime(DateTime.Now.AddMinutes(-20).ToString("yyy-MM-dd HH:mm:ss"));
            var status = Context.Set<TraInterFaceOrderEntity>().Where(n => n.Status == 2 && n.CreateTime < nowDate).Select(n => n.InterfaceId);
            if (status.Any())
            {
                where += " and InterfaceOrderId not in (select InterfaceId from Tra_InterFaceOrder WHERE Status = 2 AND CreateTime < @nowdate)";
                paraList.Add(new SqlParameter("@nowdate", nowDate));
            }

            if (query.OrderStatus.HasValue)
            {
                if (query.OrderStatus == 4)
                {
                    where += " and ProcessStatus&1=1";
                }
                else if (query.OrderStatus == 9)
                {
                    where += " and ProcessStatus&1=1";
                }
                else if (query.OrderStatus == -1)
                {
                    where += " and ProcessStatus&1<>1 and InterfaceOrderStatus=-1";
                }
                else if (query.OrderStatus == 98)
                {
                    where += " and IsCancle = 1";
                }
                else if (query.OrderStatus == 99)
                {
                    where += " and ProcessStatus&1<>1 and IsCancle=0 and AduitOrderStatus is not null and AduitOrderStatus <> 7 and AduitOrderStatus <>8";
                }
                else
                {
                    where += " and InterfaceOrderStatus = @OrderStatus";
                    paraList.Add(new SqlParameter("@OrderStatus",query.OrderStatus.Value));
                }
            }

            if (!string.IsNullOrEmpty(query.RefundOrderId))
            {
                where += " and OrderRoot in (@RefundOrderId)";
                paraList.Add(new SqlParameter("RefundOrderId", query.RefundOrderId));
            }

            if (query.OrderId.HasValue)//订单号
            {
                where += " and ((CopyType='X' and CopyFromOrderId is not null and ProcessStatus&1=1 and IsCancle<>1 and CopyFromOrderId = @OrderId) or (CopyType<>'X' and CopyFromOrderId is null and ProcessStatus&1<>1 and IsCancle=1 and OrderId = @OrderId))";
                paraList.Add(new SqlParameter("@OrderId", query.OrderId));
            }
            if (query.OrderBeginTime.HasValue)//订单开始时间
            {
                where += " and CreateTime >= @OrderBeginTime";
                paraList.Add(new SqlParameter("@OrderBeginTime", query.OrderBeginTime.Value));
            }
            if (query.OrderEndTime.HasValue)//订单结束时间
            {
                where += " and CreateTime < @OrderEndTime";
                DateTime dd = query.OrderEndTime.Value.AddDays(1);
                paraList.Add(new SqlParameter("@OrderEndTime", dd));
            }
            else
            {
                where += " and CreateTime < @OrderEndTime";
                DateTime dd = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                paraList.Add(new SqlParameter("@OrderEndTime", dd));
            }

            if (query.TravelBeginTime.HasValue)//行程开始时间
            {
                where += " and OrderId in (select tod.OrderId from Tra_Order_Detail as tod where tod.Send_Time >= @TravelBeginTime)";
                paraList.Add(new SqlParameter("@TravelBeginTime", query.TravelBeginTime.Value));
            }
            if (query.TravelEndTime.HasValue)//行程结束时间
            {
                where += " and OrderId in (select tod.OrderId from Tra_Order_Detail as tod where tod.Send_Time < @TravelEndTime)";
                DateTime dd = query.TravelEndTime.Value.AddDays(1);
                paraList.Add(new SqlParameter("@TravelEndTime", dd));
            }

            if (!string.IsNullOrEmpty(query.PassengerName))//乘机人
            {
                where += " and OrderId in (select Order_Id from Tra_Order_Detail where Od_Id in (select Od_Id from Tra_Passenger where P_Name like '%" + query.PassengerName + "%'))";
            }


            if (!string.IsNullOrEmpty(query.CostCenter))//成本中心
            {
                where += " and CostCenter like '%" + query.CostCenter + "%'";
            }

            if (query.ProjectId.HasValue)//项目名称
            {
                where += " and isnull(ProjectId,0) = @ProjectId";
                paraList.Add(new SqlParameter("@ProjectId", query.ProjectId));
            }
            //判断是否显示全部订单
            if ((query.IsShowAllOrder??0) == 1)
            {
                //判断用户是否有显示公司订单的权限
                CustomerInfoEntity customer = Context.Set<CustomerInfoEntity>().Where(n => n.Cid == query.Cid).FirstOrDefault();
                if(customer!=null)
                {
                    if((customer.IsShowAllOrder??0)==1)
                    {
                        if (!string.IsNullOrEmpty(query.CorpId))
                        {
                            where += " and Corpid is not null and Corpid = @CorpId";
                            paraList.Add(new SqlParameter("@CorpId", query.CorpId));
                        }
                        else
                        {
                            where += " and 1=0";
                        }
                    }
                    else
                    {
                        if (query.Cid.HasValue && !string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() != "administrator")
                        {
                            where += " and Cid = @Cid";
                            paraList.Add(new SqlParameter("@Cid", query.Cid.Value));
                        }
                        else
                        {
                            where += " and 1=0";
                        }
                    }
                }
                else
                {
                    where += " and 1=0";
                }

            }
            else
            {
                if (query.Cid.HasValue && !string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() != "administrator")
                {
                    where += " and Cid = @Cid";
                    paraList.Add(new SqlParameter("@Cid", query.Cid.Value));
                }
                if (!string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() == "administrator" && !string.IsNullOrEmpty(query.CorpId))
                {
                    if (!string.IsNullOrEmpty(query.CorpId))
                    {
                        where += " and Corpid is not null and Corpid = @CorpId";
                        paraList.Add(new SqlParameter("@CorpId", query.CorpId));
                    }
                    else
                    {
                        where += " and 1=0";
                    }
                }
            }
            string sql = "select top " + query.PageSize + " * from view_AppTraOrderNew " + where + " and OrderId not in (select top " + (query.PageIndex - 1) * query.PageSize + " OrderId from view_AppTraOrderNew " + where + " order by OrderId desc) order by OrderId desc";
            //如果是导出操作 返回全部订单
            if((query.IsExport??0)==1)
            {
                sql = "select * from view_AppTraOrderNew " + where + " order by OrderId desc";
            }
            List<TraOrderListDataEntity> tlist = base.ExcuteQueryBySql<TraOrderListDataEntity>(sql, paraList.Select(x => ((ICloneable)x).Clone() as SqlParameter).ToArray()).ToList();
            string sqlcount = "select count(0) from view_AppTraOrderNew " + where;
            totalCount = base.ExcuteScalar(sqlcount, paraList.Select(x => ((ICloneable)x).Clone() as SqlParameter).ToArray());
            return tlist;
        }
        public List<TraOrderListDataEntity> GetTraOrderByPageList(TraOrderListQueryEntity query, ref int totalCount)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var select = from order in db.TraOrder
                             join orderStatus in db.TraOrderStatus on order.OrderId equals orderStatus.OrderId into os
                             from orderStatus in os.DefaultIfEmpty()

                             join customer in db.CustomerInfo on order.Cid equals customer.Cid into c
                             from customer in c.DefaultIfEmpty()

                             join traInterFaceOrder in db.InterFaceOrder on order.OrderId.ToString() equals
                                 traInterFaceOrder.OrderId into tf
                             from traInterFaceOrder in tf.DefaultIfEmpty()

                             join aduitOrderDetail in db.CorpAduitOrderDetail on order.OrderId equals aduitOrderDetail.OrderId
                                 into aod
                             from aduitOrderDetail in aod.DefaultIfEmpty()

                             join aduitOrder in db.CorpAduitOrder on aduitOrderDetail.AduitOrderId equals aduitOrder.AduitOrderId
                                 into ao
                             from aduitOrder in ao.DefaultIfEmpty()
                             select new TraOrderListDataEntity()
                             {
                                 OrderId = order.OrderId,
                                 CostCenter = order.CostCenter,
                                 ProjectId = order.ProjectId,
                                 CreateTime = order.CreateTime,
                                 TotalMoney = order.TotalMoney,
                                 Corpid = customer.CorpID,
                                 Cid = customer.Cid,
                                 IsCancle = orderStatus.IsCancle,
                                 InterfaceOrderStatus = (traInterFaceOrder == null ? -1 : traInterFaceOrder.Status),
                                 InterfaceOrderId = (traInterFaceOrder == null ? -1 : traInterFaceOrder.InterfaceId),
                                 OrderType = order.OrderType,
                                 NumberIdentity = order.NumberIdentity,
                                 OrderRoot = order.OrderRoot ?? 0,
                                 ProcessStatus = orderStatus.ProccessStatus,
                                 AduitOrderId = aduitOrderDetail.AduitOrderId,
                                 AduitOrderStatus = aduitOrder.Status,
                                 IsOnlineShow = order.IsOnlineShow,
                                 RefundType = order.RefundType,
                                 CopyFromOrderId = order.CopyFromOrderId,
                                 CopyType = order.CopyType
                             };

                select = select.Where(n => n.OrderType == query.OrderType);
                if (query.AllowShowDataBeginTime.HasValue)
                {
                    select = select.Where(n => n.CreateTime > query.AllowShowDataBeginTime.Value);
                }
                if (query.OrderType == 2)
                {
                    select = select.Where(n => n.RefundType != 1);
                }
                else if (query.OrderType == 0)
                {
                    select = select.Where(n => n.IsOnlineShow != 1);
                }
                var nowDate = Convert.ToDateTime(DateTime.Now.AddMinutes(-20).ToString("yyy-MM-dd HH:mm:ss"));
                var status =
                    db.InterFaceOrder.Where(n => n.Status == 2 && n.CreateTime < nowDate).Select(n => n.InterfaceId);
                if (status.Any())
                {
                    select = select.Where(n => !status.Contains(n.InterfaceOrderId));
                }

                if (query.OrderStatus.HasValue)
                {
                    if (query.OrderStatus == 4)
                    {
                        select = select.Where(n => (n.ProcessStatus & 1) == 1);
                    }
                    else if (query.OrderStatus == 9)
                    {
                        select = select.Where(n => (n.ProcessStatus & 1) == 1);
                    }
                    else if (query.OrderStatus == -1)
                    {
                        select = select.Where(n => (n.ProcessStatus & 1) != 1 && n.InterfaceOrderStatus == -1);
                    }
                    else if (query.OrderStatus == 98)
                    {
                        select = select.Where(n => n.IsCancle == 1);
                    }
                    else if (query.OrderStatus == 99)
                    {
                        select = select.Where(n => ((n.ProcessStatus & 1) != 1) && n.IsCancle == 0 && n.AduitOrderStatus.HasValue && n.AduitOrderStatus != 7 && n.AduitOrderStatus != 8);
                    }
                    else
                    {
                        select = select.Where(n => n.InterfaceOrderStatus == query.OrderStatus.Value);
                    }
                }

                if (!string.IsNullOrEmpty(query.RefundOrderId))
                {
                    select = select.Where(n => query.RefundOrderId.Contains(n.OrderRoot.ToString()));
                }

                if (query.OrderId.HasValue)//订单号
                {
                    select = select.Where(n =>
                        ((n.CopyType == "X" && n.CopyFromOrderId.HasValue &&
                          (n.ProcessStatus & 1) == 1 &&
                          n.IsCancle != 1)
                            ? n.CopyFromOrderId.Value
                            : n.OrderId)
                        == query.OrderId.Value);
                }
                if (query.OrderBeginTime.HasValue)//订单开始时间
                {
                    select = select.Where(n => n.CreateTime >= query.OrderBeginTime.Value);
                }
                if (query.OrderEndTime.HasValue)//订单结束时间
                {
                    DateTime dd = query.OrderEndTime.Value.AddDays(1);
                    select = select.Where(n => n.CreateTime < dd);
                }
                else
                {
                    DateTime dd = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                    select = select.Where(n => n.CreateTime < dd);
                }

                if (query.TravelBeginTime.HasValue)//行程开始时间
                {
                    select = select.Where(n => db.TraOrderDetail.Where(m => m.StartTime >= query.TravelBeginTime.Value)
                        .Select(m => m.OrderId).Contains(n.OrderId));
                }
                if (query.TravelEndTime.HasValue)//行程结束时间
                {
                    DateTime dd = query.TravelEndTime.Value.AddDays(1);
                    select = select.Where(n => db.TraOrderDetail.Where(m => m.EndTime < dd)
                        .Select(m => m.OrderId).Contains(n.OrderId));
                }

                if (!string.IsNullOrEmpty(query.PassengerName))//乘机人
                {
                    var p = db.TraPassenger.Where(k => k.Name.Contains(query.PassengerName)).Select(k => k.OdId);
                    select =
                        select.Where(
                            n =>
                                db.TraOrderDetail.Where(m => p.Contains(m.OdId))
                                    .Select(m => m.OrderId)
                                    .Contains(n.OrderId));
                }


                if (!string.IsNullOrEmpty(query.CostCenter))//成本中心
                {
                    select = select.Where(n => n.CostCenter.Contains(query.CostCenter));
                }

                if (query.ProjectId.HasValue)//项目名称
                {
                    select = select.Where(n => n.ProjectId == query.ProjectId);
                }

                if (query.Cid.HasValue && !string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() != "administrator")
                {
                    select = select.Where(n => n.Cid == query.Cid.Value);
                }
                if (!string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() == "administrator" && !string.IsNullOrEmpty(query.CorpId))
                {
                    select =
                        select.Where(
                            n =>
                                !string.IsNullOrEmpty(query.CorpId) && !string.IsNullOrEmpty(n.Corpid) &&
                                n.Corpid == query.CorpId);
                }

                totalCount = select.Count();
                select = select.OrderByDescending(n => n.OrderId).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
                return select.ToList();
            }
        }

        public int Insert(TraOrderEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraOrder.Add(t);
                db.SaveChanges();
                return log.OrderId;
            }
        }

        public TraOrderEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraOrder.Where(n => n.OrderId == id).ToList();
                return result.First();
            }
        }

        public List<TraOrderEntity> GetTraOrderListExpression(Expression<Func<TraOrderEntity, bool>> predicate,
            bool isNeedCancle = false)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = from order in db.TraOrder
                             join status in db.TraOrderStatus on order.OrderId equals status.OrderId
                             where !isNeedCancle && status.IsCancle == 0
                             select order;
                result = result.Where(predicate);
                var select = result.ToList();
                if (select.Count == 0)
                    return null;
                return select;
            }
        }

        public int Update(TraOrderEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public TraOrderEntity GetTraRetOrderByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var select = from order in db.TraOrder
                             join status in db.TraOrderStatus on order.OrderId equals status.OrderId
                             where status.IsCancle == 0 && order.OrderRoot == orderRoot && order.OrderType == orderType
                             select order;

                var p = db.TraPassenger.Where(k => (ticketNoList.Contains(k.TicketNo) || ticketNoList.Contains(k.ModTicketNo))).Select(k => k.OdId);
                select =
                    select.Where(
                        n =>
                            db.TraOrderDetail.Where(m => p.Contains(m.OdId))
                                .Select(m => m.OrderId)
                                .Contains(n.OrderId));
                var list = select.ToList();
                if (list.Count == 0)
                    return null;
                return list.First();
            }
        }

        public List<TraOrderEntity> GetTraRetOrderListByOrderRootAndTicketNo(int orderRoot, List<string> ticketNoList, int orderType = 2)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var select = from order in db.TraOrder
                             join status in db.TraOrderStatus on order.OrderId equals status.OrderId
                             where status.IsCancle == 0 && order.OrderRoot == orderRoot && order.OrderType == orderType
                             select order;

                var p = db.TraPassenger.Where(k => (ticketNoList.Contains(k.TicketNo) || ticketNoList.Contains(k.ModTicketNo))).Select(k => k.OdId);
                select =
                    select.Where(
                        n =>
                            db.TraOrderDetail.Where(m => p.Contains(m.OdId))
                                .Select(m => m.OrderId)
                                .Contains(n.OrderId));
                var list = select.ToList();
                if (list.Count == 0)
                    return null;
                return list;
            }
        }
    }
}
