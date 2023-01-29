using Quick.Students.Infrastructure.DataAccess.Interfaces;
using Quick.Students.Infrastructure.DataAccess.MsSql;
using Quick.Students.Domain.Entities;

namespace Quick.Students.Infrastructure.DataAccess
{
public class RepositoryBuilder<TEntity, TPrimary> where TEntity : BaseEntity<TPrimary>
    {
        public static IBaseRepostitory<TEntity, TPrimary> Builder
            (IBaseRepostitory<TEntity, TPrimary> repostitory, StudentDbContext dbContext)
        {
            if (repostitory == null)
            {
                repostitory = new EfGenericRepository<TEntity, TPrimary>(dbContext);
            }
            return repostitory;
        }
    }
}