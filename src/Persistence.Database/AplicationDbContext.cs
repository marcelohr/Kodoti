using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Identity;
using Persistence.Database.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database
{
    public class AplicationDbContext : IdentityDbContext<AplicationUser, AplicationRole, string, IdentityUserClaim<string>, AplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
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
            new AplicationUserConfig(builder.Entity<AplicationUser>());
            new AplicationRoleConfig(builder.Entity<AplicationRole>());
        }
    }
}
