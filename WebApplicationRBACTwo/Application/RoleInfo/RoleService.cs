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
    public class RoleService : BaseService<Role,RoleDto>, IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IRoleAndMeunRepository roleAndMeunRepository;

        public RoleService(IRoleRepository roleRepository,IMapper mapper,IRoleAndMeunRepository roleAndMeunRepository)
            :base(roleRepository,mapper)
        {
            this.roleRepository = roleRepository;
            this.roleAndMeunRepository = roleAndMeunRepository;
        }

        public int Adds(RoleDto c)
        {
            return roleRepository.Add(new Role
            {
                CreateId = 0,
                IsDelete = false,
                CreateTime = DateTime.Now,
                RoleName = c.RoleName
            });
        }

        public int Upds(RoleDto c)
        {
            return roleRepository.Upd(new Role
            {
                RoleId = c.RoleId,
                CreateId = 0,
                IsDelete = false,
                CreateTime = DateTime.Now,
                RoleName = c.RoleName
            });
        }

        public int GetAssignment(AssignmentDto c)
        {
            var values = c.MeunId.Select(t => new RoleAndMeun { MeunId = t, RoleId = c.RoleId }).ToList();

            return roleAndMeunRepository.Assign(values);
        }
    }
}
