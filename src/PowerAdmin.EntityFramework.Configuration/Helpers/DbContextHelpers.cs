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

        public static ConnectionStringsConfiguration GetConnectionStrings()
        {
            var connectionStringsConfiguration = GetDbSettings().ConnectionStrings;

            if (connectionStringsConfiguration == null)
            {
                throw Oops.Oh("The \"{0}\" item is missing from the application configuration", nameof(DbSettingsConfiguration.ConnectionStrings));
            }

            return connectionStringsConfiguration;
        }

        public static string GetUserIdentityDbConnection()
        {
            var userIdentityDbConnection = GetConnectionStrings().UserIdentityDbConnection;

            if (userIdentityDbConnection == null)
            {
                throw Oops.Oh("The \"{0}\" item is missing from the application configuration", nameof(ConnectionStringsConfiguration.UserIdentityDbConnection));
            }

            return userIdentityDbConnection;
        }
    }
}
