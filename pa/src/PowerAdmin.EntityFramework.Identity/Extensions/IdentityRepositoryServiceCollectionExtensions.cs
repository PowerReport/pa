namespace PowerAdmin.EntityFramework.Identity.Extensions;

using Furion;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PowerAdmin.Domain.User.Repositories;
using PowerAdmin.EntityFramework.Identity.Repositories;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IdentityRepositoryServiceCollectionExtensions {
  public static IServiceCollection
  AddIdentityRepository<TUserIdentityDbContext>(
      this IServiceCollection services)
      where TUserIdentityDbContext : DbContext {
    // 添加用户身份管理相关服务
    services
        .AddIdentity<UserIdentity, UserIdentityRole>(
            options => App.Configuration.GetSection(nameof(IdentityOptions))
                           .Bind(options))
        .AddEntityFrameworkStores<TUserIdentityDbContext>();

    // 添加用户身份的仓储服务
    services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }
}
