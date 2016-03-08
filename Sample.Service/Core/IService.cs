using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sample.DataAccess.Entities.Interfaces;
using Sample.DataAccess.Specification;

namespace Sample.Service.Core{
    /// <summary>
    /// Exposes default functionality for each service implementation
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>    
    public interface IService<T>
        where T : class, IEntity{
        IQueryable<T> GetAll();
        IQueryable<T> Find(ISpecification<T> criteria);
        IQueryable<T> Find(Expression<Func<T, bool>> criteria);
        T FindSingle(ISpecification<T> criteria);
        T GetById(Guid id);
 //       void Update(T entity);
        void Add(T entity);
        void Remove(T entity);
        void Remove(ICollection<T> entities);
        void SaveChanges();
    }
}