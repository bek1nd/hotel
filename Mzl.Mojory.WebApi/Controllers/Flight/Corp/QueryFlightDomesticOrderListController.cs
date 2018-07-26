using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using Mzl.IApplication.Flight;
using Mzl.Mojory.WebApi.Config;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Net.Http.Headers;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 查询机票订单列表
    /// </summary>
    public class QueryFlightDomesticOrderListController : ApiController
    {
        private readonly IQueryFlightOrderListApplication _queryFlightOrderListApplication;

        public QueryFlightDomesticOrderListController(IQueryFlightOrderListApplication queryFlightOrderListApplication)
        {
            _queryFlightOrderListApplication = queryFlightOrderListApplication;
        }

        /// <summary>
        /// 查询机票订单列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<QueryFltOrderListResponseViewModel> QueryFlightOrderList(QueryFltOrderListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryFltOrderListResponseViewModel responseViewModel= _queryFlightOrderListApplication.QueryFltOrderList(request);
            ResponseBaseViewModel<QueryFltOrderListResponseViewModel> v =
              new ResponseBaseViewModel<QueryFltOrderListResponseViewModel>
              {
                  Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
                  Data = responseViewModel
              };

            return v;
        }
        /// <summary>
        /// 导出机票订单
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ExportFlightOrderList([FromUri]QueryFltOrderListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            //导出
            request.IsExport = 1;
            QueryFltOrderListResponseViewModel responseViewModel = _queryFlightOrderListApplication.QueryFltOrderList(request);

            var file = ExcelStream(responseViewModel.OrderDataList);
            //string csv = _service.GetData(model);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(file);
            //a text file is actually an octet-stream (pdf, etc)
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            //we used attachment to force download
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "国内机票订单.xls";
            return result;

            //ResponseBaseViewModel<QueryFltOrderListResponseViewModel> v =
            //  new ResponseBaseViewModel<QueryFltOrderListResponseViewModel>
            //  {
            //      Flag = new ResponseCodeViewModel() { Code = 0, MojoryToken = this.GetToken() },
            //      Data = responseViewModel
            //  };

            //return v;
        }
        private System.IO.Stream ExcelStream(List<FltOrderListDataViewModel> orderList)
        {
            //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ICellStyle notesStyle = hssfworkbook.CreateCellStyle();
            notesStyle.WrapText = true;

            

            ISheet sheet1 = hssfworkbook.CreateSheet("国内机票订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("订单号");
            rowHeader.CreateCell(1).SetCellValue("出行人");
            rowHeader.CreateCell(2).SetCellValue("班次");
            rowHeader.CreateCell(3).SetCellValue("行程");
            rowHeader.CreateCell(4).SetCellValue("航班时间");
            rowHeader.CreateCell(5).SetCellValue("订票时间");
            rowHeader.CreateCell(6).SetCellValue("票价（含服务费）");
            rowHeader.CreateCell(7).SetCellValue("订单状态");
            int j = 0;
            //生成excel内容
            foreach (var item in orderList)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(1 + j);
                
                rowtemp.CreateCell(0).SetCellValue(item.OrderId);
                string fltPassenger = "";
                for (int i = 0; i < item.PassengerList.Count; i++)
                {
                    if(i==0)
                    {
                        fltPassenger += item.PassengerList[i].Name;
                    }
                    else
                    {
                        fltPassenger += "\n" + item.PassengerList[i].Name;
                    }
                }
                string flightNo = "";
                string xingC = "";
                string tackOffTime = "";
                for (int i = 0; i < item.FlightList.Count; i++)
                {
                    if(i==0)
                    {
                        flightNo += item.FlightList[i].FlightNo;
                        xingC += "(" + item.FlightList[i].DportCity + "-" + item.FlightList[i].AportCity + ") " + item.FlightList[i].DportName + "-" + item.FlightList[i].AportName + "";
                        tackOffTime += item.FlightList[i].TackOffTime.ToString("yyyy-MM-dd HH:mm");
                    }
                    else
                    {
                        flightNo += "\n" + item.FlightList[i].FlightNo;
                        xingC += "\n" + "(" + item.FlightList[i].DportCity + "-" + item.FlightList[i].AportCity + ") " + item.FlightList[i].DportName + "-" + item.FlightList[i].AportName;
                        tackOffTime += "\n" + item.FlightList[i].TackOffTime.ToString("yyyy-MM-dd HH:mm");
                    }
                }
                //乘机人列
                ICell cell = rowtemp.CreateCell(1);
                cell.SetCellValue(fltPassenger);
                cell.CellStyle = notesStyle;

                ICell cell2 = rowtemp.CreateCell(2);
                cell2.SetCellValue(flightNo);
                cell2.CellStyle = notesStyle;

                ICell cell3 = rowtemp.CreateCell(3);
                cell3.SetCellValue(xingC);
                cell3.CellStyle = notesStyle;

                ICell cell4 = rowtemp.CreateCell(4);
                cell4.SetCellValue(tackOffTime);
                cell4.CellStyle = notesStyle;

                rowtemp.CreateCell(5).SetCellValue(item.OrderDate.ToString("yyyy-MM-dd HH:mm"));
                rowtemp.CreateCell(6).SetCellValue(item.PayAmount.ToString());
                rowtemp.CreateCell(7).SetCellValue(item.OnlineOrderStatus);
                j++;
            }

            for (int i = 0; i < 10; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);
            return file;
        }
        private System.IO.Stream ExcelStream1()
        {
            //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();

            ISheet sheet1 = hssfworkbook.CreateSheet("机票订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("订单号");
            rowHeader.CreateCell(1).SetCellValue("出行人");
            rowHeader.CreateCell(2).SetCellValue("班次");
            rowHeader.CreateCell(3).SetCellValue("行程");
            rowHeader.CreateCell(4).SetCellValue("航班时间");
            rowHeader.CreateCell(5).SetCellValue("订票时间");
            rowHeader.CreateCell(6).SetCellValue("票价（含服务费）");
            rowHeader.CreateCell(7).SetCellValue("订单状态");
           
            //生成excel内容
            
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(1);
                rowtemp.CreateCell(0).SetCellValue("1111211");
                rowtemp.CreateCell(1).SetCellValue("333");
                //string 
                rowtemp.CreateCell(2).SetCellValue("111");
                rowtemp.CreateCell(3).SetCellValue("111");
                rowtemp.CreateCell(4).SetCellValue("111");
                rowtemp.CreateCell(5).SetCellValue("111");
                rowtemp.CreateCell(6).SetCellValue("111");
                rowtemp.CreateCell(7).SetCellValue("111");
                
            



            for (int i = 0; i < 10; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);
            return file;

            //return File(file, "application/vnd.ms-excel", "保税订单.xls");
        }
    }
}
