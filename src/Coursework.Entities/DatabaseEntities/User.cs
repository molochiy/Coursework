﻿using System.Collections.Generic;

namespace Coursework.Entities.DatabaseEntities
{
  public class User: EntityBase
  {
    public User()
    {
      Roles = new HashSet<Role>();
      AntennasSynthesisProblems = new List<AntennasSynthesisProblem>();
      BranchingLinesProblems = new List<BranchingLinesProblem>();
    }

    public string Username { get; set; }
    public string Email { get; set; }
    public string HashedPassword { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<AntennasSynthesisProblem> AntennasSynthesisProblems { get; set; }
    public virtual ICollection<BranchingLinesProblem> BranchingLinesProblems { get; set; }
  }
}
