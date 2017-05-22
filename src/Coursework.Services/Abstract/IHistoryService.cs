using Coursework.Entities.ServicesEntities;
using System.Collections.Generic;

namespace Coursework.Services.Abstract
{
  public interface IHistoryService
  {
    List<AntennasSynthesisProblem> GetAntennasSynthesisProblemByUserId(int userId);

    List<BranchingLinesProblem> GetBranchingLinesProblemByUserId(int userId);

    ProblemResult GetProblemResultById(int resultId);
  }
}
