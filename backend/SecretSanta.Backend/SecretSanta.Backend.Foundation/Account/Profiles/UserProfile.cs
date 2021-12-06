using AutoMapper;
using SecretSanta.Backend.DomainModel;
using SecretSanta.Backend.Foundation.Authentication.Models;

namespace SecretSanta.Backend.Foundation.Authentication.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<UserDto, User>()
            .ForMember(u => u.Id, options => options.Ignore());
    }
}