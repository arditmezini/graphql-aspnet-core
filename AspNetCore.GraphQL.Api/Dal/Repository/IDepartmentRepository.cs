using AspNetCore.GraphQL.Api.Dal.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.GraphQL.Api.Dal.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetById(int id);
        Task<Department> Add(Department department);
        Task<Department> Update(int id, Department department);
        Task Delete(int id);
    }
}