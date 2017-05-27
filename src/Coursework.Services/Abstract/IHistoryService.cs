using Coursework.Entities.ServicesEntities;
using System.Collections.Generic;

namespace Coursework.Services.Abstract
{
  public interface IHistoryService
  {
    List<AntennasRadiationPatternProblem> GetAntennasSynthesisProblemByUserId(int userId);

    List<BranchingPointsProblem> GetBranchingLinesProblemByUserId(int userId);

    ProblemResult GetProblemResultById(int resultId);
  }
}
