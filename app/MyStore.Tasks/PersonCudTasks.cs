using MyStore.Domain;
using MyStore.Tasks.ViewModels;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Tasks
{
    public class PersonCudTasks : BaseEntityCudTasks<Person, EditPersonViewModel>
    {
        public PersonCudTasks(IRepository<Person> personRepository) 
            : base(personRepository) { }

        protected override void TransferFormValuesTo(Person toUpdate, Person fromForm) {
            toUpdate.FirstName = fromForm.FirstName;
            toUpdate.LastName = fromForm.LastName;
        }
    }
}
