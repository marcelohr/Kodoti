using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class AplicationRoleConfig
    {
        public AplicationRoleConfig(EntityTypeBuilder<AplicationRole> entityTypeBuilder)
        {
            entityTypeBuilder.HasMany(x => x.UserRoles)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();

            entityTypeBuilder.HasData(
                new AplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                new AplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Seller",
                    NormalizedName = "Seller"
                }
            );
        }
    }
}
