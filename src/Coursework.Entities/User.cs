using System.Collections;
using System.Collections.Generic;

namespace Coursework.Entities
{
  public class User: EntityBase
  {
    public User()
    {
      UserRoles = new List<UserRole>();
    }

    public string Email { get; set; }
    public string HashedPassword { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; }
  }
}
