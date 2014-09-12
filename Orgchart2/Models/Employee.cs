using System.Collections.Generic;

namespace Orgchart2.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SkypeName { get; set; }
        public int? JobTitleId { get; set; }
        public bool IsManager { get; set; }
        public int? ManagerId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual JobTitle JobTitle { get; set; }

        public virtual ICollection<Employee> ManagedEmployees { get; set; }
        public virtual ICollection<Department> ManagedDepartments { get; set; }
    }
}