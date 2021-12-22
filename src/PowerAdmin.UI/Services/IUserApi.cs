using PowerAdmin.UI.Common.Models;
using PowerAdmin.UI.Models;
using Refit;

namespace PowerAdmin.UI.Services
{
    public interface IUserApi
    {
        [Get("/api/Users")]
        Task<PagedList<User>> GetUsers(string? search = default, int pageIndex = 1, int pageSize = 10);
    }
}
