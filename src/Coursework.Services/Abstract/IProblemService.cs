using Coursework.Entities.ServicesEntities;

namespace Coursework.Services.Abstract
{
  public interface IProblemService
  {
    bool SetAntennasSynthesisProblem(AntennasRadiationPatternProblem problem);

    bool SetBranchingLinesProblem(BranchingPointsProblem problem);
  }
}