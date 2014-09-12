using System.Linq;
using NUnit.Framework;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.Tests.Infrastructure
{
    [TestFixture]
    public class DepartmentTest
    {
        private OrgChartDbContext _dbcontext;
        private Department _department;

        [SetUp]
        public void SetUp()
        {
            _dbcontext = new OrgChartDbContext();
            _department = new Department
            {
                Name = "Test Department",
                ParentDepartmentId = null,
            };

            _dbcontext.Departments.Add(_department);
            _dbcontext.SaveChanges();
        }

        [Test]
        public void CanCreateEntity()
        {
            Assert.That(_department.Id, Is.GreaterThan(0));
        }

        [Test]
        public void CanUpdateEntity()
        {
            _department.Name = "Sample Department";
            _dbcontext.SaveChanges();

            var verifyContext = new OrgChartDbContext();
            var updated = verifyContext.Departments.Single(_ => _.Id == _department.Id);

            Assert.That(_department.Name, Is.EqualTo(updated.Name));
        }

        [TearDown]
        public void TearDown()
        {
            _dbcontext.Departments.Remove(_department);
            _dbcontext.SaveChanges();
        }
    }
}