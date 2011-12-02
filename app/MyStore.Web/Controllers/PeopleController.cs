using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyStore.Domain;
using MyStore.Tasks;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Web.Controllers
{
    public class PeopleController : Controller
    {
        public PeopleController(IRepository<Person> personRepository, 
            PersonCudTasks personMgmtTasks) {

            _personRepository = personRepository;
            _personMgmtTasks = personMgmtTasks;
        }

        public ActionResult Index() {
            return View(
                _personRepository.GetAll()
                    .OrderBy(c => c.LastName).ThenBy(c => c.FirstName)
            );
        }


        public ActionResult Details(int id) {
            return View(_personRepository.Get(id));
        }

        public ActionResult Create() {
            return View("Edit", _personMgmtTasks.CreateEditViewModel());
        }

        public ActionResult Edit(int id) {
            return View(_personMgmtTasks.CreateEditViewModel(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person) {
            if (ModelState.IsValid) {
                ActionConfirmation<Person> confirmation = _personMgmtTasks.SaveOrUpdate(person);

                if (confirmation.WasSuccessful) {
                    TempData["message"] = confirmation.Message;
                    return RedirectToAction("Index");
                }

                ViewData["message"] = confirmation.Message;
            }

            return View(_personMgmtTasks.CreateEditViewModel(person));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id) {
            ActionConfirmation<Person> confirmation = _personMgmtTasks.Delete(id);
            TempData["message"] = confirmation.Message;
            return RedirectToAction("Index");
        }

        private readonly IRepository<Person> _personRepository;
        private readonly PersonCudTasks _personMgmtTasks;
    }
    }
