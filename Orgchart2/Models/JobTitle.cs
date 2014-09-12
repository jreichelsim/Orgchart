using System.Collections.Generic;

namespace Orgchart2.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}