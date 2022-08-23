using Cinema.Core.DataAccess.EntityFramework;
using Cinema.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.DataAccess.EntityFramework
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected  DbContext _db;
        protected DbSet<T> set;
        public BaseRepository(DbContext db)
        {
            _db = db;
            set = _db.Set<T>();
        }
        public async Task Add(T entity)
        {
            set.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task AddRange(List<T> entity)
        {
            set.AddRange(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            set.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return await set.FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression = null)
        {
            return expression == null
                ? await set.ToListAsync()
                : await set.Where(expression).ToListAsync();
        }

        public async Task Update(T entity)
        {
            set.Update(entity);
            await _db.SaveChangesAsync();
        }
    }
}
