using System.Data.Entity;
using System.Linq;
using Coursework.Repositories.Abstract;
using Coursework.Repositories.Configuration;

namespace Coursework.Repositories.Concrete
{
  public class CourseworkDataContext : Disposable, IDataContext
  {
    private readonly IDataContextSettings _dataContextSettings;
    private readonly bool _explicitOpenConnection;
    private CourseworkContext _courseworkContext;

    #region Constructors
    public CourseworkDataContext(IDataContextSettings dataContextSettings, bool explicitOpenConnection)
    {
      _dataContextSettings = dataContextSettings;
      _explicitOpenConnection = explicitOpenConnection;
    }
    #endregion

    #region IDataContext
    public IQueryable<TEntity> Query<TEntity>() where TEntity : class
    {
      return CourseworkContext.Set<TEntity>();
    }

    public void Insert<TEntity>(TEntity entity) where TEntity : class
    {
      CourseworkContext.Set<TEntity>().Add(entity);
    }

    public void AttachModified<TEntity>(TEntity entity) where TEntity : class
    {
      CourseworkContext.Set<TEntity>().Attach(entity);
      CourseworkContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
      CourseworkContext.Set<TEntity>().Remove(entity);
    }

    public void SaveChanges()
    {
      CourseworkContext.SaveChanges();
    }
    #endregion

    #region IDisposable
    protected override void DisposeCore()
    {
      _courseworkContext?.Dispose();
    }
    #endregion

    #region Helpers
    private CourseworkContext CourseworkContext => _courseworkContext ?? (_courseworkContext = CreateCourseworkContext());

    private CourseworkContext CreateCourseworkContext()
    {
      var courseworkContext = new CourseworkContext(_dataContextSettings.ConnectionString);

      courseworkContext.Configuration.ProxyCreationEnabled = false;

      if (_explicitOpenConnection)
      {
        if (courseworkContext.Database.Connection.State != System.Data.ConnectionState.Open)
        {
          courseworkContext.Database.Connection.Open();
        }
      }
      return courseworkContext;
    }
    #endregion
  }
}