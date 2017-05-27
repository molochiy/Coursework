using System.Collections.Generic;

namespace Coursework.Entities.DatabaseEntities
{
  public class User: EntityBase
  {
    public User()
    {
      Roles = new HashSet<Role>();
      Problems = new List<Problem>();
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<Problem> Problems { get; set; }
  }
}
