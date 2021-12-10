using MediatR;
using SecretSanta.Backend.Foundation.UserServices.Models;

namespace SecretSanta.Backend.Foundation.UserServices.Commands;

public class RegisterCommand : IRequest<UserDto>
{
    public UserDto User { get; }

    public string Password { get; }

    public bool AutoSignIn { get; }


    public RegisterCommand(UserDto user, string password, bool autoSignIn = false)
    {
        User = user;
        Password = password;
        AutoSignIn = autoSignIn;
    }
}