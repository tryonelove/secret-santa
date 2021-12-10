using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SecretSanta.Backend.DataAccess;
using SecretSanta.Backend.DomainModel;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Commands;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, UserDto>
{
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;


    public RegisterCommandHandler(
        IMapper mapper,
        ApplicationDbContext dataContext,
        UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }


    public async Task<UserDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request.User);

        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            return null;
        }

        return request.User;
    }


    private Exception CreateFrom(IdentityError identityError)
    {
        return new Exception(identityError.Description);
    }
}