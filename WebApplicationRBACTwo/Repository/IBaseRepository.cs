using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        T FanT(Expression<Func<T, bool>> predicate);
        List<T> MeunAll();
        int Upd(T c);
        int Assign(List<T> ment);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null);

        int DelAlls(Expression<Func<T, bool>> predicate);
        List<T> GetList(Expression<Func<T, bool>> predicate);
        int Add(List<T> c);
    }
}