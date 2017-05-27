using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class CourseworkContext : DbContext
  {
    public CourseworkContext()
           : base("Coursework")
    {
      Database.SetInitializer<CourseworkContext>(null);
    }

    public CourseworkContext(string connectionString) : base(connectionString)
    {
      Database.SetInitializer<CourseworkContext>(null);
    }

    public DbSet<Problem> AntennasSynthesisProblems { get; set; }
    public DbSet<ProblemResult> ProblemResults { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ProblemType> ProblemTypes { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

      modelBuilder.Configurations.Add(new ProblemConfiguration());
      modelBuilder.Configurations.Add(new ProblemResultConfiguration());
      modelBuilder.Configurations.Add(new RoleConfiguration());
      modelBuilder.Configurations.Add(new StateConfiguration());
      modelBuilder.Configurations.Add(new UserConfiguration());
      modelBuilder.Configurations.Add(new ProblemTypeConfiguration());
    }
  }
}
