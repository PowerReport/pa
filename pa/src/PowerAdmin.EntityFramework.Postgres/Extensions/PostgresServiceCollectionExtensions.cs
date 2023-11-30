namespace PowerAdmin.EntityFramework.Postgres.Extensions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.EntityFramework.Postgres.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PostgresServiceCollectionExtensions {
  public static IServiceCollection
  AddPostgresDbContexts<TUserIdentityDbContext>(
      this IServiceCollection services, string userIdentityDbConnection)
      where TUserIdentityDbContext : DbContext {
    var migrationsAssembly = typeof(MigrationAssembly).Assembly.GetName().Name;

    // 添加用户身份数据库上下文
    services.AddDbContext<TUserIdentityDbContext>(
        options => options.UseNpgsql(
            userIdentityDbConnection,
            sql => sql.MigrationsAssembly(migrationsAssembly)));

    return services;
  }
}
