using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IRoleService : IBaseService<Role,RoleDto>
    {
        int Add(RoleDto c);

        int Upd(RoleDto c);
    }
}
