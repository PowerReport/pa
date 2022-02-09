using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Admin.Usecases.User.Base
{
    public class BaseUser<TUserId>
    {
        /// <summary>
        /// 用户的唯一标识
        /// </summary>
        public TUserId Id { get; set; } = default!;
    }
}
