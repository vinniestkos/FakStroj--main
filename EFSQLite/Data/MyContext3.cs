using EFSQLite.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFSQLite.Data
{
    public class MyContext3 : DbContext
    {
        public MyContext3()
        {
            Database.EnsureCreated();
        }

        public DbSet<Invoice> Invoices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= Faktury.db");
        }

    }
}
