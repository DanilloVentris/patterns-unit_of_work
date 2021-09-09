using DcVentris.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DcVentris.Infrastructure.Context
{
    public class DcVentrisContext : DbContext
    {        
        public DcVentrisContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=localhost;Initial Catalog=DBTest.Core;User=sa;Password=SQLMASTER");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntity).Assembly);
        }

        public DbSet<User> Users { get; set; }
    }

    internal interface IEntity
    {
    }
}
