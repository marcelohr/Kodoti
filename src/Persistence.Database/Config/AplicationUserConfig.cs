using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Database.Config
{
    public class AplicationUserConfig
    {
        public AplicationUserConfig(EntityTypeBuilder<AplicationUser> entityTypeBuilder) =>
            entityTypeBuilder.HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired();
    }
}
