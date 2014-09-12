using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Orgchart2.Models;

namespace Orgchart2.Infrastructure
{
    public class JobTitleRepository : IOrgChartRepository<JobTitle>
    {
        private readonly OrgChartDbContext _dbContext;

        public JobTitleRepository(OrgChartDbContext context)
        {
            _dbContext = context;
        }

        public JobTitle Select(int id)
        {
            return _dbContext.JobTitles.Find(id);
        }

        public List<JobTitle> SelectAll()
        {
            return _dbContext.JobTitles.ToList();
        }

        public void Add(JobTitle entity)
        {
            _dbContext.JobTitles.Add(entity);
            SaveChanges();
        }

        public void Delete(int id)
        {
            var title = _dbContext.JobTitles.Find(id);
            _dbContext.JobTitles.Remove(title);
            SaveChanges();
        }

        public void Update(JobTitle entity)
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