using System.Web.Http;
using Coursework.Web.Infrastructure;
using Newtonsoft.Json.Serialization;

namespace Coursework.Web
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      config.MessageHandlers.Add(new AuthenticationHandler());

      config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
      config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
