using Melidya.DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Melidya.DataAccessLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DataContext db = new DataContext();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public List<T> List(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);
        }

        public void Insert(T obj)
        {
            db.Set<T>().Add(obj);
            Save();
        }

        public void Remove(T obj)
        {
            db.Set<T>().Remove(obj);
            Save();
        }

        public void Update(T obj)
        {
            Save();
        }

        int Save()
        {
            return db.SaveChanges();
        }
    }
}
