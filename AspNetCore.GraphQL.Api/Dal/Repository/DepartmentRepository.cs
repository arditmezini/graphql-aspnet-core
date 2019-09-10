using AspNetCore.GraphQL.Api.Dal.Context;
using AspNetCore.GraphQL.Api.Dal.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspNetCore.GraphQL.Api.Dal.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly GraphQlContext context;
        private readonly DbSet<Department> entity;

        public DepartmentRepository(GraphQlContext context)
        {
            this.context = context;
            entity = context.Set<Department>();
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await entity.ToListAsync();
        }

        public async Task<Department> GetById(int id)
        {
            return await entity.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Department> Add(Department department)
        {
            context.Entry(department).State = EntityState.Added;
            await context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> Update(int id, Department department)
        {
            var oldEntity = await GetById(id);

            if (oldEntity == null)
                throw new Exception("Entity not found");

            oldEntity.Number = department.Number;
            oldEntity.Location = department.Location;

            await context.SaveChangesAsync();

            return oldEntity;
        }

        public async Task Delete(int id)
        {
            Department department = await GetById(id);

            if (department == null)
                throw new Exception("Entity not found");

            entity.Remove(department);
            await context.SaveChangesAsync();
        }
    }
}