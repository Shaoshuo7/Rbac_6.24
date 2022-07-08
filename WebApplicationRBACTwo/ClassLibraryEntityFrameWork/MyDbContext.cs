using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryEntityFrameWork
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<AdminAndRole> AdminAndRole { get; set; }
        public DbSet<Meun> Meun { get; set; }
        public DbSet<RoleAndMeun> RoleAndMeun { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleAndMeun>(t =>
            {
                t.HasOne<Role>().WithMany().HasForeignKey(s => s.RoleId);
                t.HasOne<Meun>().WithMany().HasForeignKey(s => s.MeunId);
            });

            modelBuilder.Entity<AdminAndRole>(t =>
            {
                t.HasOne<Admin>().WithMany().HasForeignKey(s => s.AdminId);
                t.HasOne<Role>().WithMany().HasForeignKey(s => s.RoleId);
            });
        }
    }
}
