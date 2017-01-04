using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dorner.Net.Blog.Data
{
    
    /// <summary>
    /// Factory class for EmployeesContext
    /// </summary>
    public static class ApplicationDbContextFactory
    {
        public static ApplicationDbContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new ApplicationDbContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
