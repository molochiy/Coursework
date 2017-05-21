using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coursework.Web.ApiControllers
{
  [Authorize(Roles = "Admin")]
  [RoutePrefix("api/results")]
  public class ResultController : ApiControllerBase
  {
    [Route("")]
    [HttpGet]
    public HttpResponseMessage Get(HttpRequestMessage request)
    {
      return CreateHttpResponse(request, () => request.CreateResponse(HttpStatusCode.OK, new { results = "problem results" }));
    }
  }
}
