using System.Collections;
using System.Collections.Generic;

namespace Coursework.Entities
{
  public class Role: EntityBase
  {
    public Role()
    {
      Users = new HashSet<User>();
    }

    public string Name { get; set; }

    public virtual ICollection<User> Users { get; set; }
  }
}
