using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mzl.EntityModel.Proxy.MuB2T
{
    /// <summary>
    /// 中转航班返回数据
    /// </summary>
    public class FlightBookingResponse
    {
        /// <summary>
        /// 返回信息类型
        /// </summary>
        public string msgTp { get; set; }
        /// <summary>
        /// 返回信息描述
        /// </summary>
        public string msgDesc { get; set; }
        /// <summary>
        /// B2T订单号
        /// </summary>
        public string orderId { get; set; }
        /// <summary>
        /// 单人票面价（成人）
        /// </summary>
        public float? tktPrice { get; set; }
        /// <summary>
        /// 单人票面价（儿童）
        /// </summary>
        public float? tktChdPrice { get; set; }
        /// <summary>
        /// 成人代理费
        /// </summary>
        public float? discountAm { get; set; }
        /// <summary>
        /// 儿童代理费
        /// </summary>
        public float? chdDiscountAm { get; set; }
        /// <summary>
        /// 代理费率
        /// </summary>
        public string discount { get; set; }
        /// <summary>
        /// 单人实收票价（成人）
        /// </summary>
        public float? salePrice { get; set; }
        /// <summary>
        /// 单人实收票价（儿童）
        /// </summary>
        public float? saleChdPrice { get; set; }
        /// <summary>
        /// B2T登录名
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 联系人
        /// </summary>
        public string contactName { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string contactPhone { get; set; }
        /// <summary>
        /// 联系邮箱
        /// </summary>
        public string contactEmail { get; set; }
        /// <summary>
        /// 航班信息
        /// </summary>
        public List<ODInfo> ODInfoModel { get; set; }
        /// <summary>
        /// 旅客信息
        /// </summary>
        public List<PassInfo> PassInfoModel { get; set; }
        /// <summary>
        /// 外部订单号
        /// </summary>
        public string extRefNo { get; set; }
        /// <summary>
        /// 税费信息
        /// </summary>
        public List<TaxInfo> TaxInfoModel { get; set; }
    }
}
