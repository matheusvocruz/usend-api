using System;
using Microsoft.EntityFrameworkCore;
using USend.Infra.Data.Util;

namespace USend.Infra.Data.EntitiesConfig.Seed
{
    public static class UserSeed
    {
        public static void SeedUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.User>().HasData(
                new Domain.Entities.User("user@user.com", "User USend", PasswordUtil.GeneratePassword("Password123#"), DateTime.Now, "43118341017", "11999999999") { Id = 1 }
            );
        }
    }
}
