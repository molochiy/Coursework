using System.Configuration;
using Autofac;
using Coursework.Repositories.Abstract;
using Coursework.Repositories.Concrete;

namespace Coursework.Repositories
{
  public class AutofacModule: Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      var connectionString = ConfigurationManager.ConnectionStrings["Coursework"].ConnectionString;
      builder.Register(с => new DefaultDataContextSettings(connectionString)).As<IDataContextSettings>();
      builder.RegisterType<CourseworkDataContextFactory>().As<IDataContextFactory>();
      builder.RegisterType<CourseworkRepository>().As<IRepository>();
    }
  }
}
