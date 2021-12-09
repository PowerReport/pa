using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Business.Identity.Dtos.Identity.Base
{
    public class BaseUserDto<TUserId>
    {
        /// <summary>
        /// 用户的唯一标识
        /// </summary>
        public TUserId Id { get; set; }
    }
}
