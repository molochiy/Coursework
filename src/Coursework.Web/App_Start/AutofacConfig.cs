﻿using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Coursework.Services.Abstract;

namespace Coursework.Web
{
  public class AutofacConfig
  {
    public static void Initialize()
    {
      var builder = new ContainerBuilder();

      builder.RegisterModule<AutofacModule>();
      builder.RegisterModule<Entities.AutofacModule>();
      builder.RegisterModule<Services.AutofacModule>();

      var container = builder.Build();
      container.Resolve<ISolverService>().StartSolver();

      DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
      GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}