using Coursework.Entities.ServicesEntities;

namespace Coursework.Services.Abstract
{
  public interface IHistoryService
  {
    AntennasSynthesisProblem GetAntennasSynthesisProblemById(int Id);

    BranchingLinesProblem GetBranchingLinesProblemById(int Id);
  }
}
