using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Orgchart2.Models;

namespace Orgchart2.Infrastructure
{
    public class EmployeeRepository : IOrgChartRepository<Employee>
    {
        private readonly OrgChartDbContext _dbContext;

        public EmployeeRepository(OrgChartDbContext context)
        {
            _dbContext = context;
        }

        public Employee Select(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public List<Employee> SelectAll()
        {
            return _dbContext.Employees.ToList();
        }

        public void Add(Employee entity)
        {
            _dbContext.Employees.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            _dbContext.Employees.Remove(employee);
            SaveChanges();
        }

        public void Update(Employee entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}