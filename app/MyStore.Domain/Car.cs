using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class Car:Entity
    {
        public virtual Owner Owner { get; set; }
    }
}
