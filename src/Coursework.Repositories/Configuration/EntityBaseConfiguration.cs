﻿using System.Data.Entity.ModelConfiguration;
using Coursework.Entities.DatabaseEntities;

namespace Coursework.Repositories.Configuration
{
  public class EntityBaseConfiguration<T>: EntityTypeConfiguration<T> where T: EntityBase
  {
    public EntityBaseConfiguration()
    {
      HasKey(e => e.Id);
    }
  }
}
