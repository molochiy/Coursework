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
    private readonly IMembershipService _membershipService;
    private readonly IHistoryService _historyService;
    private readonly IAutoMapper _mapper;

    public HistoryController(IMembershipService membershipService, IHistoryService historyService, IAutoMapper mapper)
    {
      _membershipService = membershipService;
      _historyService = historyService;
      _mapper = mapper;
    }

    //[Route("problem1")]
    //[HttpGet]
    //public HttpResponseMessage GetAntennasSynthesisProblem(HttpRequestMessage request)
    //{
    //  var userID = _membershipService.GetUserIdByLogin(HttpContext.Current.User.Identity.Name);
    //  return CreateHttpResponse(request, () => request.CreateResponse(HttpStatusCode.OK, new { results = _historyService.GetAntennasSynthesisProblemByUserId(userID) }));
    //}

    //[Route("problem2")]
    //[HttpGet]
    //public HttpResponseMessage GetBranchingLinesProblem(HttpRequestMessage request)
    //{
    //  var userID = _membershipService.GetUserIdByLogin(HttpContext.Current.User.Identity.Name);
    //  return CreateHttpResponse(request, () => request.CreateResponse(HttpStatusCode.OK, new { results = _historyService.GetBranchingLinesProblemByUserId(userID) }));
    //}

    //[Route("result")]
    //[HttpGet]
    //public HttpResponseMessage GetResult(HttpRequestMessage request, int resultId)
    //{
    //  return CreateHttpResponse(request, () => request.CreateResponse(HttpStatusCode.OK, new { results = _historyService.GetProblemResultById(resultId) }));
    //}
  }
}
