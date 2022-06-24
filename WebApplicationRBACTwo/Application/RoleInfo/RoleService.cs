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

        public RoleService(IRoleRepository roleRepository,IMapper mapper)
            :base(roleRepository,mapper)
        {
            this.roleRepository = roleRepository;
        }

        public int Add(RoleDto c)
        {
            return roleRepository.Add(new Role
            {
                CreateId = 0,
                IsDelete = false,
                CreateTime = DateTime.Now,
                RoleName = c.RoleName
            });
        }

        public int Upd(RoleDto c)
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
    }
}
