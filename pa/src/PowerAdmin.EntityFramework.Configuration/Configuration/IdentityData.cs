namespace PowerAdmin.EntityFramework.Configuration.Configuration;

using PowerAdmin.EntityFramework.Configuration.Configuration.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class IdentityData {
  public List<Role> Roles { get; set; } = new List<Role>();

  public List<User> Users { get; set; } = new List<User>();
}
