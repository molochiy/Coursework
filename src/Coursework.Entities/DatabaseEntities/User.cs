using System.Collections.Generic;

namespace Coursework.Entities.DatabaseEntities
{
  public class User: EntityBase
  {
    public User()
    {
      Roles = new HashSet<Role>();
      AntennasSynthesisProblems = new List<AntennasRadiationPatternProblem>();
      BranchingLinesProblems = new List<BranchingPointsProblem>();
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<AntennasRadiationPatternProblem> AntennasSynthesisProblems { get; set; }
    public virtual ICollection<BranchingPointsProblem> BranchingLinesProblems { get; set; }
  }
}
