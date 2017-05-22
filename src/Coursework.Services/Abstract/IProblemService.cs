using Coursework.Entities.ServicesEntities;

namespace Coursework.Services.Abstract
{
  public interface IProblemService
  {
    bool SetAntennasSynthesisProblem(AntennasSynthesisProblem problem);

    bool SetBranchingLinesProblem(BranchingLinesProblem problem);
  }
}