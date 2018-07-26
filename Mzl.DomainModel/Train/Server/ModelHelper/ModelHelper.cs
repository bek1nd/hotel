using System;

namespace Mzl.DomainModel.Train.Server.ModelHelper
{
    /// <summary>
    /// 只能使用继承自 BaseInputModel 的类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class BaseInputModelHelper<T> where T: BaseInputModel
    {
        public static BaseInputModel SupplementInPutModel(BaseInputModel obj, string methodStr)
        {
            obj.partnerid = "mzl_formal";
            if (methodStr== "train_query")
                obj.partnerid = "miaozhilv";
            obj.method = methodStr;
            obj.reqtime = DateTime.Now.ToString("yyyyMMddHHmmss");
            obj.sign = Mzl.Common.MD5Helper.MD5Helper.GetSign(obj.partnerid, obj.method, obj.reqtime);
            return obj;
        }




    }
}
