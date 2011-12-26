using System;
using System.Linq;
using System.Web.Mvc;
using MyStore.Domain;
using MyStore.Tasks;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Web.Controllers
{
    public class QuestionController : Controller
    {
        private IRepository<Question> questionRepository;
        private QuestionCudTasks questionMgmtTasks;

        public QuestionController(IRepository<Question> questionRepository,
            QuestionCudTasks questionMgmtTasks)
        {

            this.questionRepository = questionRepository;
            this.questionMgmtTasks = questionMgmtTasks;
        }

        public ActionResult Index()
        {
            return View(
                questionRepository.GetAll()
                    .OrderBy(c => c.Title)
            );
        }


        public ActionResult Details(int id)
        {
            return View(questionRepository.Get(id));
        }

        public ActionResult Create()
        {
            return View("Edit", questionMgmtTasks.CreateEditViewModel());
        }

        public ActionResult Edit(int id)
        {
            return View(questionMgmtTasks.CreateEditViewModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                if (ticket.Id == 0)
                {
                    ticket.Created = DateTime.Now;
                }
                ActionConfirmation<Ticket> confirmation = questionMgmtTasks.SaveOrUpdate(ticket);

                if (confirmation.WasSuccessful)
                {
                    TempData["message"] = confirmation.Message;
                    return RedirectToAction("Index");
                }

                ViewData["message"] = confirmation.Message;
            }

            return View(questionMgmtTasks.CreateEditViewModel(ticket));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ActionConfirmation<Ticket> confirmation = questionMgmtTasks.Delete(id);
            TempData["message"] = confirmation.Message;
            return RedirectToAction("Index");
        }
    }
}
