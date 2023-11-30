namespace PowerAdmin.EntityFramework.Shared.DbContexts;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UserIdentityDbContext
    : IdentityDbContext<UserIdentity, UserIdentityRole, string,
                        UserIdentityClaim, UserIdentityUserRole,
                        UserIdentityUserLogin, UserIdentityRoleClaim,
                        UserIdentityUserToken> {
  public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options)
      : base(options) {}

  protected override void OnModelCreating(ModelBuilder builder) {
    base.OnModelCreating(builder);

    builder.Entity<UserIdentity>(e => {
      e.ToTable("users");

      e.Property(p => p.Id).HasColumnName("id").HasMaxLength(36);
      e.Property(p => p.UserName).HasColumnName("username").HasMaxLength(20);
      e.Property(p => p.NormalizedUserName)
          .HasColumnName("normalized_username")
          .HasMaxLength(20);
      e.Property(p => p.Email).HasColumnName("email").HasMaxLength(40);
      e.Property(p => p.NormalizedEmail)
          .HasColumnName("normalized_email")
          .HasMaxLength(40);
      e.Property(p => p.EmailConfirmed).HasColumnName("email_confirmed");
      e.Property(p => p.PasswordHash)
          .HasColumnName("password_hash")
          .HasMaxLength(100);
      e.Property(p => p.SecurityStamp)
          .HasColumnName("security_stamp")
          .HasMaxLength(32);
      e.Property(p => p.ConcurrencyStamp)
          .HasColumnName("concurrency_stamp")
          .HasMaxLength(36);
      e.Property(p => p.PhoneNumber)
          .HasColumnName("phone_number")
          .HasMaxLength(20);
      e.Property(p => p.PhoneNumberConfirmed)
          .HasColumnName("phone_number_confirmed");
      e.Property(p => p.TwoFactorEnabled).HasColumnName("two_factor_enabled");
      e.Property(p => p.LockoutEnd).HasColumnName("lockout_end");
      e.Property(p => p.LockoutEnabled).HasColumnName("lockout_enabled");
      e.Property(p => p.AccessFailedCount)
          .HasColumnName("access_failed_count")
          .HasPrecision(2, 0);
    });

    builder.Entity<UserIdentityClaim>(e => {
      e.ToTable("claims");

      e.Property(p => p.Id).HasColumnName("id");
      e.Property(p => p.UserId).HasColumnName("user_id").HasMaxLength(36);
      e.Property(p => p.ClaimType)
          .HasColumnName("claim_type")
          .HasMaxLength(100);
      e.Property(p => p.ClaimValue)
          .HasColumnName("claim_value")
          .HasMaxLength(100);
    });

    builder.Entity<UserIdentityUserRole>(e => {
      e.ToTable("user_roles");

      e.Property(p => p.UserId).HasColumnName("user_id").HasMaxLength(36);
      e.Property(p => p.RoleId).HasColumnName("role_id").HasMaxLength(36);
    });

    builder.Entity<UserIdentityRole>(e => {
      e.ToTable("roles");

      e.Property(p => p.Id).HasColumnName("id").HasMaxLength(36);
      e.Property(p => p.Name).HasColumnName("name").HasMaxLength(40);
      e.Property(p => p.NormalizedName)
          .HasColumnName("normalized_name")
          .HasMaxLength(40);
      e.Property(p => p.ConcurrencyStamp)
          .HasColumnName("concurrency_stamp")
          .HasMaxLength(36);
    });

    builder.Entity<UserIdentityRoleClaim>(e => {
      e.ToTable("role_claims");

      e.Property(p => p.Id).HasColumnName("id");
      e.Property(p => p.RoleId).HasColumnName("role_id").HasMaxLength(36);
      e.Property(p => p.ClaimType)
          .HasColumnName("claim_type")
          .HasMaxLength(100);
      e.Property(p => p.ClaimValue)
          .HasColumnName("claim_value")
          .HasMaxLength(100);
    });

    builder.Entity<UserIdentityUserLogin>(e => {
      e.ToTable("user_logins");

      e.Property(p => p.LoginProvider)
          .HasColumnName("login_provider")
          .HasMaxLength(100);
      e.Property(p => p.ProviderKey)
          .HasColumnName("provider_key")
          .HasMaxLength(256);
      e.Property(p => p.ProviderDisplayName)
          .HasColumnName("provider_display_name")
          .HasMaxLength(100);
      e.Property(p => p.UserId).HasColumnName("user_id").HasMaxLength(36);
    });

    builder.Entity<UserIdentityUserToken>(e => {
      e.ToTable("user_tokens");

      e.Property(p => p.UserId).HasColumnName("user_id").HasMaxLength(36);
      e.Property(p => p.LoginProvider)
          .HasColumnName("login_provider")
          .HasMaxLength(100);
      e.Property(p => p.Name).HasColumnName("name").HasMaxLength(100);
      e.Property(p => p.Value).HasColumnName("value").HasMaxLength(256);
    });
  }
}
