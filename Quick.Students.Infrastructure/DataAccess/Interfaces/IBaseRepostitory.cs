using System.Linq.Expressions;
using Quick.Students.Domain.Entities;

namespace Quick.Students.Infrastructure.DataAccess.Interfaces
{
public interface IBaseRepostitory<TEntity, in TPrimary> : IDisposable
        where TEntity : BaseEntity<TPrimary>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<List<TEntity>> GetAllList();
        Task<List<TEntity>> GetAllListIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        ValueTask<TEntity?> Find(TPrimary id);
        Task<TEntity?> GetFirst(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindByInculding(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Alll(Expression<Func<TEntity, bool>> predicate);
        Task<int> Count();
        Task<int> Count(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(TEntity entity);
        Task DeleteWhere(Expression<Func<TEntity, bool>> predicate);
    }
}