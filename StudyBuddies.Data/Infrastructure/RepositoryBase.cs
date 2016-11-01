using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudyBuddies.Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly UnitOfWork _unitOfWork;

        protected ISession Session {
            get { return _unitOfWork.Session; }
        }

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public virtual void Add(T entity)
        {
            Session.Save(entity);
        }

        public virtual void Update(T entity)
        {
            Session.Update(entity);
        }

        public virtual void Delete(T entity)
        {
           Session.Delete(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = Session.Query<T>().Where(where);

            foreach (T obj in objects)
                Session.Delete(obj);
        }

        public virtual T GetById(Guid id)
        {
            return Session.Get<T>(id);
        }

        public virtual T Get(Expression<Func<T, bool>> where)
        {
            return Session.Query<T>().Where(where).FirstOrDefault<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
           return Session.Query<T>().ToList<T>();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
           return Session.Query<T>().Where(where).ToList<T>();
        }
    }
}
