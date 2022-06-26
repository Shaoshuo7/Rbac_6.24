using ClassLibraryEntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : class where TKey : struct
    {
        //private readonly MyDbContext db;

        //public BaseRepository(MyDbContext db)
        //{
        //    this.db = db;
        //}

        protected MyDbContext db;

        public virtual List<T> MeunAll()
        {
            return db.Set<T>().ToList();
        }

        public virtual List<T> Cascading()
        {
            return db.Set<T>().ToList();
        }

        public virtual int Del(TKey id)
        {
            var list = db.Set<T>().Find(id);

            db.Remove(list);

            return db.SaveChanges();
        }

        public virtual int Add(T c)
        {
            db.Set<T>().Add(c);

            return db.SaveChanges();
        }

        public virtual T FanT(TKey id)
        {
            var list = db.Set<T>().Find(id);

            return list;
        }

        public virtual T FanT(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate).FirstOrDefault();
        }

        public virtual int Upd(T c)
        {
            db.Entry<T>(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return db.SaveChanges();
        }
    }
}


