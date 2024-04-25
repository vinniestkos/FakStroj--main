using EFSQLite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSQLite.Data
{
    public class MyContext2 : DbContext
    {
        public MyContext2()
        {
            Database.EnsureCreated();// Zajistí vytvoření tabulky
        }

        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= SupplierData02.db"); // naše SQLite databáze ve složce BIN
        }
    }
}
