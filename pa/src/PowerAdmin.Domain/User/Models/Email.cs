using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    /// <summary>
    /// 电子邮件地址模型
    /// </summary>
    public class Email
    {
        private string email = default!;

        /// <summary>
        /// 将 <see cref="string"/> 隐式转换为 <see cref="Email"/>
        /// 并且校验电子邮件格式是否合法
        /// </summary>
        /// <param name="str"></param>
        public static implicit operator Email(string str)
        {
            // 校验输入的字符串是否合法
            ValidateEmail(str);

            return new Email { email = str };
        }

        /// <summary>
        /// 将 <see cref="Email"/> 隐式转换为 <see cref="string"/>
        /// </summary>
        /// <param name="email"><see cref="Email"/> 的字符串表现形式</param>
        public static implicit operator string(Email email) => email.ToString();

        #region 重写

        /// <summary>
        /// 将 <see cref="Email"/> 转换为字符串表现形式
        /// </summary>
        /// <returns><see cref="Email"/> 的字符串表现形式</returns>
        public override string ToString() => email;

        public override int GetHashCode() => email.GetHashCode();

        #endregion

        #region 电子邮件校验

        /// <summary>
        /// 校验电子邮件格式是否合法
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static void ValidateEmail(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || !MailAddress.TryCreate(str, out _))
            {
                throw Oops.Bah("不正确的邮件格式: {0}!", str);
            }
        }

        #endregion
    }
}
