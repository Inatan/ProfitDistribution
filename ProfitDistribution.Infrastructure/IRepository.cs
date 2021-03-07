using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> FindAsync(string key);
        Task AddAsync(string key, params TEntity[] obj);
        Task UpdateAsync(string key,params TEntity[] obj);
        Task RemoveAsync(string key);
    }
}
