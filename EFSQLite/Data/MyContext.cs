using EFSQLite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSQLite.Data
{
    public class MyContext : DbContext
    {
        public MyContext() 
        {
            Database.EnsureCreated();// Zajistí vytvoření tabulky
        }


        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= CustomerData03.db"); // naše SQLite databáze ve složce BIN
        }
    }
}
