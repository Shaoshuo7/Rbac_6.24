using AutoMapper;
using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class AutoMapperConfilg : Profile
    {
        public AutoMapperConfilg()
        {
            CreateMap<AddDto, Meun>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<AdminDto, Admin>().ReverseMap();
            CreateMap<MeunListDto, Meun>().ReverseMap();
        }
    }
}
