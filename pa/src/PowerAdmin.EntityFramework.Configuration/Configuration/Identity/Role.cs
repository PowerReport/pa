namespace PowerAdmin.EntityFramework.Configuration.Configuration.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Role {
  public string Name { get; set; } = default!;

  public List<Claim> Claims { get; set; } = new List<Claim>();
}
