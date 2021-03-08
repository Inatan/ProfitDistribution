using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> InsertListAsync(IList<Employee> employees)
        {
            var allValues = (await _repo.GetAllAsync()).Select(v => v.Value.Matricula);
            if (employees.Where(e => allValues.Contains(e.Matricula)).Any())
            {
                return false;
            }
            foreach (var employee in employees)
            {
                await _repo.AddAsync(employee.Matricula, employee);
            }
            return true;
        }
        
        public async Task<bool> InsertNewAsync(Employee employee)
        {
            if(await _repo.FindAsync(employee.Matricula) == null)
            {
                await _repo.AddAsync(employee.Matricula, employee);
                return true;
            }
            return false;
        }

        public async Task UpdateAsync(Employee employee)
        {
            await _repo.UpdateAsync(employee.Matricula, employee);
        }
    }
}
