using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Sample.DataAccess.Context;
using Sample.DataAccess.Entities.Interfaces;
using Sample.DataAccess.Specification;

namespace Sample.DataAccess.Repository.MsSQL{
    /// <summary>
    /// MsSQL implementation of IRepository. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class, IEntity{
        private readonly IDbContext _db;
        private readonly IDbSet<T> _entities;

        public GenericRepository(IDbContext context){
            this._db = context;
            this._entities = this._db.Set<T>();
        }

        public IQueryable<T> GetAll(){
            return _entities;
        }

        public IQueryable<T> Find(ISpecification<T> criteria){
            return criteria.SatisfyingEntitiesFrom(GetAll());
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> criteria){
            return GetAll().Where(criteria);
        }

        public T FindSingle(ISpecification<T> criteria){
            return criteria.SatisfyingEntityFrom(GetAll());
        }

        public virtual T GetById(Guid id){
            return _entities.Single(p => p.Id == id);
        }

        public void Add(T entity){
            _entities.Add(entity);
        }

        public void Remove(T entity){
            _entities.Remove(entity);
        }

        public void Remove(ICollection<T> entities){
            foreach (var entity in entities)
                Remove(entity);
        }

        public void SaveChanges(){
            _db.SaveChanges();
        }
    }
}