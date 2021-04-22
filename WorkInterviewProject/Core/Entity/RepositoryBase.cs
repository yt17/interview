using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Entity
{
    public class RepositoryBase<TContext, T> : IRepository<T>
        where T : class, new()
        where TContext : DbContext, new()
    {
        public void Add(T entity)
        {
            using (var context = new TContext())
            {
                var AddedEntity = context.Entry(entity);
                AddedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (var context = new TContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                var asd = filter.ToString();
                return context.Set<T>().FirstOrDefault(filter);
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<T>().ToList()
                    : context.Set<T>().Where(filter).ToList();
            }
        }

        public void Update(T entity)
        {
            using (var context = new TContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
