using AutoMapper;
using Coursework.Entities.ServicesEntities;
using Coursework.Entities.ViewModels;

namespace Coursework.Entities.TypeMapping.MappingProfiles
{
  public class ViewModelsServiceEntitiesMappingProfile : Profile
  {
    public ViewModelsServiceEntitiesMappingProfile()
    {
      CreateMap<LoginViewModel, User>()
        .ForMember(u => u.Email, lvm => lvm.Ignore());
      CreateMap<User, LoginViewModel>();


      CreateMap<RegistrationViewModel, User>();
      CreateMap<User, RegistrationViewModel>();
    }
  }
}
