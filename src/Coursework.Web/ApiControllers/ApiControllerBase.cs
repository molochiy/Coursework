using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coursework.Web.ApiControllers
{
  public class ApiControllerBase : ApiController
  {
    protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, Antlr.Runtime.Misc.Func<HttpResponseMessage> function)
    {
      HttpResponseMessage response = null;

      try
      {
        response = function();
      }
      catch (Exception exception)
      {
        response = request.CreateResponse(HttpStatusCode.InternalServerError, new { message = exception.Message });
      }

      return response;
    }
  }
}
