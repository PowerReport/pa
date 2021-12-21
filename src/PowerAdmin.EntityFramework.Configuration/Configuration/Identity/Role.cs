using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Configuration.Configuration.Identity
{
    public class Role
    {
        public string Name { get; set; } = string.Empty;

        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
