using Furion.FriendlyException;
using PowerAdmin.Domain.User.Models;
using PowerAdmin.Domain.User.Repositories;
using PowerAdmin.EntityFramework.Shared.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Domain.User.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IUserRepository userRepository;

        public UserFactory(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<(UserIdentity, string)> CreateUser(UserName userName, Password password, Password confirmPassword, PhoneNumber phoneNumber, Email email, bool twoFactorEnabled = false)
        {
            if (password != confirmPassword)
            {
                throw Oops.Bah("新增用户失败, 登录密码与确认密码不一致");
            }

            var userByUserName = await userRepository.Get(userName);

            if (userByUserName != null)
            {
                throw Oops.Bah("新增用户失败, 已经存在相同用户名的账号!");
            }

            var userByPhoneNumber = await userRepository.Get(phoneNumber);
            var userByEmail = await userRepository.Get(email);

            if (userByPhoneNumber != null || userByEmail != null)
            {
                throw Oops.Bah("新增用户失败, 已经存在相同手机号码或邮箱的账号!");
            }

            var user = new UserIdentity
            {
                UserName = userName,
                TwoFactorEnabled = twoFactorEnabled,
                PhoneNumber = phoneNumber,
                Email = email
            };

            return (user, confirmPassword);
        }
    }
}
