namespace PowerAdmin.Domain.User.Services.Interfaces;

using PowerAdmin.Domain.User.Models;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

public interface IUserService {
  Task<UserIdentity> GetProfile(ClaimsPrincipal principal);

  Task<PagedList<UserIdentity>> GetAll(string? search, int pageIndex = 1,
                                       int pageSize = 10);

  Task<UserIdentity> Get(string id);

  Task<UserIdentity> Create(UserName userName, Password password,
                            Password confirmPassword, PhoneNumber phoneNumber,
                            Email email, bool twoFactorEnabled = false);
}
