using Mzl.IApplication.Flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mzl.Mojory.WebApi.Config;
using Mzl.UIModel.Base;
using Mzl.UIModel.Flight;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Net.Http.Headers;

namespace Mzl.Mojory.WebApi.Controllers.Flight.Corp
{
    /// <summary>
    /// 机票退票申请列表
    /// </summary>
    public class QueryFlightRetApplyListController : ApiController
    {
        private readonly IQueryFlightRetApplyListApplication _queryFlightRetApplyListApplication;

        public QueryFlightRetApplyListController(IQueryFlightRetApplyListApplication queryFlightRetApplyListApplication)
        {
            _queryFlightRetApplyListApplication = queryFlightRetApplyListApplication;
        }

        /// <summary>
        /// 查询机票退票申请列表
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseBaseViewModel<QueryFltRetApplyListResponseViewModel> QueryFlightRetApplyList(QueryFltRetApplyListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            QueryFltRetApplyListResponseViewModel responseViewModel = _queryFlightRetApplyListApplication.QueryFltRetApplyList(request);

            ResponseBaseViewModel<QueryFltRetApplyListResponseViewModel> v =
              new ResponseBaseViewModel<QueryFltRetApplyListResponseViewModel>
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
        public HttpResponseMessage ExportFlightOrderList([FromUri]QueryFltRetApplyListRequestViewModel request)
        {
            request.Cid = this.GetCid();
            //导出
            request.IsExport = 1;
            QueryFltRetApplyListResponseViewModel responseViewModel = _queryFlightRetApplyListApplication.QueryFltRetApplyList(request);
            var file = ExcelStream(responseViewModel.ApplyDataList);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            result.Content = new StreamContent(file);
            //a text file is actually an octet-stream (pdf, etc)
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            //we used attachment to force download
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = "国内机票退票订单.xls";
            return result;
        }
        private System.IO.Stream ExcelStream(List<FltRetApplyListDataViewModel> orderList)
        {
            //var list = dc.v_bs_dj_bbcdd1.Where(eps).ToList();
            HSSFWorkbook hssfworkbook = new HSSFWorkbook();
            ICellStyle notesStyle = hssfworkbook.CreateCellStyle();
            notesStyle.WrapText = true;

            ISheet sheet1 = hssfworkbook.CreateSheet("国内机票退票订单");


            IRow rowHeader = sheet1.CreateRow(0);

            //生成excel标题
            rowHeader.CreateCell(0).SetCellValue("原订单号");
            rowHeader.CreateCell(1).SetCellValue("行程");
            rowHeader.CreateCell(2).SetCellValue("乘机人");
            rowHeader.CreateCell(3).SetCellValue("航班号");
            rowHeader.CreateCell(4).SetCellValue("申请时间");
            rowHeader.CreateCell(5).SetCellValue("状态");
            int j = 0;
            //生成excel内容
            foreach (var item in orderList)
            {
                NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(1 + j);
                rowtemp.CreateCell(0).SetCellValue(item.OrderId);
                string fltPassenger = "";
                for (int i = 0; i < item.PassengerList.Count; i++)
                {
                    if (i == 0)
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
                    if (i == 0)
                    {
                        flightNo += item.FlightList[i].FlightNo;
                        xingC += "" + item.FlightList[i].DportName + "-" + item.FlightList[i].AportName + "";
                        tackOffTime += item.FlightList[i].TackOffTime.ToString("yyyy-MM-dd HH:mm");
                    }
                    else
                    {
                        flightNo += "\n" + item.FlightList[i].FlightNo;
                        xingC += "\n" + item.FlightList[i].DportName + "-" + item.FlightList[i].AportName;
                        tackOffTime += "\n" + item.FlightList[i].TackOffTime.ToString("yyyy-MM-dd HH:mm");
                    }
                }
                //换行要这样写
                ICell cell = rowtemp.CreateCell(1);
                cell.SetCellValue(xingC);
                cell.CellStyle = notesStyle;

                ICell cell2 = rowtemp.CreateCell(2);
                cell2.SetCellValue(fltPassenger);
                cell2.CellStyle = notesStyle;

                ICell cell3 = rowtemp.CreateCell(3);
                cell3.SetCellValue(flightNo);
                cell3.CellStyle = notesStyle;

                rowtemp.CreateCell(4).SetCellValue(item.CreateTime.ToString("yyyy-MM-dd HH:mm"));
                rowtemp.CreateCell(5).SetCellValue(item.OrderStatusDesc);
                j++;
            }
            //列宽自动调节
            for (int i = 0; i < 6; i++)
                sheet1.AutoSizeColumn(i);

            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            file.Seek(0, SeekOrigin.Begin);
            return file;
        }
    }
}
