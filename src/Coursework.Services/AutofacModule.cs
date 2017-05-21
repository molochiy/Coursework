using Autofac;
using Coursework.Services.Abstract;
using Coursework.Services.Concrete;

namespace Coursework.Services
{
  public class AutofacModule: Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      builder.RegisterModule<Repositories.AutofacModule>();
      builder.RegisterType<EncryptionService>().As<IEncryptionService>();
      builder.RegisterType<MembershipService>().As<IMembershipService>();
    }
  }
}