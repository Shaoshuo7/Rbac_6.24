using AutoMapper;
using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class BaseService<T, TDto> : IBaseService<T, TDto> where T : class, new() where TDto : class, new()
    {
        private readonly IBaseRepository<T, int> baseRepository;
        private readonly IMapper mapper;

        public BaseService(IBaseRepository<T, int> baseRepository, IMapper mapper)
        {
            this.baseRepository = baseRepository;
            this.mapper = mapper;
        }

        public virtual int Add(TDto c)
        {
            return baseRepository.Add(mapper.Map<T>(c));
        }

        public virtual int Del(int id)
        {
            return baseRepository.Del(id);
        }

        public virtual TDto FanT(int id)
        {
            return mapper.Map<TDto>(baseRepository.FanT(id));
        }

        public virtual List<TDto> GetShow()
        {
            return mapper.Map<List<TDto>>(baseRepository.MeunAll());
        }

        public virtual int Upd(TDto c)
        {
            return baseRepository.Upd(mapper.Map<T>(c));
        }
    }
}
