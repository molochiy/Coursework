using System.Web.Http;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Entities.ViewModels;
using Coursework.Services.Abstract;
using System.Web;
using System.Net.Http;
using System.Net;

namespace Coursework.Web.ApiControllers
{
  [Authorize(Roles = "Admin")]
  [RoutePrefix("api/history")]
  public class HistoryController : ApiControllerBase
  {
    private readonly IHistoryService _historyService;
    private readonly IAutoMapper _mapper;

    public HistoryController(IHistoryService historyService, IAutoMapper mapper)
    {
      _historyService = historyService;
      _mapper = mapper;
    }

    [Route("get/problem1")]
    [HttpGet]
    public HttpResponseMessage GetAntennasSynthesisProblem(HttpRequestMessage request, int id)
    {
      return CreateHttpResponse(request, () => request.CreateResponse(HttpStatusCode.OK, new { results = _historyService.GetAntennasSynthesisProblemById(id) }));
    }

    [Route("get/problem2")]
    [HttpGet]
    public HttpResponseMessage GetBranchingLinesProblem(HttpRequestMessage request, int id)
    {
      return CreateHttpResponse(request, () => request.CreateResponse(HttpStatusCode.OK, new { results = _historyService.GetBranchingLinesProblemById(id) }));
    }
  }
}
