using System;
using System.Linq;
using System.Linq.Expressions;

namespace StudyBuddies.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);

        // Marks an entity as modified
        void Update(T entity);

        // Marks an entity to be removed
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        // Get an entity by Guid id
        T GetById(Guid id);

        // Get an entity using delegate
        T Get(Expression<Func<T, bool>> where);

        // Gets all entities of type T
        IQueryable<T> GetAll();

        // Gets entities using delegate
        IQueryable<T> GetMany(Expression<Func<T, bool>> where);

        // Checks whether an entity is unique
        bool IsUnique(T entity);
    }
}
