using System.Linq;

namespace Sample.DataAccess.Specification{
    
    public class AndSpecification<TEntity> : CompositeSpecification<TEntity>{
        public AndSpecification(Spec<TEntity> leftSide, Spec<TEntity> rightSide)
            : base(leftSide, rightSide) {}

        public override TEntity SatisfyingEntityFrom(IQueryable<TEntity> query){
            return SatisfyingEntitiesFrom(query).FirstOrDefault();
        }

        public override IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query){
            return query.Where(LeftSide.Predicate.And(RightSide.Predicate));
        }
    }
}