using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.DomainModel.Customer.TravelReport
{
    public class TravelReportAirConsumeCountTableModel
    {
        /// <summary>
        /// 查询月份
        /// </summary>
        [Description("查询月份")]
        public DateTime? TheMonth { get; set; }
        ///人数
        [Description("人次")]
        public int mannum { get; set; }
        ///原价总额
        [Description("原价总额")]
        public decimal FacePrice1 { get; set; }
        ///售价总额
        [Description("售价总额")]
        public decimal SalePrice1 { get; set; }
        ///节省金额
        [Description("节省总额")]
        public decimal SavePrice1 { get; set; }
        ///原价总额
        [Description("原价总额")]
        public decimal FacePrice2 { get; set; }
        ///售价总额
        [Description("售价总额")]
        public decimal SalePrice2 { get; set; }
        ///节省金额
        [Description("节省总额")]
        public decimal SavePrice2 { get; set; }
        ///原价总额
        [Description("原价总额")]
        public decimal FacePrice3 { get; set; }
        ///售价总额
        [Description("售价总额")]
        public decimal SalePrice3 { get; set; }
        ///节省金额
        [Description("节省总额")]
        public decimal SavePrice3 { get; set; }
        ///原价总额
        [Description("原价总额")]
        public decimal FacePrice4 { get; set; }
        ///售价总额
        [Description("售价总额")]
        public decimal SalePrice4 { get; set; }
        ///节省金额
        [Description("节省总额")]
        public decimal SavePrice4 { get; set; }
        ///原价总额
        [Description("原价总额")]
        public decimal FacePrice5 { get; set; }
        ///售价总额
        [Description("售价总额")]
        public decimal SalePrice5 { get; set; }
        ///节省金额
        [Description("节省总额")]
        public decimal SavePrice5 { get; set; }

    }
}
