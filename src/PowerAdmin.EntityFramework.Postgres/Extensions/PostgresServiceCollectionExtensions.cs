using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.Common.Helpers;
using PowerAdmin.EntityFramework.Postgres.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Postgres.Extensions
{
    public static class PostgresServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresDbContext<TUserIdentityDbContext>(this IServiceCollection services)
            where TUserIdentityDbContext : DbContext
        {
            var migrationsAssembly = typeof(MigrationAssembly).Assembly.GetName().Name;

            // 添加用户身份数据库上下文
            var userIdentityDbConnection = DbContextHelpers.GetUserIdentityDbConnection();
            services.AddDbContext<TUserIdentityDbContext>(options => options.UseNpgsql(userIdentityDbConnection, sql => sql.MigrationsAssembly(migrationsAssembly)));

            return services;
        }
    }
}
