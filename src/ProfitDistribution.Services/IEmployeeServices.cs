using ProfitDistribution.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Services
{
    public interface IEmployeeServices
    {
        Task<IDictionary<string, Employee>> GetAllEmployeesAsync();
        Task<Employee> FindByKeyAsync(string key);
        Task<bool> InsertNewAsync(Employee employee);
        Task<bool> InsertListAsync(IList<Employee> employees);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(string key);

    }
}
