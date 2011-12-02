// Type: SharpLite.NHibernateProvider.RepositoryWithTypedId`2
// Assembly: SharpLite.NHibernateProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f2f64e823dfaf078
// Assembly location: C:\dev\tools\Sharp-Lite\Example\MyStore\lib\SharpLite.NHibernateProvider.dll

using NHibernate;
using SharpLite.Domain.DataInterfaces;
using System.Linq;

namespace SharpLite.NHibernateProvider
{
    public class RepositoryWithTypedId<T, TId> : IRepositoryWithTypedId<T, TId> where T : class
    {
        public RepositoryWithTypedId(ISessionFactory sessionFactory);
        protected virtual ISession Session { get; }

        #region IRepositoryWithTypedId<T,TId> Members

        public virtual T Get(TId id);
        public virtual IQueryable<T> GetAll();
        public virtual T SaveOrUpdate(T entity);
        public virtual void Delete(T entity);
        public virtual IDbContext DbContext { get; }

        #endregion
    }
}
