using PowerAdmin.Domain.User.Models;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Factories
{
    public interface IUserFactory
    {
        Task<(UserIdentity, string)> CreateUser(UserName userName, Password password, Password confirmPassword, PhoneNumber phoneNumber, Email email, bool twoFactorEnabled = false);
    }
}
