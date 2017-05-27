using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class ProblemTypeConfiguration : EntityBaseConfiguration<ProblemType>
  {
    public ProblemTypeConfiguration()
    {
      Property(s => s.Description).IsOptional();
    }
  }
}
