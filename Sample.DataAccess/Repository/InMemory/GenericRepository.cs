using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sample.DataAccess.Entities.Interfaces;
using Sample.DataAccess.Specification;

namespace Sample.DataAccess.Repository.InMemory{
    /// <summary>
    /// In-memory imlementation of IRepository. Can be used for fast local development and testing.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity{
        private readonly List<T> _objectSet = new List<T>();

        public IQueryable<T> GetAll(){
            return _objectSet.AsQueryable();
        }

        public IQueryable<T> Find(ISpecification<T> criteria){
            return criteria.SatisfyingEntitiesFrom(_objectSet.AsQueryable());
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> criteria){
            return _objectSet.AsQueryable().Where(criteria);
        }

        public T FindSingle(ISpecification<T> criteria){
            return criteria.SatisfyingEntityFrom(_objectSet.AsQueryable());
        }

        public T GetById(Guid id){
            return _objectSet.Single(e => e.Id == id);
        }

        public void Add(T entity){
            _objectSet.Add(entity);
        }

        public void Remove(T entity){
            _objectSet.Remove(entity);
        }

        public void Remove(ICollection<T> entities){
            _objectSet.RemoveAll(entities.Contains);
        }

        public void SaveChanges() {}
    }
}