using AutoMapper;
using xamaLibrary;

namespace xamApi.Helpers
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<UserModel, User>();
      CreateMap<RegisterModel, UserModel>();
      CreateMap<UpdateModel, UserModel>();
    }
  }
}
