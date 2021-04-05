using ProfitDistribution.Domain.Enums;
using ProfitDistribution.Domain.Model;
using ProfitDistribution.Infrastructure;
using System;
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

        public bool ValidateEmployeeValues(Employee employee)
        {
            string errorMessage = string.Empty;
            if (employee.GrossSalary < 0)
                errorMessage += "Salário bruto deve ser maior que zero. ";
            if(employee.AdmissionDate > DateTime.Now)
                errorMessage += "Data de admissão não pode ser maior que a data atual. ";
            var validAreas = EnumExtensions.GetEnumDescriptions<Area>().ToArray();
            if(Array.IndexOf(validAreas,employee.OccupationArea)< 0)
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
                bool isValid = true;
                foreach (var employee in employees)
                {
                    isValid &= !await _repo.AnyAsync(employee.RegistrationId);
                    if (!isValid)
                        return isValid;
                }
                foreach (var employee in employees)
                {
                    await _repo.AddAsync(employee.RegistrationId, employee);
                }
                return true;
            }
            return false;
        }
        
        public async Task<bool> InsertNewAsync(Employee employee)
        {
            if (ValidateEmployeeValues(employee) && !await _repo.AnyAsync(employee.RegistrationId))
            {    
                await _repo.AddAsync(employee.RegistrationId, employee);
                return true;
            }
            
            return false;
        }

        public async Task UpdateAsync(Employee employee)
        {
            if(ValidateEmployeeValues(employee))
            {
                await _repo.UpdateAsync(employee.RegistrationId, employee);
            }
        }
    }
}
