using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    public class UserName
    {
        private string name = default!;

        public static implicit operator UserName(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || str.Length < 2 || str.Length > 15)
            {
                throw Oops.Bah("不正确的用户名格式, 请输入 2~15 个字符: {0}!", str);
            }

            return new UserName { name = str };
        }

        public static implicit operator string(UserName userName) => userName.name;
    }
}
