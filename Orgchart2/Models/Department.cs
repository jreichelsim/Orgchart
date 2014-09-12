using System.Collections.Generic;

namespace Orgchart2.Models
{
    public class Department
    {
        public int Id { get; set; }
        public int? ManagerId { get; set; }
        public string Name { get; set; }
        public int? ParentDepartmentId { get; set; }

        public virtual Department ParentDepartment { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Department> ChildDepartments { get; set; }
    }
}