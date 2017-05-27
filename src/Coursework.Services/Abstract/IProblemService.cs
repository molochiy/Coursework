using System.Collections.Generic;
using Coursework.Entities.ServicesEntities;

namespace Coursework.Services.Abstract
{
  public interface IProblemService
  {
    Problem AddProblem(Problem problem);

    List<Problem> GetProblems(int userId, int problemTypeId);
  }
}