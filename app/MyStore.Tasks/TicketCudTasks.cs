using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyStore.Domain;
using MyStore.Tasks.ViewModels;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Tasks
{
    public class TicketCudTasks:BaseEntityCudTasks<Ticket,EditTicketViewModel>
    {
        public TicketCudTasks(IRepository<Ticket> ticketRepository) 
            : base(ticketRepository) { }

        protected override void TransferFormValuesTo(Ticket toUpdate, Ticket fromForm) {
            toUpdate.Title = fromForm.Title;
            toUpdate.Description = fromForm.Description;
            toUpdate.TicketStatus = fromForm.TicketStatus;
        }
    }
}
