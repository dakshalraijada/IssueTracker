using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IssueTracker.Core.Data
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        Task DeleteAsync(int id);
    }
}
