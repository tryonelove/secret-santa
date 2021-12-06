using SecretSanta.Backend.Common;
using SecretSanta.Backend.Foundation.Account.Errors;
using SecretSanta.Backend.Foundation.Authentication.Models;

namespace SecretSanta.Backend.Foundation.Account.Interfaces;

public interface IAuthenticationService
{
    Task<OperationResult<UserDto, UserRegisterError>> RegisterAsync(UserDto userDto, string password, bool autoSignIn = false);
}