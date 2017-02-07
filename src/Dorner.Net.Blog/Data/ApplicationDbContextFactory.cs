using Microsoft.EntityFrameworkCore;
using MySQL.Data.Entity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Net.Blog.Data
{
    
    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class ApplicationIdentityDbContextFactory
    {
        public static ApplicationIdentityDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationIdentityDbContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new ApplicationIdentityDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
