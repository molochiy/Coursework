using AutoMapper;
using Coursework.Entities.TypeMapping.MappingProfiles;

namespace Coursework.Entities.TypeMapping
{
  public static class AutoMapperConfiguration
  {
    public static void Configure()
    {
      Mapper.Initialize(x =>
      {
        x.AddProfile<ViewModelsServiceEntitiesMappingProfile>();
        x.AddProfile<DatabaseEntitiesServiceEntitiesMappingProfile>();
      });
    }
  }
}
