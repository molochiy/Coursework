using System.Net;
using System.Net.Http;
using System.Web.Http;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Entities.ViewModels;
using Coursework.Services.Abstract;
using System.Web;

namespace Coursework.Web.ApiControllers
{
  [Authorize(Roles = "Admin")]
  [RoutePrefix("api/problem")]
  public class ProblemController : ApiControllerBase
  {
    private readonly IMembershipService _membershipService;
    private readonly IProblemService _problemService;
    private readonly IAutoMapper _mapper;

    public ProblemController(IMembershipService membershipService, IProblemService problemService, IAutoMapper mapper)
    {
      _membershipService = membershipService;
      _problemService = problemService;
      _mapper = mapper;
    }

    [Route("submit/problem1")]
    [HttpPost]
    public HttpResponseMessage SubmitAntennasSynthesisProblem(HttpRequestMessage request, AntennasSynthesisProblem problem)
    {
      var userID = _membershipService.GetUserIdByLogin(HttpContext.Current.User.Identity.Name);

      bool result = _problemService.SetAntennasSynthesisProblem(new AntennasSynthesisProblem
      {
        CreationDate = System.DateTime.Now,
        FModule = problem.FModule,
        FArgument = problem.FArgument,
        Eps = problem.Eps,
        C1 = problem.C1,
        C2 = problem.C2,
        M1 = problem.M1,
        M2 = problem.M2,
        StateId = 1,
        UserId = userID
      });
      return request.CreateResponse(HttpStatusCode.OK, new { success = result });
    }

    [Route("submit/problem2")]
    [HttpPost]
    public HttpResponseMessage SubmitBranchingLinesProblem(HttpRequestMessage request, BranchingLinesProblem problem)
    {
      var userID = _membershipService.GetUserIdByLogin(HttpContext.Current.User.Identity.Name);

      bool result = _problemService.SetBranchingLinesProblem(new BranchingLinesProblem
      {
        CreationDate = System.DateTime.Now,
        FModule = problem.FModule,
        FArgument = problem.FArgument,
        Eps = problem.Eps,
        M1 = problem.M1,
        M2 = problem.M2,
        StateId = 1,
        UserId = userID
      });
      return request.CreateResponse(HttpStatusCode.OK, new { success = result });
    }
  }
}