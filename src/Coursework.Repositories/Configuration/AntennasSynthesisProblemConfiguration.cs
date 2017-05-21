using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class AntennasSynthesisProblemConfiguration: EntityBaseConfiguration<AntennasSynthesisProblem>
  {
    public AntennasSynthesisProblemConfiguration()
    {
      Property(asp => asp.C1).IsRequired();
      Property(asp => asp.C2).IsRequired();
      Property(asp => asp.CreationDate).IsRequired();
      Property(asp => asp.Eps).IsRequired();
      Property(asp => asp.FArgument).IsRequired();
      Property(asp => asp.FModule).IsRequired();
      Property(asp => asp.M1).IsRequired();
      Property(asp => asp.M2).IsRequired();
      Property(asp => asp.ResultId).IsOptional();
      Property(asp => asp.StateId).IsRequired();
      Property(asp => asp.TaskId).IsOptional();
      Property(blp => blp.UserId).IsRequired();

      HasRequired(asp => asp.State).WithMany().HasForeignKey(asp => asp.StateId);
      HasOptional(asp => asp.Result).WithMany().HasForeignKey(asp => asp.ResultId);
      HasRequired(asp => asp.User).WithMany(u => u.AntennasSynthesisProblems).HasForeignKey(asp => asp.UserId);
    }
  }
}
