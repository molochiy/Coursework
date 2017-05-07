using Coursework.Repositories.Abstract;

namespace Coursework.Repositories.Concrete
{
  public class CourseworkDataContextFactory: IDataContextFactory
  {
    private readonly IDataContextSettings _dataContextSettings;

    public CourseworkDataContextFactory(IDataContextSettings dataContextSettings)
    {
      _dataContextSettings = dataContextSettings;
    }

    public IDataContext NewInstance(bool explicitOpenConnection = false)
    {
      return new CourseworkDataContext(_dataContextSettings, explicitOpenConnection);
    }
  }
}
