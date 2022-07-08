using System.Collections.Generic;

namespace Application
{
    public interface IBaseService<T, TDto> where TDto : class, new() where T : class ,new()
    {
        int Add(TDto c);
        int Del(int id);
        TDto FanT(int id);
        List<TDto> GetShow();
        int Upd(TDto c);
        List<TDto> GetList();
    }
}