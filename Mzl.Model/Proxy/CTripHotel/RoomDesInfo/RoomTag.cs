using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.RoomDesInfo
{
    public class RoomTag
    {
        /// <summary>
        /// 房型标签的分类编码。VendorID：房型供应商ID
        /// SupplierID：供应商ID
        /// RateCodeID：价格编码ID
        /// Promotion：促销房型
        /// 备注：SupplierID>0，表示该售卖房型是代理商房型。
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 分类编码的名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 该房型在某分类编码中对应的值
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// 房型标签的描述性信息
        /// </summary>
        public string Desc { get; set; }
    }
}
