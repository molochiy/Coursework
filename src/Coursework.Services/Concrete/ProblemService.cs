using System;
using System.Collections.Generic;
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

    public Problem AddProblem(Problem problem)
    {
      var stateId = _repository.GetSingle<Entities.DatabaseEntities.State>(s => s.Name == "Queued").Id;

      problem.StateId = stateId;
      problem.CreationDate = DateTime.Now;

      var problemEntity = _mapper.Map<Entities.DatabaseEntities.Problem>(problem);

      var addedProblemEntity = _repository.Insert(problemEntity);

      var addedProblem = _mapper.Map<Problem>(addedProblemEntity);

      return addedProblem;
    }

    public List<Problem> GetProblems(int userId, int problemTypeId)
    {
      var problemEntities = _repository.Get<Entities.DatabaseEntities.Problem>(p => p.UserId == userId && p.TypeId == problemTypeId);

      var problems = _mapper.Map<List<Problem>>(problemEntities);

      return problems;
    }
  }
}
