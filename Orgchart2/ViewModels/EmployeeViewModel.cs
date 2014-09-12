using System.Linq;
using System.Web.Mvc;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public SelectList JobTitles { get; set; }
        public SelectList Departments { get; set; }
        public SelectList Managers { get; set; }

        public EmployeeViewModel(Employee employee)
        {
            Employee = employee;

            var dbContext = new OrgChartDbContext();
            JobTitles = new SelectList(new JobTitleRepository(dbContext).SelectAll().OrderBy(_ => _.Description), "Id", "Description", employee.JobTitleId);
            Departments = new SelectList(new DepartmentRepository(dbContext).SelectAll(), "Id", "Name", employee.DepartmentId);
            Managers = new SelectList(new EmployeeRepository(dbContext).SelectAll().Where(_ => _.IsManager).OrderBy(_ => _.LastName), "Id", "LastName", employee.ManagerId);
        }
    }
}