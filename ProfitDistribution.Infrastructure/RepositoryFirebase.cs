using FireSharp.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure
{
    public class RepositoryFirebase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DistributionProfitContext _context;

        public RepositoryFirebase(DistributionProfitContext context)
        {
            _context = context;
        }


        public async Task<IDictionary<string, TEntity>> GetAllAsync()
        {
            IDictionary<string, TEntity> employees = null;
            string path = $"{typeof(TEntity).Name}";
            try
            {
                FirebaseResponse response = await _context.GetClient().GetAsync(path);
                employees = response.ResultAs<IDictionary<string, TEntity>>();
            }
            catch (System.Exception)
            {
                FirebaseResponse response = await _context.GetClient().GetAsync(path);
                employees = response.ResultAs<IDictionary<string, TEntity>>();
            }
            return employees;
        }

        public async Task AddAsync(string key, TEntity obj)
        {
            string path = $"{obj.GetType().Name}\\{key}";
            SetResponse response = null;
            try
            {
                response = await _context.GetClient().SetAsync(path, obj);
            }
            catch (System.Exception)
            {
                response = await _context.GetClient().SetAsync(path, obj);
            }
        }

        public async Task UpdateAsync(string key, TEntity obj)
        {
            SetResponse response = null;
            string path = $"{obj.GetType().Name}\\{key}";
            try
            {
                response = await _context.GetClient().SetAsync(path, obj);
            }
            catch (System.Exception)
            {
                response = await _context.GetClient().SetAsync(path, obj);
            }
        }

        public async Task<TEntity> FindAsync(string key)
        {
            FirebaseResponse response = null;
            TEntity entity = null;
            string path = $"{typeof(TEntity).Name}\\{key}";
            try
            {
                response = await _context.GetClient().GetAsync(path);
                entity = response.ResultAs<TEntity>();
            }
            catch (System.Exception)
            {
                response = await _context.GetClient().GetAsync(path);
                entity = response.ResultAs<TEntity>();
            }
            return entity;
        }

        public async Task RemoveAsync(string key)
        {
            FirebaseResponse response = null;
            string path = $"{typeof(TEntity).Name}\\{key}";
            try
            {
                response = await _context.GetClient().DeleteAsync(path);
            }
            catch (System.Exception)
            {
                response = await _context.GetClient().DeleteAsync(path);
            }
        }
    }
}
