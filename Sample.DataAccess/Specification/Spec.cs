using System;
using System.Linq;
using System.Linq.Expressions;

namespace Sample.DataAccess.Specification{
    public class Spec<TEntity> : ISpecification<TEntity>{
        public readonly Expression<Func<TEntity, bool>> Predicate;

        public Spec(Expression<Func<TEntity, bool>> predicate){
            Predicate = predicate;
        }

        public Spec<TEntity> And(Spec<TEntity> specification){
            return new Spec<TEntity>(Predicate.And(specification.Predicate));
        }

        public Spec<TEntity> And(Expression<Func<TEntity, bool>> predicate){
            return new Spec<TEntity>(Predicate.And(predicate));
        }

        public Spec<TEntity> Or(Spec<TEntity> specification){
            return new Spec<TEntity>(Predicate.Or(specification.Predicate));
        }

        public Spec<TEntity> Or(Expression<Func<TEntity, bool>> predicate){
            return new Spec<TEntity>(Predicate.Or(predicate));
        }

        public TEntity SatisfyingEntityFrom(IQueryable<TEntity> query){
            return query.Where(Predicate).SingleOrDefault();
        }

        public IQueryable<TEntity> SatisfyingEntitiesFrom(IQueryable<TEntity> query){
            return query.Where(Predicate);
        }
    }
}