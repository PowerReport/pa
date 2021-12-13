using Furion;
using Furion.FriendlyException;
using Microsoft.Extensions.Configuration;
using PowerAdmin.EntityFramework.Configuration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerAdmin.EntityFramework.Configuration.Helpers
{
    public static class DbContextHelpers
    {
        public static DbSettingsConfiguration GetDbSettings()
        {
            var dbSettingsConfiguration = App.Configuration.GetSection("DbSettings").Get<DbSettingsConfiguration>();

            if (dbSettingsConfiguration == null)
            {
                throw Oops.Oh("The \"DbSettings\" item is missing from the application configuration");
            }

            return dbSettingsConfiguration;
        }

        public static string GetUserIdentityDbConnection()
        {
            var userIdentityDbConnection = App.Configuration.GetConnectionString("UserIdentityDbConnection");

            if (userIdentityDbConnection == null)
            {
                throw Oops.Oh("The \"UserIdentityDbConnection\" item is missing from the application configuration");
            }

            return userIdentityDbConnection;
        }
    }
}
