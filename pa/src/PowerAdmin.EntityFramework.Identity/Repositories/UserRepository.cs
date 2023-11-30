namespace PowerAdmin.EntityFramework.Identity.Repositories;

using Furion.DatabaseAccessor;
using Furion.FriendlyException;
using Microsoft.AspNetCore.Identity;
using PowerAdmin.Domain.User.Models;
using PowerAdmin.Domain.User.Repositories;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public class UserRepository : IUserRepository {
  private readonly UserManager<UserIdentity> userManager;

  public UserRepository(UserManager<UserIdentity> userManager) {
    this.userManager = userManager;
  }

  public async Task<UserIdentity> GetProfile(ClaimsPrincipal principal) {
    return await userManager.GetUserAsync(principal);
  }

  public async Task<PagedList<UserIdentity>>
  GetAll(string? search, int pageIndex = 1, int pageSize = 10) {
    var userQueryable = userManager.Users;

    if (!string.IsNullOrEmpty(search)) {
      userQueryable = userQueryable.Where(x => x.UserName.Contains(search) ||
                                               x.Email.Contains(search) ||
                                               x.PhoneNumber.Contains(search));
    }

    return await userQueryable.ToPagedListAsync(pageIndex, pageSize);
  }

  public async Task<UserIdentity> Get(string id) {
    return await userManager.FindByIdAsync(id);
  }

  public async Task<UserIdentity> Get(UserName userName) {
    return await userManager.FindByNameAsync(userName);
  }

  public async Task<UserIdentity> Get(Email email) {
    return await userManager.FindByEmailAsync(email);
  }

  public Task<UserIdentity> Get(PhoneNumber phoneNumber) {
    throw new NotImplementedException();
  }

  public async Task<UserIdentity> Add(UserIdentity user, string password) {
    var identityResult = await userManager.CreateAsync(user, password);

    if (!identityResult.Succeeded) {
      throw Oops.Oh("新增用户失败: {0}!",
                    identityResult.Errors.Select(p => p.Description));
    }

    return user;
  }
}
