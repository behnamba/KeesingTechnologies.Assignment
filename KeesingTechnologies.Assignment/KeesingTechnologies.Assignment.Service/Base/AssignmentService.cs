using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeesingTechnologies.Assignment.Data.Base;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using System.Data.Entity;
using KeesingTechnologies.Assignment.Common.DDD;

namespace KeesingTechnologies.Assignment.Service.Base
{
    public class AssignmentService<T> : IAssignmentService<T> where T : class, IAggregateRoot
    {
        private IUnitOfWork unitofWork;

        public bool IsDisposed { get; private set; }

        protected IUnitOfWork UnitOfWork
        {
            get;
            private set;
        }
        protected IDbSet<T> Entities
        {
            get;
            private set;
        }

        protected AssignmentService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            Entities = UnitOfWork.Set<T>();
        }

        #region Implementation of IPartikanService<T>
        public virtual Task<List<T>> GetAll()
        {
            return GetAll(false);
        }
        public virtual Task<List<T>> GetAll(bool withTracking)
        {
            return withTracking ? Entities.ToListAsync() : Entities.AsNoTracking().ToListAsync();
        }
        public virtual Task<List<T>> GetAllInclude(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> set = Entities;

            foreach (var includeExpression in includes)
            {
                set = set.Include(includeExpression);
            }
            return set.ToListAsync();
        }

        public virtual T Add(T entity)
        {
            return Entities.Add(entity);
        }

        public virtual void Delete(object key)
        {
            var entity = Entities.Find(key);
            if (entity != null)
                Delete(entity);
        }

        public virtual void Clear()
        {
            foreach (var item in Entities)
            {
                Entities.Remove(item);
            }
        }

        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            var q = Entities.Where(predicate);
            foreach (var entity in q)
            {
                Entities.Remove(entity);
            }
        }

        public virtual void Update(T entity)
        {
            UnitOfWork.Entry(entity).State = EntityState.Modified;
        }

        public virtual Task<List<T>> Find(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var set = Entities.Where(predicate);

            foreach (var includeExpression in includes)
            {
                set = set.Include(includeExpression);
            }

            return Task.Run(() => set.ToList());
        }
        public virtual Task<List<T>> Find(Expression<Func<T, bool>> predicate, bool withTracking)
        {
            return withTracking ? Entities.Where(predicate).ToListAsync() : Entities.AsNoTracking().Where(predicate).ToListAsync();
        }
        public virtual Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return Find(predicate, false);
        }

        public virtual List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate).ToList();
        }

        public virtual void Save()
        {
            try
            {
                UnitOfWork.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {

                    }
                }
            }
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (IsDisposed) return;
            if (disposing)
            {
                UnitOfWork.RejectChanges();

                //perform cleanup here
            }

            IsDisposed = true;
        }

        ~AssignmentService()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
