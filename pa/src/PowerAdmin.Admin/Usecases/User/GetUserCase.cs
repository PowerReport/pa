namespace PowerAdmin.Admin.Usecases.User;

using PowerAdmin.Admin.Usecases.User.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GetUserCase {
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

    /// <summary>
    /// 是否启用双重身份认证
    /// </summary>
    public bool TwoFactorEnabled { get; set; }

    /// <summary>
    /// 是否启用锁定
    /// </summary>
    public bool LockoutEnabled { get; set; }
  }
}
