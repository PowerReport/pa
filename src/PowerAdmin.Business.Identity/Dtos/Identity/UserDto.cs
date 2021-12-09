using PowerAdmin.Business.Identity.Dtos.Identity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Business.Identity.Dtos.Identity
{
    public class UserDto : UserDto<string>
    {
        public UserDto(string userName) : base(userName)
        {
        }
    }
}
