using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Proxy.CTripHotel.SearchHotelLowPrice
{
    public class LowPriceResEntity
    {
        public ResponseStatusEntity ResponseStatus { get; set; }
        public IList<NumEntity> NumEntity { get; set; }
        /// <summary>
        /// 符合请求条件的所有酒店ID列表，该节点并非每次请求都会返回。详情如下：
        /// 若PageIndex为空、为0或者不存在PageIndex节点，则每次调用，返回报文均会返回该节点；
        /// 若PageIndex大于0，则首次调用会返回该节点，之后的请求不一定每次都会返回该节点。
        /// 备注：谨慎使用该节点，未来可能会废弃。
        /// </summary>
        public string AllHotelID { get; set; }
        public IList<HotelDataList> HotelDataLists { get; set; }
    }
}
