// Type: SharpLite.NHibernateProvider.Repository`1
// Assembly: SharpLite.NHibernateProvider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f2f64e823dfaf078
// Assembly location: C:\dev\tools\Sharp-Lite\Example\MyStore\lib\SharpLite.NHibernateProvider.dll

using NHibernate;
using SharpLite.Domain.DataInterfaces;

namespace SharpLite.NHibernateProvider
{
    public class Repository<T> : RepositoryWithTypedId<T, int>, IRepository<T>, IRepositoryWithTypedId<T, int>
        where T : class
    {
        public Repository(ISessionFactory sessionFactory);
    }
}
