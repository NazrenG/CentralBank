using CentralBank.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralBank.Entities.Data
{
    public class CentralBankDbContext : DbContext
    {
        public CentralBankDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          modelBuilder.Entity<ValType>().HasOne(i=>i.Curs).WithMany(i=>i.ValType).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Valute>().HasOne(i=>i.ValType).WithMany(i=>i.Valute).OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Root> Roots { get; set; }
        public DbSet<ValCurs> ValCurs { get; set; }
        public DbSet<ValType> ValTypes { get; set; }
        public DbSet<Valute> Valutes { get; set; }
    }
}
