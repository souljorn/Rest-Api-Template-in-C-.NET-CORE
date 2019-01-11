using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

/*------------------------------------------------
                Enity Models
This is where the shape of the employee entity data 
is defined. This is the model of the data that the 
database and all layers expect to see.
------------------------------------------------*/

namespace RestTest.Models
{
    //Data Model to match the database
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
    }

    public class Employee 
    { 
        public long ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
    }
}
