using Esercizio.Core.EF.Configuration;
using Esercizio.Core.Model;
using Esercizio.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Esercizio.Core.EF.Context
{
    public sealed class OfficeContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionBuilder
        )
        {
            string connString = Config.GetConnectionString("OfficeDb");
            // OPPURE
            //string connString = Config.GetSection("ConnectionStrings")["TicketDb"];

            //optionBuilder.UseLazyLoadingProxies();
            optionBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Office>(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration<Employee>(new EmployeeConfiguration());
        }
    }
}
