using AutoMapper;
using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application
{
    public class MeunService : IMeunService
    {
        private readonly IMeunRepository meunRepository;
        private readonly IMapper mapper;

        public MeunService(IMeunRepository meunRepository,IMapper mapper)
        {
            this.meunRepository = meunRepository;
            this.mapper = mapper;
        }

        public List<MeunDto> MeunAll()
        {
            var list = meunRepository.MeunAll();

            List<MeunDto> meunDtos = new List<MeunDto>();

            var meuns = list.Where(t => t.MeId == 0).Select(t => new MeunDto
            {
                MeunId = t.MeunId,
                MeunName = t.MeunName,
                MeunLink = t.MeunLink,
            }).ToList();

            Recursions(meuns);

            return meuns;
        }

        /// <summary>
        /// 菜单显示递归
        /// </summary>
        /// <param name="meunDtos"></param>
        private void Recursions(List<MeunDto> meunDtos)
        {
            var list = meunRepository.MeunAll();

            foreach (var item in meunDtos)
            {
                var meunlist = list.Where(q => q.MeId == item.MeunId).Select(t => new MeunDto
                {
                    MeunId = t.MeunId,
                    MeunName = t.MeunName,
                    MeunLink = t.MeunLink,
                }).ToList();

                item.children.AddRange(meunlist);

                Recursions(meunlist);

            }
        }

        public int Del(int id)
        {
            var list = meunRepository.MeunAll();

            var query = list.Where(t => t.MeunId == id).Select(t => new MeunDto
            {
                MeunId = t.MeunId,
                MeunLink = t.MeunLink,
                MeunName = t.MeunName,
                children = list.Where(t => t.MeId == id).Select(t => new MeunDto
                {
                    MeunId = t.MeunId,
                    MeunName = t.MeunName,
                    MeunLink = t.MeunLink
                }).ToList()
            }).FirstOrDefault();
            if (query.children.Count() > 0)
            {
                return 500;
            }

            return meunRepository.Del(id);
        }

        public List<CreateDto> Cascading()
        {
            var list = meunRepository.MeunAll();

            List<CreateDto> meuns = list.Where(t => t.MeId == 0).Select(t => new CreateDto
            {
                value = t.MeunId,
                label = t.MeunName
            }).ToList();

            JiLian(meuns);

            return meuns;
        }

        /// <summary>
        /// 级联显示递归
        /// </summary>
        /// <param name="meunDtos"></param>
        private void JiLian(List<CreateDto> meunDtos)
        {
            var list = meunRepository.MeunAll();

            foreach (var item in meunDtos)
            {
                var meunlist = list.Where(t => t.MeId == item.value).Select(t => new CreateDto
                {
                    value = t.MeunId,
                    label = t.MeunName
                }).ToList();

                item.children.AddRange(meunlist);

                JiLian(meunlist);

            }
        }

        public int Add(AddDto c)
        {
            return meunRepository.Add(new Meun
            {
                MeunName = c.MeunName,
                MeId = c.MeId,
                MeunLink = c.MeunLink,
                CreateId = 0,
                IsDelete = false,
                CreateTime = DateTime.Now
            });


            //return meunRepository.Add(mapper.Map<Meun>(c));
        }

        public Meun FanT(int id)
        {
            //var list = meunRepository.MeunAll();

            //var query = list.Where(t => t.MeunId == id).Select(t => new CreateDto
            //{
            //    value = t.MeId,
            //    label = t.MeunName
            //});

            return meunRepository.FanT(id);
        }

        public int Upd(AddDto c)
        {
            return meunRepository.Upd(new Meun
            {
                MeunId = c.MeunId,
                MeunName = c.MeunName,
                MeId = c.MeId,
                MeunLink = c.MeunLink,
                CreateId = 0,
                IsDelete = false,
                CreateTime = DateTime.Now
            });

            //return meunRepository.Upd(mapper.Map<Meun>(c));
        }

        public List<MeunListDto> MeunListAll()
        {
            return mapper.Map<List<MeunListDto>>(meunRepository.MeunAll());
        }
    }
}
