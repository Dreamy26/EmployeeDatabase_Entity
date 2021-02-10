using System;
using Microsoft.EntityFrameworkCore;
using MockAssessment6.DALModels;
using MockAssessment6.Models;

namespace MockAssessment6.Services
{
    public class EmployeeDbContext : DbContext
    {
        // linking our VS to the Database
        public EmployeeDbContext(DbContextOptions options):base(options)
        {
        }
        //create properties for table
        
        // data set for a migration for this particular employee entity will be created
        public DbSet <EmployeeDAL> Employees { get; set; }
        //create properties for table
        
        // data set for a migration for this particular employee entity will be created
        public DbSet<MockAssessment6.Models.EmployeeCurrent> EmployeeCurrent { get; set; }

        //create DAL model Folder

    }
}
