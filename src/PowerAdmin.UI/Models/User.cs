using PowerAdmin.UI.Models.Base;

namespace PowerAdmin.UI.Models
{
    public class User : BaseUser<string>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = default!;

        /// <summary>
        /// 邮箱
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// 邮箱是否已验证
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// 手机号码
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// 手机号码是否已验证
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        /// 是否启用双重身份认证
        /// </summary>
        public bool TwoFactorEnabled { get; set; }

        /// <summary>
        /// 锁定结束时的日期
        /// </summary>
        public DateTimeOffset? LockoutEnd { get; set; }

        /// <summary>
        /// 是否启用锁定
        /// </summary>
        public bool LockoutEnabled { get; set; }

        /// <summary>
        /// 登录失败的次数
        /// </summary>
        public int AccessFailedCount { get; set; }
    }
}
