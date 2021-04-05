using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IDictionary<string, TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(string key);
        Task<bool> AnyAsync(string key);
        Task AddAsync(string key, TEntity obj);
        Task UpdateAsync(string key,TEntity obj);
        Task RemoveAsync(string key);
    }
}
