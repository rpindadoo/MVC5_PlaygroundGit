using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sample.DataAccess.Entities.Interfaces;
using Sample.DataAccess.Repository;
using Sample.DataAccess.Specification;

namespace Sample.Service.Core{
    /// <summary>
    /// Default service implementation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseService<T> : IService<T> where T : class, IEntity{
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository){
            _repository = repository;
        }

        /// <summary>
        /// Returns all records
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> GetAll(){
            return _repository.GetAll();
        }

        /// <summary>
        /// This method will return all the records which are satisfied by the specified criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IQueryable<T> Find(ISpecification<T> criteria){
            return _repository.Find(criteria);
        }

        /// <summary>
        /// This method will return all the records which are satisfied by the specified criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public IQueryable<T> Find(Expression<Func<T, bool>> criteria){
            return _repository.Find(criteria);
        }

        /// <summary>
        /// This method will return all the records which are satisfied by the specified criteria
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        public T FindSingle(ISpecification<T> criteria){
            return _repository.FindSingle(criteria);
        }

        /// <summary>
        /// Search a single entity by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(Guid id){
            return _repository.GetById(id);
        }

        ///// <summary>
        ///// This method will mark the specified entity as 'ToBeUpdated'. A Call to
        ///// SaveChanges() is needed to actually perform this action on the underlying
        ///// datasource. This is not the case when using an InMemory data source. In case
        ///// EntityFramework is used, we'll only Attach the specified entity to the context
        ///// so that it's properties can be updated, and saved with a call to SaveChanges().
        ///// </summary>
        ///// <param name="entity"></param>
        //public virtual void Update(T entity){
        //    _repository.Update(entity);
        //}

        /// <summary>
        /// This method will mark the specified entity as 'ToBeAdded'. A Call to
        /// SaveChanges() is needed to actually perform this action on the underlying
        /// datasource. This is not the case when using an InMemory data source.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Add(T entity){
            _repository.Add(entity);
        }

        /// <summary>
        /// This method will mark the specified entity as 'ToBeDeleted'. A Call to
        /// SaveChanges() is needed to actually perform this action on the underlying
        /// datasource. This is not the case when using an InMemory data source.
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Remove(T entity){
            _repository.Remove(entity);
        }

        /// <summary>
        /// This method will mark all specified enties as 'ToBeDeleted'. A Call to
        /// SaveChanges() is needed to actually perform this action on the underlying
        /// datasource. This is not the case when using an InMemory data source.
        /// </summary>
        /// <param name="entities"></param>
        public virtual void Remove(ICollection<T> entities){
            _repository.Remove(entities);
        }

        /// <summary>
        /// Saves all the changes made to the current context. Be aware of the fact that 
        /// the underlying context can also be injected into other services. So calling
        /// SaveChanges() will save ALL changes made to the current context.
        /// </summary>
        public virtual void SaveChanges(){
            _repository.SaveChanges();
        }
    }
}