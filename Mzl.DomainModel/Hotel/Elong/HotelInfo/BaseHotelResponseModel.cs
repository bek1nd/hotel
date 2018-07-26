namespace Mzl.DomainModel.Hotel.Elong.HotelInfo
{
    public class BaseHotelResponseModel<T>
    {
        public string Code { get; set; }
        public T Result { get; set; }
        public T Data { get; set; }
    }
}
