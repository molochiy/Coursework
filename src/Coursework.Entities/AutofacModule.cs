using Autofac;
using Coursework.Entities.TypeMapping.Abstract;
using Coursework.Entities.TypeMapping.Concrete;

namespace Coursework.Entities
{
  public class AutofacModule: Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      builder.RegisterType<AutoMapperAdapter>().As<IAutoMapper>();
    }
  }
}