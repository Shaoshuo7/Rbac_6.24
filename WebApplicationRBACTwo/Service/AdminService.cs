using ClassLibraryEntityFrameWork;
using IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class AdminService : IAdminService
    {
        public AdminService(MyDbContext myDbContext)
        { 
            MyDbContext = myDbContext;
        }

        public MyDbContext MyDbContext { get;}

        public int AdminDel(int id)
        {
            var list = MyDbContext.Admin.Find(id);

            MyDbContext.Admin.Remove(list);

            return MyDbContext.SaveChanges();
        }

        public Admin AdminFanT(int id)
        {
            var list = MyDbContext.Admin.Find(id);

            return list;
        }

        public List<Admin> AdminShow()
        {
            var list = MyDbContext.Admin.AsQueryable();

            return list.ToList();
        }

        public int AdminUpd(Admin c)
        {
            MyDbContext.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return MyDbContext.SaveChanges();
        }
    }
}
