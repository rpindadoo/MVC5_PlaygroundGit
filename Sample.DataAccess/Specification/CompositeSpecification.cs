using System.Linq;

namespace Sample.DataAccess.Specification{
    public abstract class CompositeSpecification<TEntity> : ISpecification<TEntity>{
        protected readonly Spec<TEntity> LeftSide;
        protected readonly Spec<TEntity> RightSide;

        protected CompositeSpecification(Spec<TEntity> leftSide, Spec<TEntity> rightSide){
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        public abstract TEntity SatisfyingEntityFrom(IQueryable<TEntity> query);

        public abstract IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query);
    }
}