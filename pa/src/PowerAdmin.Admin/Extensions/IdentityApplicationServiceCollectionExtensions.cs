using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.Admin.Services;
using PowerAdmin.Admin.Services.Interfaces;
using PowerAdmin.Domain.User.Factories;
using PowerAdmin.Domain.User.Services;
using PowerAdmin.Domain.User.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Admin.Extensions
{
    public static class IdentityApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityApplicationServices(this IServiceCollection services)
        {
            // 添加用户身份的领域服务
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFactory, UserFactory>();

            // 添加用户身份的业务服务
            services.AddScoped<IIdentityService, IdentityService>();

            return services;
        }
    }
}
