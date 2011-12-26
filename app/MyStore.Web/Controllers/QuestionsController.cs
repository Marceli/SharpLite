using System;
using System.Linq;
using System.Web.Mvc;
using MyStore.Domain;
using MyStore.Tasks;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private IRepository<Question> questionRepository;
        private QuestionCudTasks questionMgmtTasks;

        public QuestionsController(IRepository<Question> questionRepository,
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
        public ActionResult Edit(Question question)
        {
            if (ModelState.IsValid)
            {
                if (question.Id == 0)
                {
                    question.DateCreated = DateTime.Now;
                }
                ActionConfirmation<Question> confirmation = questionMgmtTasks.SaveOrUpdate(question);

                if (confirmation.WasSuccessful)
                {
                    TempData["message"] = confirmation.Message;
                    return RedirectToAction("Index");
                }

                ViewData["message"] = confirmation.Message;
            }

            return View(questionMgmtTasks.CreateEditViewModel(question));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ActionConfirmation<Question> confirmation = questionMgmtTasks.Delete(id);
            TempData["message"] = confirmation.Message;
            return RedirectToAction("Index");
        }
    }
}
