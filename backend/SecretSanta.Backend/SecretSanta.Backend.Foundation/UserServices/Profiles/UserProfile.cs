using AutoMapper;
using SecretSanta.Backend.DomainModel;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>()
            .ForMember(u => u.UserName, options => options.MapFrom((source, _) => source.Email))
            .ReverseMap();
    }
}