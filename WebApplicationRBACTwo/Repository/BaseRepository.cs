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

        public virtual int DelAlls(Expression<Func<T, bool>> predicate)
        {
            var list = db.Set<T>().Where(predicate);
            foreach (var item in list)
            { 
                db.Remove(item);
            }

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

        public int Assign(List<T> ment)
        {
            //db.Set<List<T>>().AddRange(ment);

            //return db.SaveChanges();

            foreach (var item in ment)
            {
                db.Set<T>().Add(item);
            }

            return db.SaveChanges();
        }

        public virtual IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate = null)
        {
            var query = db.Set<T>().AsQueryable();

            if (predicate != null)
            { 
                query = query.Where(predicate);
            }

            return query;
        }
    }
}


