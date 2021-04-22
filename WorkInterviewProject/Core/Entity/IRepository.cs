using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Entity
{
    public interface IRepository<T> where T:class ,new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(Expression<Func<T,bool>> filter);
        List<T> GetList(Expression<Func<T,bool>> filter);


    }
}
