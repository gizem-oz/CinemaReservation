using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.DataAccess
{
    public interface IRepository<T> where T:class,IEntity,new()
    {
        Task<T> Get(Expression<Func<T, bool>> expression);
        Task<IList<T>> GetAll(Expression<Func<T,bool>> expression = null);
        Task Add(T entity);
        Task AddRange(List<T> entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
