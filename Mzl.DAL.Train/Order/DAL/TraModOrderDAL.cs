using Mzl.IDAL.Train.Order.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.DBHelper;
using Mzl.EntityModel.Train.Order;
using Mzl.EntityModel.EFContext;
using Mzl.EntityModel.Customer.BaseInfo;

namespace Mzl.DAL.Train.Order.DAL
{
    public class TraModOrderDAL : ITraModOrderDAL
    {
        public int Insert(TraModOrderEntity t)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var log = db.TraModOrder.Add(t);
                db.SaveChanges();
                return log.CorderId;
            }
        }

        public int Update(TraModOrderEntity t, string[] properties = null)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                return db.Update(t, properties);
            }
        }

        public int Delete(TraModOrderEntity t)
        {
            throw new NotImplementedException();
        }

        public TraModOrderEntity Query(int id)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraModOrder.Where(n => n.CorderId == id).ToList();
                return result.First();
            }
        }

        public List<TraModOrderEntity> GetTraOrderListExpression(Expression<Func<TraModOrderEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraModOrder.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result;
            }
        }

        public TraModOrderEntity GetTraOrderExpression(Expression<Func<TraModOrderEntity, bool>> predicate)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var result = db.TraModOrder.Where(predicate).ToList();
                if (result.Count == 0)
                    return null;
                return result.First();
            }
        }

        public List<TraModOrderListDataEntity> GetTraModOrderByPageList(TraModOrderListQueryEntity query, ref int totalCount)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var select = from modOrder in db.TraModOrder
                    join customer in db.CustomerInfo on modOrder.Cid equals customer.Cid.ToString() into c
                    from customer in c.DefaultIfEmpty()
                    join traInterFaceOrder in db.InterFaceOrder on modOrder.CorderId.ToString() equals
                        traInterFaceOrder.OrderId into tf
                    from traInterFaceOrder in tf.DefaultIfEmpty()
                   
                    select new TraModOrderListDataEntity()
                    {
                        Coid = modOrder.Coid,
                        CreateTime = modOrder.CreateTime.Value,
                        Corpid = customer.CorpID,
                        Cid = customer.Cid,
                        InterfaceOrderStatus = (traInterFaceOrder == null ? -1 : traInterFaceOrder.Status),
                        InterfaceOrderId = (traInterFaceOrder == null ? -1 : traInterFaceOrder.InterfaceId),
                        CalcPrice = modOrder.CalcPrice.Value,
                        CorderId = modOrder.CorderId,
                        OrderStatus= modOrder.OrderStatus
                    };
                select = select.Where(n => n.OrderStatus != "N");
                if (query.AllowShowDataBeginTime.HasValue)
                {
                    select = select.Where(n => n.CreateTime > query.AllowShowDataBeginTime.Value);
                }
                var nowDate = DateTime.Now.AddMinutes(-20);
                var status =
                    db.InterFaceOrder.Where(n => n.Status == 15 && n.CreateTime < nowDate).Select(n => n.InterfaceId);
                if (status.Any())
                {
                    select = select.Where(n => !status.Contains(n.InterfaceOrderId));
                }

                if (query.OrderStatus.HasValue)
                {
                    select = select.Where(n => n.InterfaceOrderStatus == query.OrderStatus.Value);
                }

                if (!string.IsNullOrEmpty(query.Coid))//订单号
                {
                    select = select.Where(n => n.Coid.Contains(query.Coid));
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
                if (query.TravelBeginTime.HasValue)//行程开始时间
                {
                    select =
                        select.Where(n => db.TraModDetail.Where(m => m.SendTime.Value >= query.TravelBeginTime.Value)
                            .Select(m => m.CorderId).Contains(n.CorderId));
                }
                if (query.TravelEndTime.HasValue)//行程结束时间
                {
                    DateTime dd = query.TravelEndTime.Value.AddDays(1);
                    select = select.Where(n => db.TraModDetail.Where(m => m.EndTime.Value < dd)
                        .Select(m => m.CorderId).Contains(n.CorderId));
                }

                if (!string.IsNullOrEmpty(query.PassengerName))//乘机人
                {
                    var p = db.TraPassenger.Where(k => k.Name.Contains(query.PassengerName)).Select(k => k.Pid.ToString());
                    select =
                        select.Where(
                            n =>
                                db.TraModDetail.Where(m => p.Contains(m.Pid))
                                    .Select(m => m.CorderId)
                                    .Contains(n.CorderId));
                }
                //判断是否显示全部订单
                if ((query.IsShowAllOrder ?? 0) == 1)
                {
                    //判断用户是否有显示全部订单权限
                    CustomerInfoEntity customer = db.CustomerInfo.Where(x => x.Cid == query.Cid).FirstOrDefault();
                    if (customer != null && (customer.IsShowAllOrder??0) == 1)
                    {
                        select = select.Where(n => n.Corpid.ToUpper() == query.CorpId.ToUpper());
                    }
                    else
                    {
                        if (query.Cid.HasValue && !string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() != "administrator")
                        {
                            select = select.Where(n => n.Cid == query.Cid.Value);
                        }
                        if (!string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() == "administrator" && !string.IsNullOrEmpty(query.CorpId))
                        {
                            select = select.Where(n => n.Corpid.ToUpper() == query.CorpId.ToUpper());
                        }
                    }
                }
                else
                {
                    if (query.Cid.HasValue && !string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() != "administrator")
                    {
                        select = select.Where(n => n.Cid == query.Cid.Value);
                    }
                    if (!string.IsNullOrEmpty(query.UserId) && query.UserId.ToLower() == "administrator" && !string.IsNullOrEmpty(query.CorpId))
                    {
                        select = select.Where(n => n.Corpid.ToUpper() == query.CorpId.ToUpper());
                    }
                }
                totalCount = select.Count();
                if((query.IsExport??0)==0)
                {
                    select = select.OrderByDescending(n => n.CorderId).Skip(query.PageSize * (query.PageIndex - 1)).Take(query.PageSize);
                }
                else
                {
                    select = select.OrderByDescending(n => n.CorderId);
                }
                return select.ToList();

            }
        }

        public TraModOrderEntity GetTraModOrderByOrderIdAndTicketNo(int orderId, List<string> ticketNoList)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var select = from modOrder in db.TraModOrder

                    where modOrder.OrderId == orderId && (modOrder.OrderStatus != "C")
                    select modOrder;

                var p = db.TraPassenger.Where(k => ticketNoList.Contains(k.TicketNo)).Select(k => k.Pid.ToString());
                select =
                    select.Where(
                        n =>
                            db.TraModDetail.Where(m => p.Contains(m.Pid))
                                .Select(m => m.CorderId)
                                .Contains(n.CorderId));
                var list = select.ToList();
                if (list.Count == 0)
                    return null;
                return list.First();
            }
        }

        public List<TraModOrderEntity> GetTraModOrderListByOrderIdAndTicketNo(int orderId, List<string> ticketNoList)
        {
            using (BrightourDbContext db = new BrightourDbContext())
            {
                var select = from modOrder in db.TraModOrder

                             where modOrder.OrderId == orderId && (modOrder.OrderStatus != "C")
                             select modOrder;

                var p = db.TraPassenger.Where(k => ticketNoList.Contains(k.TicketNo)).Select(k => k.Pid.ToString());
                select =
                    select.Where(
                        n =>
                            db.TraModDetail.Where(m => p.Contains(m.Pid))
                                .Select(m => m.CorderId)
                                .Contains(n.CorderId));
                var list = select.ToList();
                if (list.Count == 0)
                    return null;
                return list;
            }
        }
    }
}
