using Mzl.EntityModel.Tool.MuB2T;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mzl.EntityModel.Tool
{
    public class ToolDbContext : DbContext
    {
        public ToolDbContext() : base("name=Tool")
        {
        }

        static ToolDbContext()
        {
            Database.SetInitializer<ToolDbContext>(null);
        }

        /// <summary>
        /// 航班号
        /// </summary>
        public DbSet<FlightNo> FlightNos { get; set; }


        /// <summary>
        /// 航班价格查询
        /// </summary>
        public DbSet<RtInterFlightPriceQueryLog> RtInterFlightPriceQueryLogs { get; set; }

        /// <summary>
        /// 税费查询
        /// </summary>
        public DbSet<RtFlightTaxQueryLog> RtFlightTaxQueryLogs { get; set; }


        /// <summary>
        /// 价格查询条件
        /// </summary>
        public DbSet<PriceSearchQuery> PriceSearchQuerys { get; set; }

        /// <summary>
        /// 航班价格信息
        /// </summary>
        public DbSet<ETL0RtFlightPrice> ETL0RtFlightPrices { get; set; }
    }
}
