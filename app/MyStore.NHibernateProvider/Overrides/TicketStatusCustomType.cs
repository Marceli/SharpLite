using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyStore.Domain;
using NHibernate.Type;

namespace MyStore.NHibernateProvider.Overrides
{
    class TicketStatusCustomType:PersistentEnumType
    {
        public TicketStatusCustomType()
            : base(typeof(TicketStatusType)) { }
    }
}
