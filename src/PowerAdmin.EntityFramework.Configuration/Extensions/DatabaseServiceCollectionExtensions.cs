using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    public static class DatabaseServiceCollectionExtensions
    {
        public static IServiceCollection AddDbContexts<TUserIdentityDbContext>(this IServiceCollection services)
            where TUserIdentityDbContext : DbContext
        {
            var dbSettings = DbContextHelpers.GetDbSettings();

            var userIdentityDbConnection = DbContextHelpers.GetUserIdentityDbConnection();

            switch (dbSettings.Provider?.ToLower())
            {
                case "postgres":
                    services.AddPostgresDbContexts<TUserIdentityDbContext>(userIdentityDbConnection);
                    break;
                default:
                    throw new ArgumentException(nameof(DbSettingsConfiguration.Provider));
            }

            return services;
        }
    }
}
