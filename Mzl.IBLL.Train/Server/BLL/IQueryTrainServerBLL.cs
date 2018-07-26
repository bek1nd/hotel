namespace Mzl.IBLL.Train.Server.BLL
{
    public interface IQueryTrainServerBLL<out T> : IBaseServerBLL where T : class
    {
        T DoQueryTrain();

        
    }
}
