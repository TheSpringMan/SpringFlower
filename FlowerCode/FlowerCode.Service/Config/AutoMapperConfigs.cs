using AutoMapper;
using FlowerCode.Model.Entity;
namespace FlowerCode.Service.Config;
public class AutoMapperConfigs : Profile
{
    public AutoMapperConfigs()
    {
        CreateMap<User, UserRes>();
        CreateMap<RegisterReq, User>();
    }
}