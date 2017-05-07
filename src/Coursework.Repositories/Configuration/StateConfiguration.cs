using Coursework.Entities;

namespace Coursework.Repositories.Configuration
{
  public class StateConfiguration: EntityBaseConfiguration<State>
  {
    public StateConfiguration()
    {
      Property(s => s.Name).IsRequired().HasMaxLength(50);
    }
  }
}
