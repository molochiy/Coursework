using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;

namespace Coursework.Web
{
  public class AutofacModule: Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());
      builder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
    }
  }
}