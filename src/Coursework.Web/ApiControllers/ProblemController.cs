using System.Collections.Generic;
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

    [HttpPost]
    public HttpResponseMessage AddProblem(HttpRequestMessage request, ProblemViewModel problem)
    {
      return CreateHttpResponse(request, () =>
      {
        var userId = _membershipService.GetUserIdByLogin(HttpContext.Current.User.Identity.Name);

        var problemEntity = _mapper.Map<Problem>(problem);
        problemEntity.UserId = userId;

        var addedProblemEntity = _problemService.AddProblem(problemEntity);

        var addedProblem = _mapper.Map<ProblemViewModel>(addedProblemEntity);

        return request.CreateResponse(HttpStatusCode.OK, addedProblem);
      });
    }

    [Route("all")]
    [HttpGet]
    public HttpResponseMessage GetProblems(HttpRequestMessage request, int problemTypeId)
    {
      return CreateHttpResponse(request, () =>
      {
        var userId = _membershipService.GetUserIdByLogin(HttpContext.Current.User.Identity.Name);

        var problemEntities = _problemService.GetProblems(userId, problemTypeId);

        var problems = _mapper.Map<List<ProblemViewModel>>(problemEntities);

        return request.CreateResponse(HttpStatusCode.OK, problems);
      });
    }
  }
}