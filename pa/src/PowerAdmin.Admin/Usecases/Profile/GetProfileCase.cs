namespace PowerAdmin.Admin.Usecases.Profile;

using PowerAdmin.Admin.Usecases.User.Base;

public class GetProfileCase {
  public class Response : BaseUser<string> {
    /// <summary>
    /// 用户名
    /// </summary>
    public string UserName { get; set; } = default!;

    /// <summary>
    /// 邮箱
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// 手机号码
    /// </summary>
    public string? PhoneNumber { get; set; }
  }
}
