﻿using System;
using System.Configuration;
using System.IO;
using MyStore.NHibernateProvider;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using Configuration = NHibernate.Cfg.Configuration;

namespace MyStore.Tests.NHibernateProvider
{
    /// <summary>
    /// Provides a means to verify that the target database is in compliance with all mappings.
    /// Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    /// If this is failing, the error will likely inform you that there is a missing table or column
    /// which needs to be added to your database.
    /// </summary>
    [TestFixture]
    [Category("DB Tests")]
    public class MappingIntegrationTests
    {
        [SetUp]
        public virtual void SetUp() {
            var dataDirectory = ConfigurationManager.AppSettings["DataDirectory"];
            var absoluteDataDirectory = Path.GetFullPath(dataDirectory);
            AppDomain.CurrentDomain.SetData("DataDirectory", absoluteDataDirectory); 
            _configuration = NHibernateInitializer.Initialize();
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [Test]
        public void CanCofirmanDrabaseatMcheMappsings() {
            var allClassMetadata = _sessionFactory.GetAllClassMetadata();

            foreach (var entry in allClassMetadata) {
                _sessionFactory.OpenSession().CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                    .SetMaxResults(0).List();
            }
        }

        /// <summary>
        /// Generates and outputs the database schema SQL to the console
        /// </summary>
        [Test]
        public void CanGenerateDatabaseSchema()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (
                    TextWriter stringWriter =
                        new StreamWriter("../../../../app/MyStore.DB/Schema/UnitTestGeneratedSchema.sql"))
                {
                    new SchemaExport(_configuration).Execute(true, true, false, session.Connection, stringWriter);
                }
            }
        }

        private Configuration _configuration;
        private ISessionFactory _sessionFactory;
    }
}
