using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IAdminService : IBaseService<Admin,AdminDto>
    {
        ResultDto AdminAdd(AdminDto c);

        TokenDto AdmLogin(LoginDto c);
    }
}
