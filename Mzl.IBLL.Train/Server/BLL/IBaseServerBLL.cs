namespace Mzl.IBLL.Train.Server.BLL
{
    public interface IBaseServerBLL
    {
        string Data { get; set; }
        /// <summary>
        /// POST请求外部接口地址
        /// </summary>
        /// <returns></returns>
        string DoPostRequest();
        /// <summary>
        /// GET请求外部接口地址
        /// </summary>
        /// <returns></returns>
        string DoGetRequest();
        /// <summary>
        /// 保存日志
        /// </summary>
        /// <param name="logInfo"></param>
        void SaveLog(string logInfo);
    }
}
