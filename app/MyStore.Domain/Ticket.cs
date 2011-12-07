using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class Ticket : Entity
    {
        public Ticket() {
             Assignations= new List<TicetPersonAssignation>();
        }

        public virtual DateTime Created { get; set; }
        [StringLength(100,ErrorMessage="Title is too long.")]
        public virtual String Title { get; set; }
        [StringLength(500,ErrorMessage="Description is too long.")]
        public virtual String Description { get; set; }

        public virtual IList<TicetPersonAssignation> Assignations { get; protected set; }


        /// <summary>
        /// Maps to an enum type and is not an entity relationship
        /// </summary>
        public virtual TicketStatusType TicketStatus { get; set; }


    }
}
