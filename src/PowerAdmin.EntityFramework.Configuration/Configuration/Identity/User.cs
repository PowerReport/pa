using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Configuration.Configuration.Identity
{
    public class User
    {
        public string Username { get; set; } = string.Empty;

        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public List<string> Roles { get; set; } = new List<string>();

        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}
