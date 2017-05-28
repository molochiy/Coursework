using Coursework.Entities.ServicesEntities;

namespace Coursework.Services.Abstract
{
  public interface IResultService
  {
    AntennasRadiationPatternProblemResult GetAntennasRadiationPatternProblemResult(int problemId);

    BranchingPointsProblemResult GetBranchingPointsProblemResult(int problemId);
  }
}