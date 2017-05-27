using AutoMapper;
using Coursework.Entities.ServicesEntities;

namespace Coursework.Entities.TypeMapping.MappingProfiles
{
  public class DatabaseEntitiesServiceEntitiesMappingProfile : Profile
  {
    public DatabaseEntitiesServiceEntitiesMappingProfile()
    {
      CreateMap<DatabaseEntities.User, User>();

      CreateMap<DatabaseEntities.Problem, Problem>();

      CreateMap<Problem, DatabaseEntities.Problem>()
        .ForMember(pe => pe.Id, p => p.Ignore())
        .ForMember(pe => pe.TaskId, p => p.Ignore())
        .ForMember(pe => pe.ResultId, p => p.Ignore());

      CreateMap<DatabaseEntities.ProblemResult, ProblemResult>();
    }
  }
}
