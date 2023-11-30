namespace PowerAdmin.Blazor.Services;

using PowerAdmin.Blazor.Common.Models;
using PowerAdmin.Blazor.Models;
using Refit;

public interface IUserApi {
  [Get("/api/Users")]
  Task<PagedList<User>> GetUsers(string? search = default, int pageIndex = 1,
                                 int pageSize = 10);
}
