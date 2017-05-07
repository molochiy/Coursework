using Coursework.Entities;

namespace Coursework.Repositories.Configuration
{
  public class UserConfiguration : EntityBaseConfiguration<User>
  {
    public UserConfiguration()
    {
      Property(u => u.Email).IsRequired().HasMaxLength(200);
      Property(u => u.HashedPassword).IsRequired();
      HasMany(u => u.Roles).WithMany(r => r.Users).Map(ur =>
      {
        ur.MapLeftKey("StudentId");
        ur.MapRightKey("RoleId");
        ur.ToTable("UserRoles");
      });

      //HasMany(u => u.AntennasSynthesisProblems).WithRequired(asp => asp.User).HasForeignKey(asp => asp.UserId);
      //HasMany(u => u.BranchingLinesProblems).WithRequired(blp => blp.User).HasForeignKey(blp => blp.UserId);
    }
  }
}