using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mzl.Common.MD5Helper;
using Mzl.DomainModel.Train.Server;

namespace Mzl.Common.ModelHelper
{
    /// <summary>
    /// 只能使用继承自 BaseInputModel 的类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class BaseInputModelHelper<T> where T: BaseInputModel
    {
        public static BaseInputModel SupplementInPutModel(BaseInputModel obj, string MethodStr)
        { 
            obj.partnerid = "miaozhilv";
            obj.method = MethodStr;
            obj.reqtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            obj.sign = MD5Helper.MD5Helper.GetSign(obj.partnerid, obj.method, obj.reqtime);
            return obj;
        }




    }
}
