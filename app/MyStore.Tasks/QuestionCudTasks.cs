using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyStore.Domain;
using MyStore.Tasks.ViewModels;
using SharpLite.Domain.DataInterfaces;

namespace MyStore.Tasks
{
    public class QuestionCudTasks : BaseEntityCudTasks<Question, EditQuestionViewModel>
    {
        public QuestionCudTasks(IRepository<Question> questionRepository)
            : base(questionRepository) { }

        protected override void TransferFormValuesTo(Question toUpdate, Question fromForm)
        {
            toUpdate.Title = fromForm.Title;
            toUpdate.Content = fromForm.Content;
            toUpdate.DateCreated = DateTime.Now;
          //  toUpdate.Answers = fromForm.Answers;
        }
    }
}
