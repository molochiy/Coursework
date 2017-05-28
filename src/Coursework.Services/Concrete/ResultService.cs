using Coursework.Entities.ServicesEntities;
using Coursework.Repositories.Abstract;
using Coursework.Services.Abstract;

namespace Coursework.Services.Concrete
{
  class ResultService: ServiceBase, IResultService
  {
    public ResultService(IRepository repository) : base(repository)
    {
    }

    public AntennasRadiationPatternProblemResult GetAntennasRadiationPatternProblemResult(int problemId)
    {
      var resultEntity = GetProblem(problemId);

      var result = SerializationService.FromXmlString<AntennasRadiationPatternProblemResult>(resultEntity.Result);

      return result;
    }

    public BranchingPointsProblemResult GetBranchingPointsProblemResult(int problemId)
    {
      var resultEntity = GetProblem(problemId);

      var result = SerializationService.FromXmlString<BranchingPointsProblemResult>(resultEntity.Result);

      return result;
    }

    private Entities.DatabaseEntities.ProblemResult GetProblem(int problemId)
    {
      return _repository.GetSingle<Entities.DatabaseEntities.Problem>(p => p.Id == problemId, p => p.Result).Result;
    }
  }
}
