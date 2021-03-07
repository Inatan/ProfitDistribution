using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Find(string key);
        Task Add(string key, params TEntity[] obj);
        Task Change(string key,params TEntity[] obj);
        Task Remove(string key);
    }
}
