using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Coursework.Repositories.Abstract;

namespace Coursework.Repositories.Concrete
{
  public class CourseworkRepository: RepositoryBase, IRepository
  {
    public CourseworkRepository(IDataContextFactory dataContextFactory) : base(dataContextFactory)
    {
    }

    public TEntity GetByKey<TKey, TEntity>(string keyPropertyName, TKey key, params Expression<Func<TEntity, object>>[] paths) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        var query = context.Query<TEntity>();
        query = IncludePaths(paths, query);

        return query.Single(GetSelectByKeyCriteria<TKey, TEntity>(keyPropertyName, key));
      }
    }

    public List<TEntity> Get<TEntity>(Func<TEntity, bool> criteria = null, params Expression<Func<TEntity, object>>[] paths) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        var query = context.Query<TEntity>();
        query = IncludePaths(paths, query);
        if (criteria != null)
        {
          query = query.Where(criteria).AsQueryable();
        }

        return query.ToList();
      }
    }

    public TEntity GetSingle<TEntity>(Func<TEntity, bool> criteria = null, params Expression<Func<TEntity, object>>[] paths) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        var query = context.Query<TEntity>();
        query = IncludePaths(paths, query);
        if (criteria != null)
        {
          query = query.Where(criteria).AsQueryable();
        }

        return query.SingleOrDefault();
      }
    }

    public int Count<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        var query = context.Query<TEntity>();

        if (criteria != null)
        {
          query = query.Where(criteria).AsQueryable();
        }

        return query.Count();
      }
    }

    public bool Exists<TEntity>(Func<TEntity, bool> criteria = null) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        var query = context.Query<TEntity>();

        return criteria != null ? query.Any(criteria) : query.Any();
      }
    }

    public TEntity Update<TEntity>(TEntity entity) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        context.AttachModified(entity);
        context.SaveChanges();

        return entity;
      }
    }

    public TEntity Insert<TEntity>(TEntity entity) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        context.Insert(entity);
        context.SaveChanges();

        return entity;
      }
    }

    public void Delete<TKey, TEntity>(string keyPropertyName, TKey key) where TEntity : class
    {
      using (var context = DataContextFactory.NewInstance())
      {
        var entity = context.Query<TEntity>().Single(GetSelectByKeyCriteria<TKey, TEntity>(keyPropertyName, key));
        context.Delete(entity);
        context.SaveChanges();
      }
    }
  }
}
