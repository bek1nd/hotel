using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.MD5Helper;
using Mzl.DomainModel.Train.Server;

namespace Mzl.BLL.Train.RequestInterface
{
    public class RequestInterfaceHelper<T> where T : BaseInputModel
    {
        /// <summary>
        /// 请求空铁无忧接口
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="methodStr"></param>
        /// <returns></returns>
        public static BaseInputModel SupplementInPutModel(BaseInputModel obj, string methodStr)
        {
            obj.partnerid = "mzl_formal";
            if (methodStr == "train_query")
                obj.partnerid = "miaozhilv";
            obj.method = methodStr;
            obj.reqtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            obj.sign = MD5Helper.GetSign(obj.partnerid, obj.method, obj.reqtime);
            return obj;
        }
    }
}
