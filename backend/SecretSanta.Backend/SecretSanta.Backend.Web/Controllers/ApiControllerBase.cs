using Microsoft.AspNetCore.Mvc;

namespace SecretSanta.Backend.Web.Controllers;

[ApiController]
[Route("/api/[controller]/")]
public abstract class ApiControllerBase : ControllerBase
{

}