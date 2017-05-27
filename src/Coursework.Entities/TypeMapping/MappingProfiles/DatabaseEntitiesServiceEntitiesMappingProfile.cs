using AutoMapper;
using Coursework.Entities.ServicesEntities;

namespace Coursework.Entities.TypeMapping.MappingProfiles
{
  public class DatabaseEntitiesServiceEntitiesMappingProfile : Profile
  {
    public DatabaseEntitiesServiceEntitiesMappingProfile()
    {
      CreateMap<DatabaseEntities.User, User>();
      CreateMap<DatabaseEntities.AntennasRadiationPatternProblem, AntennasRadiationPatternProblem>();
      CreateMap<DatabaseEntities.BranchingPointsProblem, BranchingPointsProblem>();
      CreateMap<DatabaseEntities.ProblemResult, ProblemResult>();
    }
  }
}
