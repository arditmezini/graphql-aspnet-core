using AspNetCore.GraphQL.Api.Dal.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.GraphQL.Api.Dal.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetById(int id);
        Task<IEnumerable<Employee>> GetByDepartmentId(int id);
        Task<Employee> Add(Employee employee);
        Task<Employee> Update(int id, Employee employee);
        Task Delete(int id);
    }
}