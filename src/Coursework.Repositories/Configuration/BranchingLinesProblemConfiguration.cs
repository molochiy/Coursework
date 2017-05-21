using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class BranchingLinesProblemConfiguration: EntityBaseConfiguration<BranchingLinesProblem>
  {
    public BranchingLinesProblemConfiguration()
    {
      Property(blp => blp.CreationDate).IsRequired();
      Property(blp => blp.Eps).IsRequired();
      Property(blp => blp.FArgument).IsRequired();
      Property(blp => blp.FModule).IsRequired();
      Property(blp => blp.M1).IsRequired();
      Property(blp => blp.M2).IsRequired();
      Property(blp => blp.ResultId).IsOptional();
      Property(blp => blp.StateId).IsRequired();
      Property(blp => blp.TaskId).IsOptional();
      Property(blp => blp.UserId).IsRequired();

      HasRequired(blp => blp.State).WithMany().HasForeignKey(blp => blp.StateId);
      HasOptional(blp => blp.Result).WithMany().HasForeignKey(blp => blp.ResultId);
      HasRequired(blp => blp.User).WithMany(u => u.BranchingLinesProblems).HasForeignKey(blp => blp.UserId);
    }
  }
}