using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class RoleConfiguration: EntityBaseConfiguration<Role>
  {
    public RoleConfiguration()
    {
      Property(r => r.Name).IsRequired().HasMaxLength(50);
    }
  }
}
