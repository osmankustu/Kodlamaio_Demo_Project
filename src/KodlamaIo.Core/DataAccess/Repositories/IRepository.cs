using KodlamaIo.Core.Entites.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Core.DataAccess.Repositories
{
    public interface IRepository<T> where T : IEntity 
    {
        public Task add(T entity);

        public Task update(T entity);

        public Task delete(T entity);

        public Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
            params Expression<Func<T, object>>[] includes);

        public Task<T> GetById(Expression<Func<T, bool>> filter = null , params Expression<Func<T, object>>[] includes);
    }
}
