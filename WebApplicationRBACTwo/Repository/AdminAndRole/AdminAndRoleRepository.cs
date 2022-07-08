using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminAndRoleRepository : BaseRepository<AdminAndRole, int>, IAdminAndRoleRepository
    {
        public AdminAndRoleRepository(MyDbContext myDbContext)
        {
            this.db = myDbContext;
        }
    }
}
