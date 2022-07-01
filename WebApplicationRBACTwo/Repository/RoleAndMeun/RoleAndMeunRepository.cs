using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleAndMeunRepository : BaseRepository<RoleAndMeun, int>, IRoleAndMeunRepository
    {
        public RoleAndMeunRepository(MyDbContext myDbContext)
        {
            this.db = myDbContext;
        }
    }
}
