using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class Owner:Entity
    {
        public virtual IList<Car> Cars { get; protected set; }
        public Owner()
        {
            Cars = new List<Car>();
        }
    }
}
