using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Postgres.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresDbContext<TUserIdentityDbContext>(this IServiceCollection services)
            where TUserIdentityDbContext : DbContext
        {
            // 添加用户身份数据库上下文
            var userIdentityDbConnection = DbContextHelpers.GetUserIdentityDbConnection();
            services.AddDbContext<TUserIdentityDbContext>(options => options.UseNpgsql(userIdentityDbConnection));

            return services;
        }
    }
}
