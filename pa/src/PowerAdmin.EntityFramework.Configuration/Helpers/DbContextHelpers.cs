namespace PowerAdmin.EntityFramework.Configuration.Helpers;

using Furion;
using Furion.FriendlyException;
using Microsoft.Extensions.Configuration;
using PowerAdmin.EntityFramework.Configuration.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DbContextHelpers {
  public static DatabaseProviderSettingsConfiguration
  GetDatabaseProviderSettings() {
    var providerSettings =
        App.Configuration.GetSection("DatabaseProviderSettings")
            .Get<DatabaseProviderSettingsConfiguration>();

    if (providerSettings == null) {
      throw Oops.Oh(
          "The \"DatabaseProviderSettings\" item is missing from the application configuration");
    }

    return providerSettings;
  }

  public static string GetUserIdentityDbConnection() {
    var userIdentityDbConnection =
        App.Configuration.GetConnectionString("UserIdentityDbConnection");

    if (userIdentityDbConnection == null) {
      throw Oops.Oh(
          "The \"UserIdentityDbConnection\" item is missing from the application configuration");
    }

    return userIdentityDbConnection;
  }
}
