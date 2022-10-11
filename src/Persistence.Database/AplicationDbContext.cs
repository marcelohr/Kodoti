using Microsoft.EntityFrameworkCore;
using Model;
using Persistence.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new ClientConfig(builder.Entity<Client>());
            new ProductConfig(builder.Entity<Product>());
        }
    }
}
