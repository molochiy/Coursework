using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class ProblemConfiguration: EntityBaseConfiguration<Problem>
  {
    public ProblemConfiguration()
    {
      Property(p => p.C1).IsRequired();
      Property(p => p.C2).IsRequired();
      Property(p => p.NumberPartitionsC1).IsRequired();
      Property(p => p.NumberPartitionsC2).IsRequired();
      Property(p => p.CreationDate).IsRequired();
      Property(p => p.Eps).IsRequired();
      Property(p => p.FArgument).IsRequired();
      Property(p => p.FModule).IsRequired();
      Property(p => p.M1).IsRequired();
      Property(p => p.M2).IsRequired();
      Property(p => p.ResultId).IsOptional();
      Property(p => p.StateId).IsRequired();
      Property(p => p.TaskId).IsOptional();
      Property(p => p.UserId).IsRequired();
      Property(p => p.TypeId).IsRequired();

      HasRequired(p => p.State).WithMany().HasForeignKey(p => p.StateId);
      HasOptional(p => p.Result).WithMany().HasForeignKey(p => p.ResultId);
      HasRequired(p => p.ProblemType).WithMany().HasForeignKey(p => p.TypeId);
      HasRequired(p => p.User).WithMany(u => u.Problems).HasForeignKey(p => p.UserId);
    }
  }
}
