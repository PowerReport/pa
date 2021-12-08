﻿using Furion;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Postgres.Extensions
{
    public static class PostgresMigrationApplicationBuilderExtensions
    {
        public static IApplicationBuilder EnsureDatabasesMigrated<TUserIdentityDbContext>(this IApplicationBuilder app)
            where TUserIdentityDbContext : DbContext
        {
            using (var userIdentityDbContext = App.GetRequiredService<TUserIdentityDbContext>())
            {
                userIdentityDbContext.Database.Migrate();
            }

            return app;
        }
    }
}
