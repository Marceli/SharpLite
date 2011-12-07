using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyStore.Domain;
using MyStore.NHibernateProvider;
using NHibernate;
using NHibernate.Cfg;
using NUnit.Framework;

namespace MyStore.Tests.NHibernateProvider
{
    [TestFixture]
    public class AssignationTest
    {
        private Configuration _configuration;
        private ISessionFactory _sessionFactory;

        [SetUp]
            public virtual void SetUp() {
                _configuration = NHibernateInitializer.Initialize();
                _sessionFactory = _configuration.BuildSessionFactory();
            }
        [Test]
        public void CanSaveAssignationWithPersonAndTicket()
        {
            var person = new Person();
            person.BirthDate=new DateTime(2000,1,1);
            person.FirstName = "John";
            person.LastName = "Smith";
            var session = _sessionFactory.OpenSession();

            var ticket = new Ticket();
            ticket.Created=DateTime.Now;
            ticket.Description = "First ticket";
            ticket.Title = "Title";
            ticket.TicketStatus = TicketStatusType.New;
            var assignation = new TicetPersonAssignation() {AssignationStart = DateTime.Now, Assigned = person};
            assignation.Ticket = ticket;

            using (var t=session.BeginTransaction())
            {
                //session.SaveOrUpdate(person);
                //session.SaveOrUpdate(ticket);
                session.SaveOrUpdate(assignation);
                t.Commit();
            }
        }
    }
}
