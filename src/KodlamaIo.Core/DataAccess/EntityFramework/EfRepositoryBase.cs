using KodlamaIo.Core.DataAccess.Repositories;
using KodlamaIo.Core.Entites.Abstract;
using KodlamaIo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Core.DataAccess.EntityFramework
{
    public class EfRepositoryBase<T,TContext> : IRepository<T> 
        where T :  BaseEntity
        where TContext : DbContext ,new()
    {
       

        public Task add(T entity)
        {
            using(TContext context = new())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return Task.CompletedTask;
            }
        }

        public Task delete(T entity)
        {
            using (TContext context = new())
            {
                var delete = context.Entry(entity);
                delete.State = EntityState.Deleted;
                context.SaveChanges();
                return Task.CompletedTask;
            }
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            using(TContext context = new())
            {
                IQueryable<T> query = context.Set<T>();
                foreach(Expression<Func<T,Object>> include in includes)
                {
                    query = query.Include(include);
                }
                if(filter != null)
                {
                    query = query.Where(filter);
                }

                if(orderBy != null)
                {
                    query = orderBy(query);
                }

                return await query.ToListAsync();
            }
        }

        public async Task<T> GetById(Expression<Func<T, bool>> filter = null,
            params Expression<Func<T, object>>[] includes)
        {
            using (TContext ctx = new())
            {
                IQueryable<T> query = ctx.Set<T>();
                foreach(Expression<Func<T,object>> include in includes)
                {
                    query = query.Include(include);
                }
                return await query.SingleOrDefaultAsync(filter);
            }
        }

        public Task update(T entity)
        {
            using(TContext ctx = new())
            {
                var deletedEntity = ctx.Entry(entity);
                deletedEntity.State = EntityState.Modified;
                ctx.SaveChanges();
                return Task.CompletedTask;
            }
        }
    }
}
