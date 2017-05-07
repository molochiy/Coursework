using Coursework.Entities;
using System.Data.Entity.Migrations;

namespace Coursework.Repositories.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<Repositories.Configuration.CourseworkContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(Repositories.Configuration.CourseworkContext context)
    {
      base.Seed(context);
      var states = new []
      {
        new State { Id = 1, Name = "Queued" },
        new State { Id = 2, Name = "InProgress" },
        new State { Id = 3, Name = "Finished" },
        new State { Id = 4, Name = "Canceled" },
        new State { Id = 5, Name = "Aborted" }
      };

      context.States.AddOrUpdate(s => s.Id, states);

      var roles = new[]
      {
        new Role {Id = 1, Name = "Admin" },
        new Role {Id = 2, Name = "Guest" },
        new Role {Id = 3, Name = "User" }
      };

      context.Roles.AddOrUpdate(r => r.Id, roles);
    }
  }
}
