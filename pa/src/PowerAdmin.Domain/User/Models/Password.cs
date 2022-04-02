using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    public class Password
    {
        private string password = default!;

        public static implicit operator Password(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 8 || str.Length > 20)
            {
                throw Oops.Bah("不正确的密码格式, 请输入 8~20 个字符: {0}!", str);
            }

            if (!IncludeDigit(str) || !IncludeUpperChar(str) || !IncludeSpecialChar(str))
            {
                throw Oops.Bah("不正确的密码格式, 需要大小写字母、数字和特殊字符三种或以上: {0}!", str);
            }

            return new Password { password = str };
        }

        public static implicit operator string(Password password) => password.password;

        public override bool Equals(object? obj) => Equals(obj as Password);

        private bool Equals(Password? password)
        {
            if (password is null)
            {
                return false;
            }

            return password.password == this.password;
        }

        public static bool operator ==(Password? password, Password? password1)
        {
            if (password is null)
            {
                if (password1 is null)
                {
                    return true;
                }

                return false;
            }

            return password.Equals(password1);
        }

        public static bool operator !=(Password? password, Password? password1) => !(password == password1);

        public override int GetHashCode() => password.GetHashCode();

        /// <summary>
        /// 是否包含数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IncludeDigit(string str)
        {
            return str.Any(c => char.IsDigit(c));
        }

        /// <summary>
        /// 是否包含大写字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IncludeUpperChar(string str)
        {
            return str.Any(c => char.IsUpper(c));
        }

        /// <summary>
        /// 是否包含特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IncludeSpecialChar(string str)
        {
            return str.Any(c => !char.IsLetterOrDigit(c));
        }
    }
}
