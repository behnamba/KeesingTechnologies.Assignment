using KeesingTechnologies.Assignment.Common.DDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KeesingTechnologies.Assignment.Service.Base
{
    public interface IAssignmentService<T> : IDisposable where T : class, IAggregateRoot
    {
        Task<List<T>> GetAll(bool withTracking);
        Task<List<T>> GetAll();
        Task<List<T>> GetAllInclude(params System.Linq.Expressions.Expression<Func<T, object>>[] includes);

        T Add(T entity);
        void Delete(object key);
        void Delete(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        void Clear();
        void Update(T entity);
        Task<List<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, bool withTracking);
        Task<List<T>> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        Task<List<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        List<T> Get(Expression<Func<T, bool>> predicate);
        void Save();
    }
}
