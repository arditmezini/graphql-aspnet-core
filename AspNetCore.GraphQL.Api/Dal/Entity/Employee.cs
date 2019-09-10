using System;

namespace AspNetCore.GraphQL.Api.Dal.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public DateTime HireDate { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}