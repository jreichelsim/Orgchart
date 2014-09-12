using System.Collections.Generic;

namespace Orgchart2.Infrastructure
{
    public interface IOrgChartRepository<T> where T : class
    {
        T Select(int id);
        List<T> SelectAll();
        void Add(T entity);
        void Delete(int id);
        void Update(T entity);
        int SaveChanges();
    }
}