using Furion.FriendlyException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Models
{
    public class Email
    {
        private string email = default!;

        public static implicit operator Email(string str)
        {
            if (string.IsNullOrWhiteSpace(str) || !MailAddress.TryCreate(str, out _))
            {
                throw Oops.Bah("不正确的邮件格式: {0}!", str);
            }

            return new Email { email = str };
        }

        public static implicit operator string(Email email) => email.email;
    }
}
