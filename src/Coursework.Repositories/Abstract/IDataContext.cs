using System;
using System.Collections.Generic;
using System.Linq;

namespace Coursework.Repositories.Abstract
{
  public interface IDataContext : IDisposable
  {
    IQueryable<TEntity> Query<TEntity>() where TEntity : class;
    void Insert<TEntity>(TEntity entity) where TEntity : class;
    void AttachModified<TEntity>(TEntity entity) where TEntity : class;
    void Delete<TEntity>(TEntity entity) where TEntity : class;
    void SaveChanges();
  }
}
