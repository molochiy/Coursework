using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Coursework.Web
{
  public class AutofacConfig
  {
    public static void Initialize()
    {
      var builder = new ContainerBuilder();

      builder.RegisterModule<AutofacModule>();
      builder.RegisterModule<Repositories.AutofacModule>();

      var container = builder.Build();

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}