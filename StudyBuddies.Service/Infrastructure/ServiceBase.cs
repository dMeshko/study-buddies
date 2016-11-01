using StudyBuddies.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudyBuddies.Service.Infrastructure
{
    public abstract class ServiceBase<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Save(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            _repository.Delete(where);
        }

        public virtual T GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return _repository.Get(where);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _repository.GetMany(where);
        }
    }
}
