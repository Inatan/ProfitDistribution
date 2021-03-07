using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Services.Handlers
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IRepository<Employee> _repo;
        public EmployeeServices(IRepository<Employee> repo)
        {
            _repo = repo;
        }

        public async Task DeleteAsync(string key)
        {
            await _repo.RemoveAsync(key);
        }

        public async Task<Employee> FindByKeyAsync(string key)
        {
            return await _repo.FindAsync(key);
        }

        public async Task<IDictionary<string, Employee>> GetAllEmployeesAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task InsertListAsync(IList<Employee> employees)
        {
            foreach (var employee in employees)
            {
                await _repo.AddAsync(employee.Matricula, employee);
            }
        }
        
        public async Task InsertNewAsync(Employee employee)
        {
            await _repo.AddAsync(employee.Matricula, employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _repo.UpdateAsync(employee.Matricula, employee);
        }
    }
}
