using NHibernate.Mapping.ByCode;

namespace SharpLiteTest.NHibernateProvider.Overrides
{
    internal interface IOverride
    {
        void Override(ModelMapper mapper);
    }
}
