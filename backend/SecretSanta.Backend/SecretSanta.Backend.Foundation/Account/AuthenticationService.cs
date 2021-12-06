using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SecretSanta.Backend.Common;
using SecretSanta.Backend.DomainModel;
using SecretSanta.Backend.Foundation.Account.Errors;
using SecretSanta.Backend.Foundation.Account.Interfaces;
using SecretSanta.Backend.Foundation.Authentication.Models;

namespace SecretSanta.Backend.Foundation.Account;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;


    public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }


    public async Task<OperationResult<UserDto, UserRegisterError>> RegisterAsync(UserDto userDto, string password, bool authSignIn)
    {
        var user = _mapper.Map<UserDto, User>(userDto);

        var result = await _userManager.CreateAsync(user, password);

        if (authSignIn)
        {
            await _signInManager.SignInAsync(user, false);
        }

        return OperationResult<UserDto, UserRegisterError>.CreateSuccessful(userDto);
    }

    public Task<OperationResult<UserDto, UserRegisterError>> RegisterAsync(UserDto userDto, string password)
    {
        throw new NotImplementedException();
    }
}