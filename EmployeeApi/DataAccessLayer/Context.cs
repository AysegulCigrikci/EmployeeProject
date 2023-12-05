using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.DataAccessLayer
{
    public class Context:DbContext
    {
        //Veri tabanı bağlantısı
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=EmployeeDbApi;integrated security=true;");
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
