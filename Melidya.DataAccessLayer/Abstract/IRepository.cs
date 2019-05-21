using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Melidya.DataAccessLayer.Abstract
{
    interface IRepository<T>
    {
        List<T> List();

        List<T> List(Expression<Func<T, bool>> expression);

        T Find(Expression<Func<T, bool>> expression);

        void Insert(T obj);

        void Remove(T obj);

        void Update(T obj);
        
    }
}
