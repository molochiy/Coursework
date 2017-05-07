using Coursework.Repositories.Abstract;

namespace Coursework.Repositories.Concrete
{
  public class DefaultDataContextSettings : IDataContextSettings
  {
    public DefaultDataContextSettings(string connectionString)
    {
      ConnectionString = connectionString;
    }

    public string ConnectionString { get; }
  }
}