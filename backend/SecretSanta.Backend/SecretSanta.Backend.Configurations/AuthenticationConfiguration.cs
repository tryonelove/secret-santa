using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SecretSanta.Backend.Configurations;

public static class AuthenticationConfiguration
{
    public const string Issuer = "SecretSantaServer";

    public const string Audience = "SecretSantaClient";

    public const int TokenTimeout = 60;


    public static SymmetricSecurityKey CreateSymmetricSecurityKey(string key)
    {
        return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key));
    }
}