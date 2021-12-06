using Moq;
using SecretSanta.Backend.Foundation.Account.Interfaces;
using Xunit;

namespace SecretSanta.Backend.Tests;

public class AuthenticationTests
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationTests()
    {
        var service = new Mock<IAuthenticationService>();
    }


    [Fact]
    public void CanRegister_ValidInput()
    {
        // todo
    }
}