using EMP.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP.core
{
   public  class Context :DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }

       

        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProjectMaster> Masters { get; set; }
        public DbSet<EmployeeProjectDetails> Details { get; set; }
    }
}
