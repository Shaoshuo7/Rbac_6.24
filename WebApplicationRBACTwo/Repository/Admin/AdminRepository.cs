﻿using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminRepository : BaseRepository<Admin, int>, IAdminRepository
    {
        public AdminRepository(MyDbContext myDbContext)
        {
            this.db = myDbContext;
        }
    }
}
