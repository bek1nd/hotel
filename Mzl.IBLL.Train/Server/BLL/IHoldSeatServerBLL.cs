namespace Mzl.IBLL.Train.Server.BLL
{
    /// <summary>
    /// 火车票占位接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IHoldSeatServerBLL<in T> : IBaseServerBLL where T : class
    {
        /// <summary>
        /// 保存占位回调信息
        /// </summary>
        /// <param name="t"></param>
        bool SaveHoldSeatLog(T t);

        /// <summary>
        /// 获取占位信息
        /// </summary>
        /// <returns></returns>
        string ReceiveHoldSeatInof();

    }
}
