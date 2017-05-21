using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Coursework.Web.Infrastructure.Extensions;

namespace Coursework.Web.Infrastructure
{
  public class AuthenticationHandler : DelegatingHandler
  {
    private IEnumerable<string> _authHeaderValues;

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
      try
      {
        request.Headers.TryGetValues("Authorization", out _authHeaderValues);
        if (_authHeaderValues == null)
        {
          return base.SendAsync(request, cancellationToken);
        }

        var tokens = _authHeaderValues.FirstOrDefault();
        if (!string.IsNullOrEmpty(tokens) 
          && !string.IsNullOrEmpty(tokens = tokens.Replace("Basic", string.Empty).Trim()))
        {
          var data = Convert.FromBase64String(tokens);
          var decodedString = Encoding.UTF8.GetString(data);
          var tokensValues = decodedString.Split(':');

          var membershipService = request.GetMembershipService();

          var membershipContext = membershipService.ValidateUser(tokensValues[0], tokensValues[1]);
          if (membershipContext.User != null)
          {
            var principal = membershipContext.Principal;
            Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
          }
          else
          {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var tcs = new TaskCompletionSource<HttpResponseMessage>();
            tcs.SetResult(response);

            return tcs.Task;
          }
        }
        else
        {
          var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
          var tcs = new TaskCompletionSource<HttpResponseMessage>();
          tcs.SetResult(response);

          return tcs.Task;
        }

        return base.SendAsync(request, cancellationToken);
      }
      catch (Exception)
      {
        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
        var tcs = new TaskCompletionSource<HttpResponseMessage>();
        tcs.SetResult(response);

        return tcs.Task;
      }
    }
  }
}