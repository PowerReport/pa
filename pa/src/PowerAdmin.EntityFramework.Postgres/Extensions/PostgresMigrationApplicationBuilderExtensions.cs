namespace PowerAdmin.EntityFramework.Postgres.Extensions;

using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PostgresMigrationApplicationBuilderExtensions {
  public static IApplicationBuilder
  PostgresEnsureDatabasesMigrated<TUserIdentityDbContext>(
      this IApplicationBuilder app)
      where TUserIdentityDbContext : DbContext {
    using (var userIdentityDbContext =
               App.GetRequiredService<TUserIdentityDbContext>()) {
      userIdentityDbContext.Database.Migrate();
    }

    return app;
  }
}
