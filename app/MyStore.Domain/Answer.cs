using System;
using SharpLite.Domain;

namespace MyStore.Domain
{
    public class Answer : Entity
    {
        public virtual Question Question { get; set; }
        public virtual string Text { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime DateUpdated { get; set; }
        public virtual Person Author { get; set; }
    }
}