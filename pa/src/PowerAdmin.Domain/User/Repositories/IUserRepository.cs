using PowerAdmin.Domain.User.Models;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Repositories
{
    public interface IUserRepository
    {
        Task<UserIdentity> GetProfile(ClaimsPrincipal principal);

        Task<PagedList<UserIdentity>> GetAll(string? search, int pageIndex = 1, int pageSize = 10);

        Task<UserIdentity> Get(string id);

        Task<UserIdentity> Get(UserName userName);

        Task<UserIdentity> Get(Email email);

        Task<UserIdentity> Get(PhoneNumber phoneNumber);

        Task<UserIdentity> Add(UserIdentity user, string password);
    }
}
