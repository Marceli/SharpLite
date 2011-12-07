using System;
using System.Linq;
using System.Web.Mvc;
using MyStore.Domain;
using MyStore.Tasks;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Web.Controllers
{
    public class TicketsController : Controller
    {
        private IRepository<Ticket> ticketRepository;
        private TicketCudTasks ticketMgmtTasks;

        public TicketsController(IRepository<Ticket> ticketRepository,
            TicketCudTasks ticketMgmtTasks)
        {

            this.ticketRepository = ticketRepository;
            this.ticketMgmtTasks = ticketMgmtTasks;
        }

        public ActionResult Index()
        {
            return View(
                ticketRepository.GetAll()
                    .OrderBy(c => c.Title).ThenBy(c => c.TicketStatus)
            );
        }


        public ActionResult Details(int id)
        {
            return View(ticketRepository.Get(id));
        }

        public ActionResult Create()
        {
            return View("Edit", ticketMgmtTasks.CreateEditViewModel());
        }

        public ActionResult Edit(int id)
        {
            return View(ticketMgmtTasks.CreateEditViewModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                if(ticket.Id==0)
                {
                    ticket.Created = DateTime.Now;
                }
                ActionConfirmation<Ticket> confirmation = ticketMgmtTasks.SaveOrUpdate(ticket);

                if (confirmation.WasSuccessful)
                {
                    TempData["message"] = confirmation.Message;
                    return RedirectToAction("Index");
                }

                ViewData["message"] = confirmation.Message;
            }

            return View(ticketMgmtTasks.CreateEditViewModel(ticket));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ActionConfirmation<Ticket> confirmation = ticketMgmtTasks.Delete(id);
            TempData["message"] = confirmation.Message;
            return RedirectToAction("Index");
        }
    }
}
