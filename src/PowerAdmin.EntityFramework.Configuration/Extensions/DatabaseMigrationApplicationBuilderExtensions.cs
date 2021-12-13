using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PowerAdmin.EntityFramework.Configuration.Configuration;
using PowerAdmin.EntityFramework.Configuration.Helpers;
using PowerAdmin.EntityFramework.Postgres.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
