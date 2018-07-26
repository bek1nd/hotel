using Mzl.Framework.Base;
using Mzl.IDAL.Customer.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Mzl.DomainModel.Customer.TravelReport;
namespace Mzl.DAL.Customer.Customer
{
    internal class TravelReportAirlineCountDal : BaseDal, ITravelReportAirlineCountDal
    {
        /// <summary>
        /// 汇总页面求平均票面价和总和数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="yearval"></param>
        /// <param name="corpId"></param>
        /// <returns></returns>
        public List<T> GetTravelReportData<T>(string yearval,string corpId) where T : class
        {
            List<T> tList =
        base.ExcuteQueryBySql<T>(
                  @"SELECT COUNT(1)countNum,ISNULL(avg((SalePrice+TaxFee+OilFee+ServiceFee)),0) avgPrice FROM TravelReport_TicketSource WHERE DATENAME(YEAR,TheMonth)=@yearval and corpId=@corpId",
                    new SqlParameter("@yearval", yearval),
                    new SqlParameter("@corpId", corpId)
                  ).ToList();
            return tList;
        }
        /// <summary>
        /// 求退票金额
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="yearval"></param>
        /// <param name="corpId"></param>
        /// <returns></returns>
        public List<T> GetTravelReportFltRefund<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
            base.ExcuteQueryBySql<T>(
                  @"select top 10
                    CostCenter
                    , sum(RefundFee) PriceSum --退票金额
                    from TravelReport_FltRefundSource
                    where (TheMonth>=@startMonth and TheMonth<=@endMonth) and corpid=@corpid and SourceType = @SourceType
                    and CostCenter IS NOT NULL
                    group by CostCenter
                    order by sum(RefundFee) desc",
                       new SqlParameter("@startMonth", Remodel.StartMonth),
                       new SqlParameter("@endMonth", Remodel.EndMonth),
                       new SqlParameter("@corpid", Remodel.Corpid),
                       new SqlParameter("@SourceType", Remodel.SourceType)
                  ).ToList();
            return tList;
        }
        /// <summary>
        /// 求改签金额
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="yearval"></param>
        /// <param name="corpId"></param>
        /// <returns></returns> where (TheMonth>=@startMonth and TheMonth<=@endMonth) and corpid=@corpid and SourceType = @SourceType
        public List<T> GetTravelReportFltMod<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
            base.ExcuteQueryBySql<T>(
                  @"select top 10
                    CostCenter
                    ,sum(ModPrice) PriceSum --改签金额
                    from TravelReport_FltModSource
                    where (TheMonth>=@startMonth and TheMonth<=@endMonth) and corpid=@corpid and SourceType = @SourceType 
                    and CostCenter IS NOT NULL
                    group by CostCenter
                    order by sum(ModPrice) desc",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
                  ).ToList();
            return tList;
        }
        ///
        ///预定提前天数占比
        ///
        public List<T> GetTravelReport_ReserveDay<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_ReserveDay @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///东上航折扣舱位占比分析
        ///
        public List<T> GetTravelReport_SalePrice<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_SalePrice @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///(全)航司折扣舱位占比分析
        ///
        public List<T> GetTravelReport_AllSalePrice<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_AllSalePrice @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///成本中心汇总表 
        ///
        public List<T> GetTravelReport_CostCenter<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_CostCenter @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///前10条出差航段汇总表
        ///
        public List<T> GetTravelReport_DportCity<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_DportCity @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///前10位人员出差人次汇总表
        ///
        public List<T> GetTravelReport_PassengerTop<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_PassengerTop @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///消费总览
        ///
        public List<T> GetTravelReport_ConsumeCount<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_ConsumeCount @TheYear,@corpid,@SourceType",
                   new SqlParameter("@TheYear", Remodel.TheYear),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///月度消费总额
        ///
        public List<T> GetTravelReport_YearPriceCount<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                @"EXEC Sp1_TravelReport_YearPriceCount @TheYear,@corpid,@SourceType",
                   new SqlParameter("@TheYear", Remodel.TheYear),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///月度消费总额
        ///
        public List<T> GetTravelReport_AirlineCount<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                 @"EXEC Sp1_TravelReport_AirlineCount @startMonth,@endMonth,@corpid,@SourceType",
                   new SqlParameter("@startMonth", Remodel.StartMonth),
                   new SqlParameter("@endMonth", Remodel.EndMonth),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///年享受航司协议节省金额
        ///
        public List<T> GetTravelReport_AirConsumeCount<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                 @"EXEC Sp1_TravelReport_AirConsumeCount @TheYear,@corpid,@SourceType",
                    new SqlParameter("@TheYear", Remodel.TheYear),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
        ///
        ///年享受航司协议节省金额 Table显示
        ///
        public List<T> GetTravelReport_AirConsumeCountTable<T>(TravelReportRequestDoModel Remodel) where T : class
        {
            List<T> tList =
             base.ExcuteQueryBySql<T>(
                 @"EXEC Sp1_TravelReport_AirConsumeCountTable @TheYear,@corpid,@SourceType",
                    new SqlParameter("@TheYear", Remodel.TheYear),
                   new SqlParameter("@corpid", Remodel.Corpid),
                   new SqlParameter("@SourceType", Remodel.SourceType)
             ).ToList();
            return tList;
        }
    }
}
