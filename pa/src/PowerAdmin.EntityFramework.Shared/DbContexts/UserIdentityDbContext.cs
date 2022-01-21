using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Shared.DbContexts
{
    public class UserIdentityDbContext : IdentityDbContext<UserIdentity, UserIdentityRole, string, UserIdentityClaim, UserIdentityUserRole, UserIdentityUserLogin, UserIdentityRoleClaim, UserIdentityUserToken>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserIdentity>().ToTable("users");
            builder.Entity<UserIdentityClaim>().ToTable("claims");
            builder.Entity<UserIdentityUserRole>().ToTable("user_roles");

            builder.Entity<UserIdentityRole>().ToTable("roles");
            builder.Entity<UserIdentityRoleClaim>().ToTable("role_claims");

            builder.Entity<UserIdentityUserLogin>().ToTable("user_logins");
            builder.Entity<UserIdentityUserToken>().ToTable("user_tokens");
        }
    }
}
