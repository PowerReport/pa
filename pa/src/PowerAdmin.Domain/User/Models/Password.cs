using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    /// <summary>
    /// 密码模型
    /// </summary>
    public class Password
    {
        private string password = default!;

        /// <summary>
        /// 将 <see cref="string"/> 隐式转换为 <see cref="Password"/>
        /// 并且校验密码格式是否合法
        /// </summary>
        /// <param name="str"></param>
        public static implicit operator Password(string str)
        {
            // 校验输入的字符串是否合法
            ValidatePassword(str);

            return new Password { password = str };
        }

        /// <summary>
        /// 将 <see cref="Password"/> 隐式转换为 <see cref="string"/>
        /// </summary>
        /// <param name="password"><see cref="Password"/> 的字符串表现形式</param>
        public static implicit operator string(Password password) => password.ToString();

        /// <summary>
        /// 对比 <see cref="Password"/> 的字符串表现形式是否相等
        /// </summary>
        /// <param name="password"></param>
        /// <param name="password1"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 对比 <see cref="Password"/> 的字符串表现形式是否不相等
        /// </summary>
        /// <param name="password"></param>
        /// <param name="password1"></param>
        /// <returns></returns>
        public static bool operator !=(Password? password, Password? password1) => !(password == password1);

        /// <summary>
        /// 对比 <see cref="Password"/> 的字符串表现形式是否相等
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool Equals(Password? password)
        {
            if (password is null)
            {
                return false;
            }

            return password.password == this.password;
        }

        #region 重写
        
        /// <summary>
        /// 对比 <see cref="Password"/> 的字符串表现形式是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj) => Equals(obj as Password);

        /// <summary>
        /// 将 <see cref="Password"/> 转换为字符串表现形式
        /// </summary>
        /// <returns><see cref="Password"/> 的字符串表现形式</returns>
        public override string ToString() => password;

        public override int GetHashCode() => password.GetHashCode(); 

        #endregion

        #region 密码校验

        /// <summary>
        /// 校验密码格式是否合法
        /// </summary>
        /// <param name="str"></param>
        private static void ValidatePassword(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 8 || str.Length > 20)
            {
                throw Oops.Bah("不正确的密码格式, 请输入 8~20 个字符: {0}!", str);
            }

            if (!IncludeDigit(str) || !IncludeUpperChar(str) || !IncludeSpecialChar(str))
            {
                throw Oops.Bah("不正确的密码格式, 需要大小写字母、数字和特殊字符三种或以上: {0}!", str);
            }
        }

        /// <summary>
        /// 判断 <see cref="string"/> 是否包含数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IncludeDigit(string str) => str.Any(c => char.IsDigit(c));

        /// <summary>
        /// 判断 <see cref="string"/> 是否包含大写字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IncludeUpperChar(string str) => str.Any(c => char.IsUpper(c));

        /// <summary>
        /// 判断 <see cref="string"/> 是否包含特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IncludeSpecialChar(string str) => str.Any(c => !char.IsLetterOrDigit(c)); 

        #endregion
    }
}
