using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : BaseRepository<Role, int>, IRoleRepository
    {
        private readonly MyDbContext myDbContext;

        public RoleRepository(MyDbContext myDbContext)
        {
            this.db = myDbContext;
        }
    }
}
