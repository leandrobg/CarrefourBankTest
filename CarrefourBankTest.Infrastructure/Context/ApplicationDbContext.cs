using CarrefourBankTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrefourBankTest.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.Id);
            modelBuilder.Entity<Transaction>().HasKey(t => t.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
