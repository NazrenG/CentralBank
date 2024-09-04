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
        public DbSet<Root> Roots { get; set; }
        public DbSet<ValCurs> ValCurs { get; set; }
        public DbSet<ValType> ValTypes { get; set; }
        public DbSet<Valute> Valutes { get; set; }
    }
}
