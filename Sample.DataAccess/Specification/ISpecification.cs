using System.Linq;

namespace Sample.DataAccess.Specification{
    public interface ISpecification<TEntity>{
        TEntity SatisfyingEntityFrom(IQueryable<TEntity> query);
        IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query);
    }
}