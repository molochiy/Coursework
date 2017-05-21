using System.Net;
using System.Net.Http;
using System.Web.Http;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Entities.ViewModels;
using Coursework.Services.Abstract;

namespace Coursework.Web.ApiControllers
{
  [Authorize(Roles = "Admin")]
  [RoutePrefix("api/account")]
  public class AccountController : ApiControllerBase
  {
    private readonly IMembershipService _membershipService;
    private readonly IAutoMapper _mapper;

    public AccountController(IMembershipService membershipService, IAutoMapper mapper)
    {
      _membershipService = membershipService;
      _mapper = mapper;
    }

    [AllowAnonymous]
    [Route("authenticate")]
    [HttpPost]
    public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
    {
      return CreateHttpResponse(request, () =>
      {
        HttpResponseMessage response;

        if (ModelState.IsValid)
        {
          var membershipContext = _membershipService.ValidateUser(user.Username, user.Password);

          response = request.CreateResponse(HttpStatusCode.OK, membershipContext.User != null ? new { success = true } : new { success = false });
        }
        else
        {
          response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
        }

        return response;
      });
    }

    [AllowAnonymous]
    [Route("register")]
    [HttpPost]
    public HttpResponseMessage Register(HttpRequestMessage request, RegistrationViewModel user)
    {
      return CreateHttpResponse(request, () =>
      {
        HttpResponseMessage response = null;

        if (!ModelState.IsValid)
        {
          response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
        }
        else
        {

          var userEntity = _mapper.Map<User>(user);
          var registeredUser = _membershipService.CreateUser(userEntity, new[] { 1 });

          response = request.CreateResponse(HttpStatusCode.OK, registeredUser != null ? new { success = true } : new { success = false });
        }

        return response;
      });
    }
  }
}