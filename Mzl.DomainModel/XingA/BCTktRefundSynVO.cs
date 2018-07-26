using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.XingA
{
    public class BCTktRefundSynVO
    {
        /// <summary>
        /// 行程单号
        /// </summary>
        public long? journeyNo { get; set; }
        /// <summary>
        /// 票号
        /// </summary>
        public string ticketNo { get; set; }
        /// <summary>
        /// PNR号
        /// </summary>
        public string pnrNo { get; set; }
        /// <summary>
        /// 打票机号
        /// </summary>
        public string playTktNo { get; set; }
        /// <summary>
        /// 国际国内标识（d-国内，i-国际）
        /// </summary>
        public string di { get; set; }
        /// <summary>
        /// 公司编码
        /// </summary>
        public string corpCode { get; set; }
        /// <summary>
        /// 退票申请时间
        /// </summary>
        public string applyTime { get; set; }
        /// <summary>
        /// 退票处理时间
        /// </summary>
        public string dealTime { get; set; }
        /// <summary>
        /// 操作员的账号
        /// </summary>
        public string manipulate { get; set; }
        /// <summary>
        /// 退票手续费
        /// </summary>
        public double? dealBOperFee { get; set; }
        /// <summary>
        /// 退票服务费
        /// </summary>
        public double? dealBServiceFee { get; set; }
        /// <summary>
        /// 实退金额
        /// </summary>
        public double? dealBRealPrice { get; set; }
        /// <summary>
        /// 供应商退票手续费
        /// </summary>
        public double? supplierBOperFee { get; set; }
        /// <summary>
        /// 供应商实退金额
        /// </summary>
        public double? supplierBRealPrice { get; set; }
        /// <summary>
        /// 退票单号
        /// </summary>
        public string bTktNo { get; set; }
        /// <summary>
        /// 行啊传送的加密密文
        /// </summary>

        public string RequestStr { get; set; }
    }
}
