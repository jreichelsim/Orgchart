using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.Tests.Infrastructure
{
    [TestFixture]
    internal class JobTitleTest
    {
        private JobTitle _jobTitle;
        private OrgChartDbContext _dbcontext;

        [SetUp]
        public void SetUp()
        {
            _dbcontext = new OrgChartDbContext();
            _jobTitle = new JobTitle
            {
                Description = "test",
            };

            _dbcontext.JobTitles.Add(_jobTitle);
            _dbcontext.SaveChanges();
        }

        [Test]
        public void TestConnection()
        {
            var count = _dbcontext.Database.ExecuteSqlCommand("SELECT * FROM JOB_TITLE");
            Assert.That(count, Is.EqualTo(-1));
        }

        [Test]
        public void CanCreateEntity()
        {
            Assert.That(_jobTitle.Id, Is.GreaterThan(0));
        }

        [Test]
        public void CanUpdateEntity()
        {
            _jobTitle.Description = "newDescription";
            _dbcontext.SaveChanges();

            var verifyContext = new OrgChartDbContext();
            var updated = verifyContext.JobTitles.Single(_ => _.Id == _jobTitle.Id);

            Assert.That(_jobTitle.Description, Is.EqualTo(updated.Description));
        }

        [Test, Ignore("Handled by Teardown")]
        public void CanDeleteEntity()
        {
            // handled by TearDown
        }

        [TearDown]
        public void Teardown()
        {
            _dbcontext.JobTitles.Remove(_jobTitle);
            _dbcontext.SaveChanges();
        }
    }
}
