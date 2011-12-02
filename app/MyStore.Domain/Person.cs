using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class Person : Entity
    {
        virtual public string FirstName { get; set; }
        virtual public string LastName { get; set; }
        virtual public DateTime BirthDate { get; set; }

    }
}
