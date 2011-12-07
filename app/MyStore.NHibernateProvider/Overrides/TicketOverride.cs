using MyStore.Domain;
using NHibernate.Mapping.ByCode;

namespace MyStore.NHibernateProvider.Overrides
{
    /// <summary>
    /// Overrides the class-conventions for the Order object
    /// </summary>
    public class TicketOverride : IOverride
    {
        public void Override(ModelMapper mapper) {
            
            mapper.Class<Ticket>(map => map.Bag(x=>x.Assignations,bag=>bag.Inverse(true)));
        }
    }
}
