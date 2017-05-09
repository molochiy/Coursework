﻿using Coursework.Entities;

namespace Coursework.Repositories.Configuration
{
  public class ProblemResultConfiguration: EntityBaseConfiguration<ProblemResult>
  {
    public ProblemResultConfiguration()
    {
      Property(pr => pr.Result).IsRequired();
    }
  }
}