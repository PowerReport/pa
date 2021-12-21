using Furion;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PowerAdmin.EntityFramework.Configuration.Configuration;
using PowerAdmin.EntityFramework.Configuration.Helpers;
using PowerAdmin.EntityFramework.Postgres.Extensions;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Configuration.Extensions
{
    public static class DatabaseMigrationApplicationBuilderExtensions
    {
        public static IApplicationBuilder EnsureDatabasesMigrated<TUserIdentityDbContext>(this IApplicationBuilder app)
            where TUserIdentityDbContext : DbContext
        {
            var dbSettings = DbContextHelpers.GetDbSettings();

            switch (dbSettings.Provider?.ToLower())
            {
                case "postgres":
                    app.PostgresEnsureDatabasesMigrated<TUserIdentityDbContext>();
                    break;
                default:
                    throw new ArgumentException(nameof(DbSettingsConfiguration.Provider));
            }

            return app;
        }

        public static async Task<IApplicationBuilder> EnsureSeedIdentityData(this IApplicationBuilder app)
        {
            var roleManager = App.GetRequiredService<RoleManager<UserIdentityRole>>();
            var userManager = App.GetRequiredService<UserManager<UserIdentity>>();

            var identityData = App.Configuration.GetSection(nameof(IdentityData)).Get<IdentityData>();

            if (identityData != null)
            {
                foreach (var role in identityData.Roles)
                {
                    var dbRole = await roleManager.FindByNameAsync(role.Name);

                    if (dbRole != null)
                    {
                        continue;
                    }

                    var userIdentityRole = new UserIdentityRole
                    {
                        Name = role.Name,
                    };

                    var result = await roleManager.CreateAsync(userIdentityRole);

                    if (result.Succeeded)
                    {
                        foreach (var claim in role.Claims)
                        {
                            await roleManager.AddClaimAsync(userIdentityRole, new Claim(claim.Type, claim.Value));
                        }
                    }
                    else
                    {
                        throw Oops.Oh(result.Errors.First().Description);
                    }
                }

                foreach (var user in identityData.Users)
                {
                    var dbUser = await userManager.FindByNameAsync(user.Username);

                    if (dbUser != null)
                    {
                        continue;
                    }

                    var userIdentity = new UserIdentity
                    {
                        UserName = user.Username,
                        Email = user.Email,
                        EmailConfirmed = !string.IsNullOrWhiteSpace(user.Email),
                        PhoneNumber = user.PhoneNumber,
                        PhoneNumberConfirmed = !string.IsNullOrWhiteSpace(user.PhoneNumber),
                    };

                    var result = string.IsNullOrWhiteSpace(user.Password)
                        ? await userManager.CreateAsync(userIdentity)
                        : await userManager.CreateAsync(userIdentity, user.Password);

                    if (result.Succeeded)
                    {
                        foreach (var claim in user.Claims)
                        {
                            await userManager.AddClaimAsync(userIdentity, new Claim(claim.Type, claim.Value));
                        }

                        foreach(var role in user.Roles)
                        {
                            await userManager.AddToRoleAsync(userIdentity, role);
                        }
                    }
                    else
                    {
                        throw Oops.Oh(result.Errors.First().Description);
                    }
                }
            }

            return app;
        }
    }
}
