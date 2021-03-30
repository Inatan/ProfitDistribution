using ProfitDistribution.Domain.Enums;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System;
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

        public bool ValidateEmployeeValues(Employee employee)
        {
            string errorMessage = string.Empty;
            if (employee.Salario_bruto < 0)
                errorMessage += "Salário bruto deve ser maior que zero. ";
            if(employee.Data_de_admissao > DateTime.Now)
                errorMessage += "Data de admissão não pode ser maior que a data atual. ";
            var validAreas = EnumExtensions.GetEnumDescriptions<Area>().ToArray();
            if(Array.IndexOf(validAreas,employee.Area)< 0)
                errorMessage += "Área só pode ser(Diretoria, Contabilidade, Financeiro, Tecnologia, Serviços Gerais e Relacionamento com o Cliente). ";

            if (!string.IsNullOrEmpty(errorMessage))
                throw new ArgumentException(errorMessage);
            else return true;
        }

        public bool ValidateEmployeeList(IList<Employee> employees)
        {
            bool isValid = true;
            foreach (var employee in employees)
            {
                isValid &= ValidateEmployeeValues(employee);
            }
            return isValid;
        }

        public async Task<bool> InsertListAsync(IList<Employee> employees)
        {
            if(ValidateEmployeeList(employees))
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
            return false;
        }
        
        public async Task<bool> InsertNewAsync(Employee employee)
        {
            if (ValidateEmployeeValues(employee) && await _repo.FindAsync(employee.Matricula) == null)
            {    
                await _repo.AddAsync(employee.Matricula, employee);
                return true;
            }
            
            return false;
        }

        public async Task UpdateAsync(Employee employee)
        {
            if(ValidateEmployeeValues(employee))
            {
                await _repo.UpdateAsync(employee.Matricula, employee);
            }
        }
    }
}
