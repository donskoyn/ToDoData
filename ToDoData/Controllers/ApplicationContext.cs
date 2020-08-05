using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using ToDoData.Controllers;
using ToDoData.Models;

namespace ToDoData.Controllers
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Data> Tasks { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Todo_db;Username=postgres;Password=1234567890");
        }


    }
}
