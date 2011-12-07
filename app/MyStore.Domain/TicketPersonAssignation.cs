using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class TicetPersonAssignation:Entity
    {
        public virtual Person Assigned{get; set; }
        public virtual Ticket Ticket { get; set; }
        public virtual DateTime AssignationStart { get; set; }
        public virtual DateTime? AssignationEnd { get; set; }
    }
}
