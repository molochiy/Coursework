﻿using System.Security.Principal;
using Coursework.Entities.DatabaseEntities;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Repositories.Abstract;
using Coursework.Services.Abstract;
using System.Collections.Generic;

namespace Coursework.Services.Concrete
{
  public class HistoryService : ServiceBase, IHistoryService
  {

    private readonly IAutoMapper _mapper;

    public HistoryService(IRepository repository, IAutoMapper mapper) : base(repository)
    {
      _mapper = mapper;
    }

    public List<Entities.ServicesEntities.AntennasSynthesisProblem> GetAntennasSynthesisProblemByUserId(int userId)
    {
      List<Entities.ServicesEntities.AntennasSynthesisProblem> result = new List<Entities.ServicesEntities.AntennasSynthesisProblem>();
      var problemList = _repository.Get<Entities.DatabaseEntities.AntennasSynthesisProblem>(u => u.UserId == userId);
      foreach (var problem in problemList)
      {
        result.Add(new Entities.ServicesEntities.AntennasSynthesisProblem
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
        });
      };

      return result;
    }

    public List<Entities.ServicesEntities.BranchingLinesProblem> GetBranchingLinesProblemByUserId(int userId)
    {
      List<Entities.ServicesEntities.BranchingLinesProblem> result = new List<Entities.ServicesEntities.BranchingLinesProblem>();
      var problemList = _repository.Get<Entities.DatabaseEntities.BranchingLinesProblem>(u => u.UserId == userId);
      foreach (var problem in problemList)
      {
        result.Add(new Entities.ServicesEntities.BranchingLinesProblem
        {
          CreationDate = problem.CreationDate,
          FModule = problem.FModule,
          FArgument = problem.FArgument,
          Eps = problem.Eps,
          M1 = problem.M1,
          M2 = problem.M2,
          StateId = 1,
          UserId = problem.UserId
        });
      };

      return result;
    }

    public Entities.ServicesEntities.ProblemResult GetProblemResultById(int resultId)
    {
      var result = _repository.GetSingle<Entities.DatabaseEntities.ProblemResult>(u => u.Id == resultId);
      return new Entities.ServicesEntities.ProblemResult
      {
        Result = result.Result
      };
    }
  }
}
