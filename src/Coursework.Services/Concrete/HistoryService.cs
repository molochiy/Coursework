using System.Security.Principal;
using Coursework.Entities.DatabaseEntities;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Repositories.Abstract;
using Coursework.Services.Abstract;

namespace Coursework.Services.Concrete
{
  public class HistoryService : ServiceBase, IHistoryService
  {

    private readonly IAutoMapper _mapper;

    public HistoryService(IRepository repository, IAutoMapper mapper) : base(repository)
    {
      _mapper = mapper;
    }

    public Entities.ServicesEntities.AntennasSynthesisProblem GetAntennasSynthesisProblemById(int Id)
    {
      var problem = _repository.GetSingle<Entities.DatabaseEntities.AntennasSynthesisProblem>(u => u.Id == Id);
      return new Entities.ServicesEntities.AntennasSynthesisProblem
      {
        CreationDate = problem.CreationDate,
        FModule = problem.FModule,
        FArgument = problem.FArgument,
        Eps = problem.Eps,
        C1 = problem.C1,
        C2 = problem.C2,
        M1 = problem.M1,
        M2 = problem.M2,
        StateId = 1,
        UserId = problem.UserId
      };
    }

    public Entities.ServicesEntities.BranchingLinesProblem GetBranchingLinesProblemById(int Id)
    {
      var problem = _repository.GetSingle<Entities.DatabaseEntities.BranchingLinesProblem>(u => u.Id == Id);
      return new Entities.ServicesEntities.BranchingLinesProblem
      {
        CreationDate = problem.CreationDate,
        FModule = problem.FModule,
        FArgument = problem.FArgument,
        Eps = problem.Eps,
        M1 = problem.M1,
        M2 = problem.M2,
        StateId = 1,
        UserId = problem.UserId
      };
    }
  }
}
