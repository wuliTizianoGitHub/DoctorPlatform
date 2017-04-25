using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Domain.Repositories
{
    public interface IRepository<TEntity, TPrimaryKey> where TEntity : class
    {
        int Count();
        int Count(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        void Delete(TEntity entity);
        void Delete(TPrimaryKey id);

        void Delete(Expression<Func<TEntity, bool>> predicate);

        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TPrimaryKey id);
        Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(TPrimaryKey id);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);

        TEntity Get(TPrimaryKey id);

        Task<TEntity> GetAsync(TPrimaryKey id);

        IQueryable<TEntity> GetAll();


        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

        List<TEntity> GetAllList();
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);

        Task<List<TEntity>> GetAllListAsync();

        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Insert(TEntity entity);

        TPrimaryKey InsertAndGetId(TEntity entity);

        Task<TEntity> InsertAsync(TEntity entity);

        Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);

        TEntity InsertOrUpdate(TEntity entity);

        TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);

        Task<TEntity> InsertOrUpdateAsync(TEntity entity);

        Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);

        TEntity Load(TPrimaryKey id);

        long LongCount();

        long LongCount(Expression<Func<TEntity, bool>> predicate);

        Task<long> LongCountAsync();

        Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);

        T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);

        TEntity Single(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity Update(TEntity entity);

        TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
    }
}
