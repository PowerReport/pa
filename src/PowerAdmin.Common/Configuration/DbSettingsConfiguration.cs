using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.Common.Configuration
{
    public class DbSettingsConfiguration
    {
        public string? Type { get; set; }

        public ConnectionStringsConfiguration? ConnectionStrings { get; set; }
    }
}
