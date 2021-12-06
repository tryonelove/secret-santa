using Microsoft.AspNetCore.Mvc;
using SecretSanta.Backend.Foundation.Account.Interfaces;

namespace SecretSanta.Backend.Web.Controllers;

public class AccountController : ApiControllerBase
{
    private readonly IAuthenticationService _authenticationService;


    public AccountController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost]
    public async Task Register(string username, string password)
    {
        await _authenticationService.RegisterAsync(null, string.Empty);
    }
}