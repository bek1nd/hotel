using Mzl.DomainModel.Events;
using Mzl.DomainModel.Train.Order;
using Mzl.DomainModel.Train.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.DomainModel.Common.Account;
using Mzl.DomainModel.Customer.ContactInfo;
using Mzl.DomainModel.Train.BaseMaintenance;

namespace Mzl.IApplication.Train.Order.Domain
{
    /// <summary>
    /// 火车票业务接口
    /// </summary>
    public interface IOrderDomain
    {
        #region 事件
        /// <summary>
        /// 接口订单提交事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraOrderSubmitModel>> ServerOrderSubmit;
        /// <summary>
        /// 第三方接口退票提交事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraTicketRefundModel>> ServerRefundSubmit;
        /// <summary>
        /// 改签提交事件
        /// </summary>
        event EventHandler<TraServerEventArgs<TraRequestChangeModel>> ServerModSubmit;
        /// <summary>
        /// 付供应商事件
        /// </summary>
        event EventHandler<CommonEventArgs<AccountDetailModel>> PaySupplierEvent;
        /// <summary>
        /// 收供应商事件
        /// </summary>
        event EventHandler<CommonEventArgs<AccountDetailModel>> CollectSupplierEvent;
        /// <summary>
        /// 新增联系人事件
        /// </summary>
        event EventHandler<CommonEventArgs<List<ContactInfoModel>>> AddContactEvent;
        #endregion

        #region 事件监听
        /// <summary>
        /// 监听占位成功后的操作
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoTraHoldSeatCallBackEvent(object o, TraServerEventArgs<TraHoldSeatCallBackLogModel> e);
        /// <summary>
        /// 监听确认出票成功后的操作
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoOrderConfirmEvent(object o, TraServerEventArgs<TraOrderConfirmModel> e);
        /// <summary>
        /// 退票回调后的执行操作
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void RefundTicketCallBackEvent(object o, TraServerEventArgs<TraRefundTicketCallBackLogModel> e);
        /// <summary>
        /// 改签回调执行事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoModCallBackEvent(object o, TraServerEventArgs<TraModHoldSeatCallBackLogModel> e);
        /// <summary>
        /// 改签确认执行事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoModComfireEvent(object o, TraServerEventArgs<TraRequestConfirmModel> e);
        /// <summary>
        /// 改签出票成功回调后执行事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoModPrintTicketEvent(object o, TraServerEventArgs<TraModPrintTicketCallBackLogModel> e);
        /// <summary>
        /// 执行出票回调事件
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        void DoOrderTicketEvent(object o, TraServerEventArgs<TraPrintTicketCallBackLogModel> e);
        #endregion

        #region 正单
        /// <summary>
        /// 新增火车订单信息
        /// </summary>
        /// <param name="newOrder">火车订单</param>
        /// <returns></returns>
        int AddOrder(TraAddOrderModel newOrder);
        /// <summary>
        /// 火车订单列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TraOrderListDataModel> GetTraOrderByPageList(TraOrderListQueryModel query, ref int totalCount);
        /// <summary>
        /// 获取火车订单详情信息
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <returns></returns>
        TraOrderInfoModel GetTraOrderByOrderId(int orderid);
        /// <summary>
        /// 获取12306帐号信息
        /// </summary>
        /// <returns></returns>
        List<Tra12306AccountModel> GetTra12306AccountList();
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        TraOrderModel GetTraOrderModelByOrderId(int orderId);

        List<TraOrderDetailModel> AutoAnalysis(string analysisArgs);
        #endregion

        #region 退单
        /// <summary>
        /// 火车退票订单列表（分页）
        /// </summary>
        /// <param name="query"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TraOrderListDataModel> GetTraRetOrderByPageList(TraOrderListQueryModel query, ref int totalCount);
        /// <summary>
        /// 获取添加火车退票信息
        /// </summary>
        /// <param name="orderid">订单号</param>
        /// <param name="isFromOnline">是否来自线上</param>
        /// <param name="corderId">改签订单号</param>
        /// <returns></returns>
        TraRetModOrderModel GetAddTraRetOrderView(int orderid, bool isFromOnline, int? corderId = null);
        /// <summary>
        /// 添加退票订单
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int AddRetOrder(TraAddRetModOrderModel newOrder);
        /// <summary>
        /// 根据原订单号获取对应的退票单信息
        /// </summary>
        /// <param name="rootOrderid"></param>
        /// <returns></returns>
        List<TraOrderInfoModel> GetTraRetOrderByRootOrderId(int rootOrderid);
        #endregion

        #region 改签
        /// <summary>
        /// 获取添加火车改签信息
        /// </summary>
        /// <param name="orderid"></param>
        /// <param name="isFromOnline"></param>
        /// <returns></returns>
        TraRetModOrderModel GetAddTraModOrderView(int orderid, bool isFromOnline);
        /// <summary>
        /// 添加改签订单
        /// </summary>
        /// <param name="newOrder"></param>
        /// <returns></returns>
        int AddModOrder(TraAddRetModOrderModel newOrder);
        /// <summary>
        /// 改签订单列表分页
        /// </summary>
        /// <param name="query"></param>
        /// <param name="totalCount"></param>
        /// <returns></returns>
        List<TraModOrderListDataModel> GetTraModOrderByPageList(TraModOrderListQueryModel query, ref int totalCount);
        /// <summary>
        /// 获取改签订单详情
        /// </summary>
        /// <param name="corderId"></param>
        /// <returns></returns>
        TraModOrderInfoModel GetTraModOrderByCorderId(int corderId);
        /// <summary>
        /// 根据原订单号获取对应的改签单信息
        /// </summary>
        /// <param name="rootOrderid"></param>
        /// <returns></returns>
        List<TraModOrderInfoModel> GetTraModOrderByRootOrderId(int rootOrderid);
        /// <summary>
        /// 获取改签扣率说明
        /// </summary>
        /// <param name="facePriceList"></param>
        /// <param name="modFacePrice"></param>
        /// <param name="startTime"></param>
        /// <param name="modStartTime"></param>
        /// <returns></returns>
        string GetModFeeRate(List<decimal> facePriceList, decimal modFacePrice,DateTime modStartTime, DateTime startTime);
        #endregion
    }
}
