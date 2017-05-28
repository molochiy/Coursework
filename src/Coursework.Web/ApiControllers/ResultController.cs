using System.Net;
using System.Net.Http;
using System.Web.Http;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Services.Abstract;

namespace Coursework.Web.ApiControllers
{
  [Authorize(Roles = "Admin")]
  [RoutePrefix("api/results")]
  public class ResultController : ApiControllerBase
  {
    private readonly IResultService _resultService;
    private readonly IAutoMapper _mapper;

    public ResultController(IResultService resultService, IAutoMapper mapper)
    {
      _resultService = resultService;
      _mapper = mapper;
    }

    [Route("")]
    [HttpGet]
    public HttpResponseMessage Get(HttpRequestMessage request, int problemId, int problemTypeId)
    {
      return CreateHttpResponse(request, () =>
        {
          if (problemTypeId == 1 || problemTypeId == 2)
          {
            var result = _resultService.GetAntennasRadiationPatternProblemResult(problemId);
            return request.CreateResponse(HttpStatusCode.OK, new { result });
          }
          else
          {
            var result = _resultService.GetBranchingPointsProblemResult(problemId);
            return request.CreateResponse(HttpStatusCode.OK, new { result });
          }
        });
    }
  }
}
