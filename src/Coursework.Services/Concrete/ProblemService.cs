using System;
using System.Linq;
using System.Security.Principal;
using Coursework.Entities.DatabaseEntities;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Repositories.Abstract;
using Coursework.Services.Abstract;

namespace Coursework.Services.Concrete
{
  public class ProblemService : ServiceBase, IProblemService
  {
    private readonly IAutoMapper _mapper;

    public ProblemService(IRepository repository,  IAutoMapper mapper) : base(repository)
    {
      _mapper = mapper;
    }

    public bool SetAntennasSynthesisProblem(Entities.ServicesEntities.AntennasRadiationPatternProblem pr)
    {
      try
      {
        var createdUser = _repository.Insert(new Entities.DatabaseEntities.AntennasRadiationPatternProblem
        {
          C1 = pr.C1,
          C2 = pr.C2,
          CreationDate = pr.CreationDate,
          Eps = pr.Eps,
          FArgument = pr.FArgument,
          FModule = pr.FModule,
          M1 = pr.M1,
          M2 = pr.M2,
          StateId = pr.StateId,
          UserId = pr.UserId,
        });
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }

    public bool SetBranchingLinesProblem(Entities.ServicesEntities.BranchingPointsProblem pr)
    {
      try
      {
        var createdUser = _repository.Insert(new Entities.DatabaseEntities.BranchingPointsProblem
        {
          CreationDate = pr.CreationDate,
          Eps = pr.Eps,
          FArgument = pr.FArgument,
          FModule = pr.FModule,
          M1 = pr.M1,
          M2 = pr.M2,
          StateId = pr.StateId,
          UserId = pr.UserId,
        });
        return true;
      }
      catch (Exception)
      {
        return false;
      }
    }
  }
}
