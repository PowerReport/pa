using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.Business.Identity.Services;
using PowerAdmin.Business.Identity.Services.Interfaces;
using PowerAdmin.EntityFramework.Identity.Repositories;
using PowerAdmin.EntityFramework.Identity.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Business.Identity.Extensions
{
    public static class IdentityServicesServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            // 添加用户身份的仓储服务
            services.AddScoped<IIdentityRepository, IdentityRepository>();

            // 添加用户身份的业务服务
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
