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

        public virtual int DelAll(int[] ids)
        {
            var list = db.Set<RoleAndMeun>().Where(t => ids.Contains(t.RoleAndMeunId));

            db.Set<RoleAndMeun>().RemoveRange(list);

            return db.SaveChanges();
        }
    }
}
