using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Configuration.Configuration.Identity
{
    public class Claim
    {
        public string Type { get; set; } = default!;

        public string Value { get; set; } = default!;
    }
}
