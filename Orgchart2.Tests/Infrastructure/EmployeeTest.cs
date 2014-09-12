using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.Tests.Infrastructure
{
    [TestFixture]
    class EmployeeTest
    {
        private Employee _employee;
        private OrgChartDbContext _dbcontext;

        [SetUp]
        public void SetUp()
        {
            _dbcontext = new OrgChartDbContext();
            _employee = new Employee
            {
                FirstName = "Test",
                LastName = "Person",
                JobTitleId = null,
                IsManager = false,
                ManagerId = null,
                DepartmentId = null,
            };

            _dbcontext.Employees.Add(_employee);
            _dbcontext.SaveChanges();
        }

        [Test]
        public void CanCreateEntity()
        {
            Assert.That(_employee.Id, Is.GreaterThan(0));
        }

        [Test]
        public void CanUpdateEntity()
        {
            _employee.FirstName = "Sample";
            _dbcontext.SaveChanges();

            var verifyContext = new OrgChartDbContext();
            var updated = verifyContext.Employees.Single(_ => _.Id == _employee.Id);

            Assert.That(updated.Id, Is.EqualTo(_employee.Id));
        }
        
        [TearDown]
        public void TearDown()
        {
            _dbcontext.Employees.Remove(_employee);
            _dbcontext.SaveChanges();
        }
    }
}
