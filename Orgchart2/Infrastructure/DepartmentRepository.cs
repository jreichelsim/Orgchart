using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Orgchart2.Models;

namespace Orgchart2.Infrastructure
{
    public class DepartmentRepository : IOrgChartRepository<Department>
    {
        private readonly OrgChartDbContext _dbContext;

        public DepartmentRepository(OrgChartDbContext context)
        {
            _dbContext = context;
        }

        public Department Select(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public List<Department> SelectAll()
        {
            return _dbContext.Departments.ToList();
        }

        public void Add(Department entity)
        {
            _dbContext.Departments.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);
            _dbContext.Departments.Remove(department);
            SaveChanges();
        }

        public void Update(Department entity)
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