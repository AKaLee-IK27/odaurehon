using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Server.Interfaces;
using Server.Models.Data;

namespace Server.Repositories
{
    public class GenericRepository<T>(EFDataContext context) : IGenericRepository<T>
        where T : class
    {
        protected readonly EFDataContext dbContext = context;
        private readonly DbSet<T> dbSet = context.Set<T>();

        public T Add(T entity)
        {
            return dbSet.Add(entity).Entity;
        }

        public bool CheckContains(Expression<Func<T, bool>> filter)
        {
            return dbContext.Set<T>().Count(filter) > 0;
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public T Delete(T entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public T Delete(int id)
        {
            T? entity = dbSet.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException();
            }
            return dbSet.Remove(entity).Entity;
        }

        public void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where(where).AsEnumerable();
            foreach (T obj in objects)
                dbSet.Remove(obj);
        }

        public IEnumerable<T> GetAll(string[]? includes = null)
        {
            if (includes != null && includes.Length > 0)
            {
                var initialQuery = dbContext.Set<T>().Include(includes.First());
                foreach (string include in includes.Skip(1))
                    initialQuery = initialQuery.Include(include);
                return initialQuery.AsQueryable();
            }

            return dbContext.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> filter, string[]? includes = null)
        {
            if (includes != null && includes.Length > 0)
            {
                var initialQuery = dbContext.Set<T>().Include(includes.First());
                foreach (string include in includes.Skip(1))
                    initialQuery = initialQuery.Include(include);
                return initialQuery.Where<T>(filter).AsQueryable();
            }

            return dbContext.Set<T>().Where<T>(filter).AsQueryable();
        }

        public IEnumerable<T> GetMultiPaging(
            Expression<Func<T, bool>> filter,
            out int total,
            int index = 0,
            int size = 50, // Default page size
            string[]? includes = null
        )
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dbContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet =
                    filter != null ? query.Where<T>(filter).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet =
                    filter != null
                        ? dbContext.Set<T>().Where<T>(filter).AsQueryable()
                        : dbContext.Set<T>().AsQueryable();
            }

            _resetSet =
                skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet.AsQueryable();
        }

        public T GetSingleByCondition(
            Expression<Func<T, bool>> expression,
            string[]? includes = null
        )
        {
            throw new NotImplementedException();
        }

        public T GetSingleById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
