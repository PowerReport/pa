using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.Business.Identity.Services;
using PowerAdmin.Business.Identity.Services.Interfaces;
using PowerAdmin.EntityFramework.Identity.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Business.Identity.Extensions
{
    public static class IdentityServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices<TUserIdentityDbContext>(this IServiceCollection services)
            where TUserIdentityDbContext : DbContext
        {
            // 添加用户身份的仓储相关服务
            services.AddIdentityRepository<TUserIdentityDbContext>();

            // 添加用户身份的业务服务
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
