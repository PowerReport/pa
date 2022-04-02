using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    public class PhoneNumber
    {
        private string phoneNumber = default!;

        public static implicit operator PhoneNumber(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || !IsPhoneNumber(str))
            {
                throw Oops.Bah("不正确的手机号码格式: {0}!", str);
            }

            return new PhoneNumber { phoneNumber = str };
        }

        public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.phoneNumber;

        /// <summary>
        /// 是否手机号码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static bool IsPhoneNumber(string str)
        {
            // TODO: 实现手机号码的验证规则
            return true;
        }
    }
}
