using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    /// <summary>
    /// 用户名称模型
    /// </summary>
    public class UserName
    {
        private string name = default!;

        /// <summary>
        /// 将 <see cref="string"/> 隐式转换为 <see cref="PhoneNumber"/>
        /// 并且校验用户名称格式是否合法
        /// </summary>
        /// <param name="str"></param>
        public static implicit operator UserName(string str)
        {
            // 校验输入的字符串是否合法
            ValidateUserName(str);

            return new UserName { name = str };
        }

        /// <summary>
        /// 将 <see cref="UserName"/> 隐式转换为 <see cref="string"/>
        /// </summary>
        /// <param name="userName"><see cref="UserName"/> 的字符串表现形式</param>
        public static implicit operator string(UserName userName) => userName.ToString();

        #region 重写

        /// <summary>
        /// 将 <see cref="UserName"/> 转换为字符串表现形式
        /// </summary>
        /// <returns><see cref="UserName"/> 的字符串表现形式</returns>
        public override string ToString() => name;

        public override int GetHashCode() => name.GetHashCode();

        #endregion

        #region 用户名称校验

        /// <summary>
        /// 校验用户名称格式是否合法
        /// </summary>
        /// <param name="str"></param>
        private static void ValidateUserName(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 2 || str.Length > 15)
            {
                throw Oops.Bah("不正确的用户名格式, 请输入 2~15 个字符: {0}!", str);
            }
        }

        #endregion
    }
}
