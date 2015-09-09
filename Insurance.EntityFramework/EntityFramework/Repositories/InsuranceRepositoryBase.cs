using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Insurance.EntityFramework.Repositories
{
    public abstract class InsuranceRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<InsuranceDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected InsuranceRepositoryBase(IDbContextProvider<InsuranceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class InsuranceRepositoryBase<TEntity> : InsuranceRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected InsuranceRepositoryBase(IDbContextProvider<InsuranceDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
