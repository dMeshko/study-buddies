using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace StudyBuddies.Service.Infrastructure
{
    public interface IService<T> where T : class
    {
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(Guid id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
