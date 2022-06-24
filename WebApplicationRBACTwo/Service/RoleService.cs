using ClassLibraryEntityFrameWork;
using IService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RoleService : IRoleService
    {
        public RoleService(MyDbContext myDbContext)
        { 
            MyDbContext = myDbContext;
        }

        public MyDbContext MyDbContext { get;}

        public List<Role> RoleShow()
        {
            var list = MyDbContext.Role.Include("Admin").AsQueryable();

            return list.ToList();
        }
    }
}
