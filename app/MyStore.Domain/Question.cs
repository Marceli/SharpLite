using System;
using System.Collections.Generic;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class Question : Entity
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual IList<Answer> Answers { get; protected set; }
    }
}