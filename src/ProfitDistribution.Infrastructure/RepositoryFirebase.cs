using FireSharp.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ProfitDistribution.Infrastructure
{
    public class RepositoryFirebase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ProfitDistributionContext _context;

        public RepositoryFirebase(ProfitDistributionContext context)
        {
            _context = context;
        }

        public async Task<IDictionary<string, TEntity>> GetAllAsync()
        {
            IDictionary<string, TEntity> employees = null;
            string path = $"{typeof(TEntity).Name}";
            FirebaseResponse response = await _context.GetClient().GetAsync(path);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(2000);
                response = await _context.GetClient().GetAsync(path);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new KeyNotFoundException("Falha ao recuperar dados da base");
            }
            employees = response.ResultAs<IDictionary<string, TEntity>>();
            return employees;
        }

        public async Task AddAsync(string key, TEntity obj)
        {
            string path = $"{obj.GetType().Name}\\{key}";
            SetResponse response = null;
            
            response = await _context.GetClient().SetAsync(path, obj);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(2000);
                response = await _context.GetClient().SetAsync(path, obj);
                if(response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new KeyNotFoundException("Falha ao realizar ao adicionar na base");
            }
        }

        public async Task UpdateAsync(string key, TEntity obj)
        {
            SetResponse response = null;
            string path = $"{obj.GetType().Name}\\{key}";
            response = await _context.GetClient().SetAsync(path, obj);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(2000);
                response = await _context.GetClient().SetAsync(path, obj);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new KeyNotFoundException("Falha ao realizar ao atualizar dados na base");
            }
        }

        public async Task<TEntity> FindAsync(string key)
        {
            FirebaseResponse response = null;
            TEntity entity = null;
            string path = $"{typeof(TEntity).Name}\\{key}";
            
            response = await _context.GetClient().GetAsync(path);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                Thread.Sleep(2000);
                response = await _context.GetClient().GetAsync(path);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new KeyNotFoundException("Falha ao recuperar dados da base");
            }
            entity = response.ResultAs<TEntity>();
            return entity;
        }

        public async Task RemoveAsync(string key)
        {
            FirebaseResponse response = null;
            string path = $"{typeof(TEntity).Name}\\{key}";
            response = await _context.GetClient().DeleteAsync(path);
            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                Thread.Sleep(2000);
                response = await _context.GetClient().DeleteAsync(path);
                if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    throw new KeyNotFoundException("Não foi possivel deletar o dado da base");
            }
        }
    }
}
