using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebApplication3.Core.Constants;

namespace WebApplication.Infrastructure.Data.EF.Seeding
{
    public class UserIdentitySeed
    {
        public static void Seed(ApplicationDbContext context, string password)
        {
            context.Database.EnsureCreated();
            CreateUserAsync(context, "admin@admin.com", password, RoleConstants.Admin).GetAwaiter().GetResult();
            CreateUserAsync(context, "reader@reader.com", password, RoleConstants.Reader).GetAwaiter().GetResult();
            context.SaveChanges();
        }

        public static async Task CreateUserAsync(ApplicationDbContext context, string email, string password, string role)
        {
            var user = new IdentityUser
            {
                UserName = email,
                NormalizedUserName = email,
                Email = email,
                NormalizedEmail = email,
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(context);

            if (!context.Roles.Any(r => r.Name == role))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = role, NormalizedName = role });
            }

            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var passwordHasher = new PasswordHasher<IdentityUser>();
                var hashed = passwordHasher.HashPassword(user, password);
                user.PasswordHash = hashed;
                var userStore = new UserStore<IdentityUser>(context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, role);
            }
        }
    }
}
