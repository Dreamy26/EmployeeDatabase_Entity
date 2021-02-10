using System;
using Microsoft.EntityFrameworkCore;
using MockAssessment6.DALModels;

namespace MockAssessment6.Services
{
    public class EmployeeDbContext : DbContext
    {
        // linking our VS to the Database
        public EmployeeDbContext(DbContextOptions options):base(options)
        {
        }
        //create properties for table
        

        public DbSet <EmployeeDAL> Employees { get; set; }

        //create DAL model Folder

    }
}
