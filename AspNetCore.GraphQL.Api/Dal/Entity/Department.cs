using System.Collections.Generic;

namespace AspNetCore.GraphQL.Api.Dal.Entity
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}