using System.Collections.Generic;

namespace Repository
{
    public interface IBaseRepository<T, TKey>
        where T : class
        where TKey : struct
    {
        int Add(T c);
        List<T> Cascading();
        int Del(TKey id);
        T FanT(TKey id);
        List<T> MeunAll();
        int Upd(T c);
    }
}