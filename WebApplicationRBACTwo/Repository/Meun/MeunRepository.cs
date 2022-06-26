using ClassLibraryDto;
using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class MeunRepository : BaseRepository<Meun,int>,IMeunRepository
    {
        //private readonly MyDbContext myDbContext;

        public MeunRepository(MyDbContext myDbContext)
        {
            this.db = myDbContext;
        }

        
    }
}
