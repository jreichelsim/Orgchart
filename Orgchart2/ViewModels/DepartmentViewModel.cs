using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orgchart2.Infrastructure;
using Orgchart2.Models;

namespace Orgchart2.ViewModels
{
    public class DepartmentViewModel
    {
        public Department Department;
        public SelectList Managers;
        public SelectList Departments;

        public DepartmentViewModel(Department department)
        {
            Department = department;

            var dbContext = new OrgChartDbContext();
            Managers = new SelectList(new EmployeeRepository(dbContext).SelectAll().Where(_ => _.IsManager).OrderBy(_ => _.LastName), "Id", "LastName", department.ManagerId);
            Departments = new SelectList(new DepartmentRepository(dbContext).SelectAll().OrderBy(_ => _.Name), "Id", "Name", department.ParentDepartmentId);
        }
    }
}