using AspNetCore.GraphQL.Api.Dal.Context;
using AspNetCore.GraphQL.Api.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.GraphQL.Api.Dal.Repository
{

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GraphQlContext context;
        private readonly DbSet<Employee> entity;

        public EmployeeRepository(GraphQlContext context)
        {
            this.context = context;
            entity = context.Set<Employee>();
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await entity.ToListAsync();
        }

        public async Task<Employee> GetById(int id)
        {
            return await entity.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetByDepartmentId(int id)
        {
            return await entity.Where(x => x.DepartmentId == id).ToListAsync();
        }

        public async Task<Employee> Add(Employee employee)
        {
            context.Entry(employee).State = EntityState.Added;
            await context.SaveChangesAsync();

            return employee;
        }

        public async Task<Employee> Update(int id, Employee employee)
        {
            var oldEntity = await GetById(id);

            if (oldEntity == null)
                throw new Exception("Entity not found");

            oldEntity.FirstName = employee.FirstName;
            oldEntity.LastName = employee.LastName;
            oldEntity.JobTitle = employee.JobTitle;
            oldEntity.HireDate = employee.HireDate;
            oldEntity.DepartmentId = employee.DepartmentId;

            await context.SaveChangesAsync();

            return oldEntity;
        }

        public async Task Delete(int id)
        {
            Employee employee = await GetById(id);

            if (employee == null)
                throw new Exception("Entity not found");

            entity.Remove(employee);
            await context.SaveChangesAsync();
        }
    }
}