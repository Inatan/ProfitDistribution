using FireSharp.Response;
using ProfitDistribution.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure
{
    class RepositoryFirebase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DistributionProfitContext _context;

        public RepositoryFirebase(DistributionProfitContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            FirebaseResponse response = await _context.GetClient().GetAsync($"{typeof(TEntity).Name}");
            IEnumerable<TEntity> employees = response.ResultAs<IEnumerable<TEntity>>();
            return employees;
        }

        public async Task Add(string key, params TEntity[] obj)
        {
            SetResponse response = await _context.GetClient().SetAsync($"{obj.GetType().Name}\\{key}", obj);
            TEntity result = response.ResultAs<TEntity>();
        }

        public async Task Change(string key,params TEntity[] obj)
        {
            Employee employee = obj as Employee;
            SetResponse response = await _context.GetClient().SetAsync($"{obj.GetType().Name}\\{key}", obj);
            Employee result = response.ResultAs<Employee>();
        }

        public async Task<TEntity> Find(string key)
        {
            FirebaseResponse response = await _context.GetClient().GetAsync($"{typeof(TEntity).Name}\\{key}");
            TEntity entity = response.ResultAs<TEntity>();
            return entity;
        }

        public async Task Remove(string key)
        {
            FirebaseResponse response = await _context.GetClient().DeleteAsync($"{typeof(TEntity).Name}\\{key}");
            Employee employee = response.ResultAs<Employee>();
        }
    }
}
