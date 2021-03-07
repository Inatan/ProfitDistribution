using ProfitDistribution.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProfitDistribution.Services
{
    public interface IEmployeeServices
    {
        Task<IDictionary<string, Employee>> GetAllEmployeesAsync();
        Task<Employee> FindByKeyAsync(string key);
        Task InsertNewAsync(Employee employee);
        Task InsertListAsync(IList<Employee> employees);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(string key);

    }
}
