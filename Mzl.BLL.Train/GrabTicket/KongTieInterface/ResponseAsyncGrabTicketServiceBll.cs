using System.Collections.Generic;
using System.Linq;
using Mzl.DomainModel.Train.GrabTicket.KongTieInterface;
using Mzl.IBLL.Train.GrabTicket.KongTieInterface;
using Newtonsoft.Json;

namespace Mzl.BLL.Train.GrabTicket.KongTieInterface
{
    internal class ResponseAsyncGrabTicketServiceBll : IResponseAsyncGrabTicketServiceBll
    {

        /// <summary>
        /// 失败结果
        /// </summary>
       public GrabTicketFailedDataAsyncResponseModel FailedResult { get; private set; }
        /// <summary>
        /// 成功结果
        /// </summary>
        public GrabTicketSuccessedDataAsyncResponseModel SuccessedResult { get; private set; }

        /// <summary>
        /// 收到抢票异步通知
        /// </summary>
        /// <returns></returns>
        public bool ResponseGrabTicketResult(string responseData)
        {
            bool flag = false;
            if (string.IsNullOrEmpty(responseData))
            {
                return flag;
            }

            Dictionary < string, string> dictionary= ParserResponseData(responseData);//解析抢票通知响应结果

            //判断抢票是否成功
            string isSuccess = dictionary["issuccess"];
            string data = dictionary["data"];
        
            GrabTicketAbstractAsyncResponseModel responseModel= Produce(isSuccess, data);

            if (isSuccess == "Y")
            {
                responseModel.transactionid= dictionary["transactionid"];
                flag = true;
            }

            responseModel.reqtime = dictionary["reqtime"];
            responseModel.sign = dictionary["sign"];
            responseModel.orderid = dictionary["orderid"];
            responseModel.isSuccess = isSuccess;

            return flag;
        }


        /// <summary>
        /// 解析抢票通知响应结果
        /// </summary>
        /// <param name="responseData"></param>
        /// <returns></returns>
        private Dictionary<string, string> ParserResponseData(string responseData)
        {
          
            List<string> responseDataList = responseData.Split('&').ToList();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var data in responseDataList)
            {
                string key = data.Split('=')[0].ToLower();
                string value = data.Split('=')[1];
                dictionary.Add(key.Trim(), value.Trim());
            }

            return dictionary;

        }


        private GrabTicketAbstractAsyncResponseModel Produce(string isSuccess,string data)
        {
            if (isSuccess == "N")//抢票失败
            {
                FailedResult =
                    JsonConvert.DeserializeObject<GrabTicketFailedDataAsyncResponseModel>(data);
                return new GrabTicketFailedAsyncResponseModel() {data = FailedResult };
            }

            SuccessedResult =
                  JsonConvert.DeserializeObject<GrabTicketSuccessedDataAsyncResponseModel>(data);
            return new GrabTicketSuccessedAsyncResponseModel() {data = SuccessedResult};
        }
    }
}
