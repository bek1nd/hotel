using System;

namespace Mzl.IBLL.Token.Token
{
    public interface ITokenBLL<T> where T : class
    {
        T Get(string token);
        void Set(T t, TimeSpan validFor);
        void Expire(string token, int hours);
        void Delete(string token);
    }
}
